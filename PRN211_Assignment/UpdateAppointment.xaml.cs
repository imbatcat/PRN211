using Entities;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Window
    {

        private Appointment _appointment = new Appointment();

        public UpdateAppointment()
        {
            InitializeComponent();

            //load doctor data for combobox
            //using (var context = new db())
            //{
            //    var objects = context.Appointment.ToList();
            //    cbbDoctorId.ItemsSource = objects;
            //    cbbDoctorId.DisplayMemberPath = "DoctorId";
            //}
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment ad = new AcceptedAppointment();
            ad.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
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
                bool check = false;
                bool cancel = false;
                if (cbbIsCheckedUp.SelectedItem != null)
                {
                    string selectedValue = cbbIsCheckedUp.SelectedItem.ToString();
                    if (selectedValue.Equals("Yes"))
                    {
                        check = true;
                    }
                    else check = false;
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
                _appointment.CustomerName = cus;
                _appointment.Notes = note;
                _appointment.IsCheckedUp = check;
                _appointment.IsCancelled = cancel;

                DialogResult = true;
                this.Tag = _appointment;
                Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
