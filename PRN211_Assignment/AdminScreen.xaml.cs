using Core.Appointments;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        private RequestAppointmentRepository _requestAppointmentRepository = new RequestAppointmentRepository();
        private AppointmentRepository appointmentRepository;
        public List<AppointmentRequest> appointmentRequestList;
        public readonly AccountRepository accountRepository;
        
        public AdminScreen()
        {
            accountRepository = new AccountRepository();
            appointmentRepository = new AppointmentRepository();
            InitializeComponent();
            LoadDepartmentCbb();
            LoadData();
            btnCreateAppointment.IsEnabled = false;
        }
        public void LoadDepartmentCbb()
        {
            List<string> department = new List<string>
            {
                "Obstetrics and gynaecology",
                "Emergency medicine",
                "Cardiology",
                "Surgery",
                "Paediatrics"
            };
            cbbDepartment.ItemsSource = department;
        }

        public void LoadDoctorListCbb(string department)
        {
            List<Account> DoctorAccount = accountRepository.GetDoctorWithDepartment(department).ToList();
            cbbDocID.ItemsSource = null;
            cbbDocID.ItemsSource = DoctorAccount;
            cbbDocID.DisplayMemberPath = "FullName";
            cbbDocID.SelectedValuePath = "Id";
        }
        public void LoadData()
        {
            _requestAppointmentRepository = new RequestAppointmentRepository();
            appointmentRequestList = _requestAppointmentRepository.GetAllAppointmentRequest().ToList();
            dtgCusRequest.ItemsSource = appointmentRequestList;
        }

        public void RefreshDataGrid()
        {
            _requestAppointmentRepository = new RequestAppointmentRepository();
            appointmentRequestList = _requestAppointmentRepository.GetAllAppointmentRequest().ToList();
            dtgCusRequest.ItemsSource = null;
            dtgCusRequest.ItemsSource = appointmentRequestList;
        }

        public void ClearBox()
        {
            txtAppRequestId.Clear();
            txtCusName.Clear();
            txtNote.Clear();
            cbbDepartment.SelectedItem = null;
            cbbDocID.ItemsSource= null;
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

            if(dtgCusRequest.SelectedItem is AppointmentRequest selectedReq)
            {
                ClearBox();
                btnCreateAppointment.IsEnabled = true;
                txtCusName.Text = selectedReq.customerName;
                txtAppRequestId.Text = selectedReq.appRequestId.ToString();
            }
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
            try
            {
                if(txtAppRequestId.Text.IsNullOrEmpty() || txtCusName.Text.IsNullOrEmpty())
                {
                    throw new Exception("Internal error");
                } else if(cbbDepartment.SelectedItem == null || cbbDocID.SelectedItem == null)
                {
                    throw new Exception("Empty field");
                }
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure want to create this appointment","Notification", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if(messageBoxResult == MessageBoxResult.OK)
                {
                    appointmentRepository.CreateAppointment(new Appointment
                    {
                        Id = Guid.NewGuid(),
                        appRequestId = Guid.Parse(txtAppRequestId.Text),
                        AccountId = Guid.Parse(cbbDocID.SelectedValue.ToString()),
                        Notes = txtNote.Text,
                        IsCheckedUp = false,
                        IsCancelled = false,
                        DateCreated = DateTime.Now,
                        CustomerName = txtCusName.Text

                    });
                    MessageBox.Show("Create appointment successfully", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearBox();
                    RefreshDataGrid();
                    btnCreateAppointment.IsEnabled = false; //disable button when don't use
                }

            }catch (Exception ex)
            {
                if(ex.Message == "Empty field")
                {
                    MessageBox.Show("Please fill all the field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                } else if(ex.Message == "Internal error")
                {
                    MessageBox.Show("Internal error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                } else
                {
                    MessageBox.Show("Department can't be null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
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

        private void cbbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(cbbDepartment.SelectedItem != null)
                {
                    LoadDoctorListCbb(cbbDepartment.SelectedItem.ToString());
                }
                
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Continue");
            }
        }

        //private void btnShowDoctorList(object sender, RoutedEventArgs e)
        //{
        //    ShowDoctorList mainWindow = new ShowDoctorList();
        //    mainWindow.Show();
        //    Close();
        //}
    }
}
