using Repositories;
using Repositories.Repos;
using System.Windows;
using System.Windows.Controls;
using Entities;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for UpdateAccount.xaml
    /// </summary>
    public partial class UpdateAccount : Window
    {
        private readonly Guid _id;
        private readonly AccountRepository _accountRepository;
        public UpdateAccount()
        {
            InitializeComponent();
            _accountRepository = new AccountRepository();
        }
        public UpdateAccount(Guid id)
        {
            InitializeComponent();
            _accountRepository = new AccountRepository();
            _id = id;
        }

        private void btn_UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var fullName = txtFullname.Text;
            var dateOfBirth = dprDOB.SelectedDate.Value;
            DateOnly dateOfBirth2 = DateOnly.FromDateTime(dateOfBirth);
            var cbbDis = (ComboBoxItem)cbbDiscriminator.SelectedItem;
            string discriminator = cbbDis.Content.ToString();
            Account curAcc = _accountRepository.GetByCondition(a => a.Id == _id);
            Account updateAcc = _accountRepository.GetByCondition(a=>a.Id==_id);
            if (updateAcc != null)
            {
                updateAcc.FullName = fullName;
                updateAcc.DateOfBirth = dateOfBirth2;
                updateAcc.Discriminator = discriminator;
                _accountRepository.Update(curAcc,updateAcc);
                MessageBox.Show("Update succesfully");                
            }
            ShowDoctorList showDL= new ShowDoctorList();
            showDL.Show();
            Close();
        }
    }
}
