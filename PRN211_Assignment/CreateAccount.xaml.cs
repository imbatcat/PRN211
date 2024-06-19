using Core;
using Entities;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private readonly IAccountRepository _accountRepository = new AccountRepository();
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var user = txtUser.Text;
            var fullName = txtFullname.Text;
            var email = txtEmail.Text;
            var password = passWordbox.Password;
            var dateOfBirth = dprDOB.SelectedDate.Value;
            DateOnly dateOfBirth2 = DateOnly.FromDateTime(dateOfBirth);
            var cbbDis = (ComboBoxItem)cbbDiscriminator.SelectedItem;
            string discriminator = cbbDis.Content.ToString();
            var cbbGen = (ComboBoxItem)cbbGender.SelectedValue;
            string gender = cbbGen.Content.ToString();
            var cbbDep = (ComboBoxItem)cbbDepartment.SelectedItem;
            string department = cbbDep.Content.ToString();
            if (string.IsNullOrEmpty(user)
                || string.IsNullOrEmpty(fullName)
                || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(password)
                || cbbDiscriminator.Items.Count == 0
                || cbbDepartment.Items.Count == 0)
            {
                MessageBox.Show("Please fill all the required fields");
                return;
            }
            Account newAcc = new Account
            {
                Id = Guid.NewGuid(),
                Appointments = [],
                JoinDate = DateOnly.FromDateTime(DateTime.Now),
                UserName = user,
                FullName = fullName,
                Email = email,
                Password = password,
                DateOfBirth = dateOfBirth2,
                Discriminator = discriminator,
                Department = department,
                IsMale = gender == "Male" ? true : false,
            };
            _accountRepository.Add(newAcc);
            ShowDoctorList sd = new ShowDoctorList();
            sd.Show();
            Close();
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointment = new AcceptedAppointment();
            acceptedAppointment.Show();
            Close();
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btn_acceptedApp_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointmentWindow= new AcceptedAppointment();
            acceptedAppointmentWindow.Show();
            Close();
        }

        private void btn_showDocList_Click(object sender, RoutedEventArgs e)
        {
            ShowDoctorList showDoctorListWindow = new ShowDoctorList();
            showDoctorListWindow.Show();
            Close();
        }

        private void btn_CreateAccount_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_cusRequest_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen adminScreenWindow = new AdminScreen();
            adminScreenWindow.Show();
            Close();
        }
    }
}
