using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Repositories.Repos;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for ShowDoctorList.xaml
    /// </summary>
    public partial class ShowDoctorList : System.Windows.Window
    {
        private readonly IAccountRepository _accountRepository = new AccountRepository();
        public ShowDoctorList()
        {
            InitializeComponent();
            dtgDocList.ItemsSource = _accountRepository.GetAllDoctors();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen ad = new AdminScreen();
            ad.Show();
            Close();
        }

        private void btnShowAppointment_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment ad = new AcceptedAppointment();
            ad.Show();
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //delete doctor

            //using (var dbcontext = new db())
            //{
            //    Button button = sender as Button;
            //    Doctor selected = button.CommandParameter as Doctor;
            //    staffs.Remove(selected);
            //    dbcontext.Doctor.Remove(selected);
            //    dbcontext.SaveChanges();
            //    var listUser = dbcontext.Doctor.ToList();
            //    dgDocList.ItemsSource = listUser;
            //}
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btn_acceptedApp_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointmentWindow = new AcceptedAppointment();
            acceptedAppointmentWindow.Show();
            Close();
        }

        private void btn_showDocList_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccountWindow = new CreateAccount();
            createAccountWindow.Show();
            Close();
        }

        private void btn_cusRequest_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen adminScreenWindow = new AdminScreen();
            adminScreenWindow.Show();
            Close();
        }
    }
}
