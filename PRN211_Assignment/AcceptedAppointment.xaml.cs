using Repositories.Interfaces;
using Repositories.Repos;
using System.ComponentModel;
using System.Windows;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for AcceptedAppointment.xaml
    /// </summary>
    public partial class AcceptedAppointment : Window, INotifyPropertyChanged
    {
        private readonly IAppointmentRepository _appointmentRepository = new AppointmentRepository();
        public AcceptedAppointment()
        {
            InitializeComponent();
            dtgAccepted.ItemsSource = _appointmentRepository.GetAll();
            //load datagrid
            //using (var dbcontext = new db())
            //{
            //    var listRequest = dbcontext.Appointment.ToList();
            //    dtgCusRequest.ItemsSource = listRequest;
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UpdateAppointment CreateWindow = new UpdateAppointment();
            //using (var dbcontext = new db())
            //{

            //    if (CreateWindow.ShowDialog() == true)
            //    {
            //        var newRe = CreateWindow.Tag as Appointment;
            //        app.Add(newRe);
            //        dbcontext.Appointment.Update(newRe);
            //        dbcontext.SaveChanges();
            //    }

            //    var listRe = dbcontext.Appointment.ToList();
            //    dtgAccepted.ItemsSource = listRe;
            //}
        }

        private void btnBackPage_Click(object sender, RoutedEventArgs e)
        {
            AdminScreen ad = new AdminScreen();
            ad.Show();
            Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btn_acceptedApp_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
