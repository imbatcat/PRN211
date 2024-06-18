using Core;
using Entities;
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

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for AcceptedAppointment.xaml
    /// </summary>
    public partial class AcceptedAppointment : Window, INotifyPropertyChanged
    {
        //    private static readonly Lazy<AcceptedAppointment> instance =
        //new Lazy<AcceptedAppointment>(() => new AcceptedAppointment());

        //    public static AcceptedAppointment Instance => instance.Value;
        private AcceptedAppointmentList _list;

        public AcceptedAppointmentList List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged(nameof(List));
                //DataContext = this;

            }
        }
        public AcceptedAppointment()
        {

            InitializeComponent();
            List = new AcceptedAppointmentList();
        }
        public AcceptedAppointment(List<AcceptedAppointmentDTO> list)
        {
            InitializeComponent();
            List = new AcceptedAppointmentList();
            foreach (var item in list)
            {
                List.AddAppointment(item);
            }

            //load datagrid
            //using (var dbcontext = new db())
            //{
            //    var listRequest = dbcontext.Appointment.ToList();
            //    dtgCusRequest.ItemsSource = listRequest;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UpdateAppointment CreateWindow = new UpdateAppointment();
            //using (var dbcontext = new db())
            //{

            //    if (CreateWindow.ShowDialog() == true)
            //    {
            //        var newRe = CreateWindow.Tag as Appointment;
            //        app.Add(newRe);
            //        dbcontext.Appointment.Update(newRe);
            //        dbcontext.SaveChanges();
            //    }

            //    var listRe = dbcontext.Appointment.ToList();
            //    dtgAccepted.ItemsSource = listRe;
            //}
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen ad = new AdminScreen();
            ad.Show();
            Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
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
        private void btn_CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount cA = new CreateAccount();
            cA.Show();
            Close();
        }
    }
}
