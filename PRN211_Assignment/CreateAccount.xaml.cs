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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private Account _account = new Account();
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var user=txtUser.Text;
            var fullName=txtFullname.Text;
            var email=txtEmail.Text;
            var password=passWordbox.Password;
            var dateOfBirth= dprDOB.SelectedDate;
            if (dateOfBirth.HasValue)
            {
                string formatted = dateOfBirth.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            var discriminator= cbbDiscriminator.SelectedIndex;
            var gender=cbbGender.SelectedIndex;
            var department=cbbDepartment.SelectedIndex;
            if(string.IsNullOrEmpty(user) 
                && string.IsNullOrEmpty(fullName)
                && string.IsNullOrEmpty(email)
                && string.IsNullOrEmpty(password)
                && cbbDiscriminator.Items.Count==0
                && cbbDepartment.Items.Count == 0)
            {
                MessageBox.Show("Doctor's name cannot be empty.");
                return;
            }
            else
            {
                //var newAcc = new Account(
                //    {
                //    UserName = user,
                //    FullName = fullName,
                //    Email = email,
                //    Password = password,
                //    DateOfBirth=dateOfBirth.Value,
                //    Discriminator= discriminator,
                    
                //});
            }
            ShowDoctorList sd= new ShowDoctorList();
            sd.Show();
            sd.Close();
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
