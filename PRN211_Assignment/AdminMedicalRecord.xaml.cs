using Entities;
using Repositories;
using Repositories.Interfaces;
using Repositories.Repos;
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
    /// Interaction logic for AdminMedicalRecord.xaml
    /// </summary>
    public partial class AdminMedicalRecord : Window
    {
        private readonly IMedicalRecordRepository medicalRecordRepository;
        private List<MedicalRecord>? _list;
        public List<MedicalRecord> List
        {
            get => _list;
            set
            {
                _list = value;
            }
        }
        public AdminMedicalRecord()
        {
            medicalRecordRepository = new MedicalRecordRepository();
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            List = medicalRecordRepository.GetAll().ToList();
            DataContext = List;
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

        private void btn_cusRequest_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen adminScreenWindow = new AdminScreen();
            adminScreenWindow.Show();
            Close();
        }

        private void btn_ViewMedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminMedicalRecord adminMedicalRecord = new AdminMedicalRecord();
            adminMedicalRecord.Show();
            Close();
        }

        private void btn_NameSearch(object sender, RoutedEventArgs e)
        {
            List<MedicalRecord> medicalRecords = medicalRecordRepository.GetMedicalRecordsByCustomerName(txtNameSearch.Text).ToList();
            dtg_MedList.ItemsSource = null;
            dtg_MedList.ItemsSource = medicalRecords;
        }
    }
}
