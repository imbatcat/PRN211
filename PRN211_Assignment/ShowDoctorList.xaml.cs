using Core.Accounts;
using Entities;
using Repositories;
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
        private readonly HospitalAppDbContext _context;
        private readonly AccountRepository accountRepository;
        public ShowDoctorList()
        {
            InitializeComponent();
            _context = new HospitalAppDbContext();
            accountRepository = new AccountRepository();
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
            AcceptedAppointment acceptedAppointmentWindow = new AcceptedAppointment();
            acceptedAppointmentWindow.Show();
            Close();
        }

        private void btn_showDocList_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
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
                        Password = account.Password,
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
        private void btn_SearchByDoctorName(object sender, RoutedEventArgs e)
        {
            List<Account> acc = accountRepository.GetDocByCondition(txtSearchByName.Text).ToList();
            dtgDocList.ItemsSource = null;
            dtgDocList.ItemsSource = acc;
        }
    }
}
