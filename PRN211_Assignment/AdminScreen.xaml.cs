using Core.Appointments;
using Entities;
using Repositories;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        private readonly RequestAppointmentRepository _requestAppointmentRepository;

        public AcceptedAppointmentList List;
        public AdminScreen()
        {
            InitializeComponent();
            List = new AcceptedAppointmentList();
            _requestAppointmentRepository = new RequestAppointmentRepository();
            dtgCusRequest.ItemsSource = _requestAppointmentRepository.GetAllAppointmentRequest();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnCreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            //var cus = txtCusName.Text;
            //if (string.IsNullOrWhiteSpace(cus))
            //{
            //    MessageBox.Show("Customer's name cannot be empty.");
            //    return;
            //}
            //var note = txtNote.Text;


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
        }

        private void btn_acceptedApp_Click(object sender, RoutedEventArgs e)
        {
            AcceptedAppointment acceptedAppointmentWindow = new AcceptedAppointment();
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
            CreateAccount createAccountWindow = new CreateAccount();
            createAccountWindow.Show();
            Close();
        }

        //private void btnShowDoctorList(object sender, RoutedEventArgs e)
        //{
        //    ShowDoctorList mainWindow = new ShowDoctorList();
        //    mainWindow.Show();
        //    Close();
        //}
    }
}
