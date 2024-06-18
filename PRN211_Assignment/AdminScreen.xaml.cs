using Core;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : System.Windows.Window, INotifyPropertyChanged
    {
        private Appointment _appointment = new Appointment();

        private AcceptedAppointmentList _list;

        public event PropertyChangedEventHandler? PropertyChanged;

        public AcceptedAppointmentList List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(List));
            }
        }
        public AdminScreen()
        {
            DataContext = this;
            InitializeComponent();
            List = new AcceptedAppointmentList();
        }

        public AdminScreen(List<AcceptedAppointmentDTO> list)
        {
            DataContext = this;
            InitializeComponent();
            List = new AcceptedAppointmentList();
            foreach (var items in list)
            {
                List.AddAppointment(items);
            }
        }

        private void dtgCusRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //CreateAppointment CreateWindow = new CreateAppointment();
            //using (var dbcontext = new db())
            //{

            //    if (CreateWindow.ShowDialog() == true)
            //    {
            //        var newRe = CreateWindow.Tag as Appointment;
            //        app.Add(newRe);
            //        dbcontext.Appointment.Add(newRe);
            //        dbcontext.SaveChanges();
            //    }

            //    var listRe = dbcontext.Appointment.ToList();
            //    dtgCusRequest.ItemsSource = listRe;
            //}
        }

        private void btnShowAcceptedRequest_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment app = new AcceptedAppointment();
            app.Show();
            app.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            List<AcceptedAppointmentDTO> list = [];
            foreach (var item in _list)
            {
                list.Add(item);
            }
            MainWindow mainWindow = new MainWindow(list);
            mainWindow.Show();
            Close();
        }

        private void btnCreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (_appointment != null)
            {
                var cus = txtCusName.Text;
                if (string.IsNullOrWhiteSpace(cus))
                {
                    MessageBox.Show("Customer's name cannot be empty.");
                    return;
                }
                var note = txtNote.Text;
                

                //if (cbbIsCheckedUp.SelectedItem != null)
                //{
                //    string selectedValue = cbbIsCheckedUp.SelectedItem.ToString();
                //    if (selectedValue.Equals("Yes"))
                //    {
                //        check = true;
                //    }
                //    else check = false;
                //}

                //if (cbbIsCancelled.SelectedItem != null)
                //{
                //    string selectedValue = cbbIsCancelled.SelectedItem.ToString();
                //    if (selectedValue.Equals("Yes"))
                //    {
                //        cancel = true;
                //    }
                //    else cancel = false;
                //}

                _appointment.DateCreated = DateOnly.FromDateTime(DateTime.Now);
                _appointment.CustomerName = cus;
                _appointment.Notes = note;

                DialogResult = true;
                this.Tag = _appointment;
                Close();
            }
        }

        private void btnShowDoctorList(object sender, RoutedEventArgs e)
        {
            ShowDoctorList mainWindow = new ShowDoctorList();
            mainWindow.Show();
            Close();
        }
    }
}
