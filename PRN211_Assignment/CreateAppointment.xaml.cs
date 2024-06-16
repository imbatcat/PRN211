using Entities;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {

        private Appointment _appointment = new Appointment();

        public CreateAppointment()
        {
            InitializeComponent();

            //đoạn này là lấy cái fullname bên AdminScreen gán vào cái lblCusName luôn


            //cần lấy data cho duy nhất 1 combobox là DoctorId
            //using (var context = new db())
            //{
            //var objects = context.Doctor.ToList();
            //cbbDoctorId.ItemsSource = objects;
            //cbbDoctorId.DisplayMemberPath = "DoctorId";               
            //}
        }


        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (_appointment != null)
            {
                var cus = txtCusName.Text;
                if (string.IsNullOrWhiteSpace(cus))
                {
                    MessageBox.Show("Customer's name cannot be empty.");
                    return;
                }
                var note = txtNotes.Text;
                bool check = false;
                bool cancel = false;
                if (cbbIsCheckedUp.SelectedItem != null)
                {
                    string selectedValue = cbbIsCheckedUp.SelectedItem.ToString();
                    if (selectedValue.Equals("Yes"))
                    {
                        check = true;
                    } else check = false;
                }

                if (cbbIsCancelled.SelectedItem != null)
                {
                    string selectedValue = cbbIsCancelled.SelectedItem.ToString();
                    if (selectedValue.Equals("Yes"))
                    {
                        cancel = true;
                    }
                    else cancel = false;
                }
                _appointment.DateCreated = DateOnly.FromDateTime(DateTime.Now);
                _appointment.CustomerName = cus;
                _appointment.Notes = note;
                _appointment.IsCheckedUp = check;
                _appointment.IsCancelled = cancel;

                DialogResult = true;
                this.Tag = _appointment;
                Close();
            }
        }
    }
}
