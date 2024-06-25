using Core.Accounts;
using Entities;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for ShowDoctorList.xaml
    /// </summary>
    public partial class ShowDoctorList : System.Windows.Window
    {
        private readonly HospitalAppDbContext _context;
        public ShowDoctorList()
        {
            InitializeComponent();
            btnUpdate.IsEnabled = false;
            _context = new HospitalAppDbContext();
            LoadData();
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
            if (dtgDocList.SelectedItem is AccountDTO)
            {
                AccountDTO selectedAcc = (AccountDTO)dtgDocList.SelectedItem;
                UpdateAccount UdA = new UpdateAccount(selectedAcc.Id);
                UdA.Show();
            }
            btnUpdate.IsEnabled = false;
            Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnUpdate.IsEnabled = true;
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
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is AccountDTO accountDTO)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure wanting to delete this item ?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Account acc = _context.Accounts.FirstOrDefault(a => a.Id == accountDTO.Id);
                    if (acc != null)
                    {
                        _context.Accounts.Remove(acc);
                        _context.SaveChanges();
                        refreshData();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Delete fail", "Notification");
                    }
                }
            }
        }
        public void LoadData()
        {
            List<Account> accounts = _context.Accounts.ToList();
            List<AccountDTO> accountDTOs = new List<AccountDTO>();
            foreach (Account account in accounts)
            {
                if (account.Discriminator == "Doctor")
                {
                    AccountDTO newAcc = new AccountDTO
                    {
                        Id = account.Id,
                        UserName = account.UserName,
                        FullName = account.FullName,
                        DateOfBirth = account.DateOfBirth,
                        Discriminator = account.Discriminator,
                        Email = account.Email,
                    };
                    accountDTOs.Add(newAcc);
                }
            }
            dtgDocList.ItemsSource = accountDTOs;
        }
        public void refreshData()
        {
            dtgDocList.ItemsSource = null;
        }

        private void btn_ViewMedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            AdminMedicalRecord adminMedicalRecord = new AdminMedicalRecord();
            adminMedicalRecord.Show();
            Close();
        }
    }
}
