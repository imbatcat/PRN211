using Entities;
using Repositories.Repos;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace PRN211_Assignment
{
    /// <summary>
    /// Interaction logic for DoctorScreen.xaml
    /// </summary>
    public partial class DoctorScreen : Window, INotifyPropertyChanged
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly MedicalRecordRepository _medicalRecord;
        public Guid DoctorId;
        private List<Appointment>? _list;
        public List<Appointment> List
        {
            get => _list;
            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }



        public DoctorScreen(Guid doctorId)
        {
            InitializeComponent();
            DoctorId = doctorId;
            _appointmentRepository = new AppointmentRepository();
            _medicalRecord = new MedicalRecordRepository();
            btnSaveMed.IsEnabled = false;
            LoadData();

        }

        public void LoadData()
        {
            List = _appointmentRepository.getAllDoctorAppointments(DoctorId).ToList();
            DataContext = List;
        }
        public void RefreshDatagrid() //refresh the datagrid to display new appointment list after finish a medial record
        {
            List = _appointmentRepository.getAllDoctorAppointments(DoctorId).ToList();
            DataContext = null;
            DataContext = List;
            btnSaveMed.IsEnabled = false;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtg_appList.SelectedItem is Appointment selectedAppointment)
            {
                ResetData();
                txtCusName.Text = selectedAppointment.CustomerName;
                txtAppointmentId.Text = selectedAppointment.Id.ToString();
                btnSaveMed.IsEnabled = true;
            }
        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnSaveMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string diagnosis = txtDiagnosis.Text.Trim();
                string symptoms = txtSymptom.Text.Trim();
                string note = txtNote.Text.Trim();
                if (diagnosis.Length > 0 && symptoms.Length > 0)
                {
                    MedicalRecord medicalRecord = new MedicalRecord
                    {
                        MedId = Guid.NewGuid(),
                        appointmentId = Guid.Parse(txtAppointmentId.Text),
                        CustomerName = txtCusName.Text,
                        Diagnosis = diagnosis,
                        Symptoms = symptoms,
                        Note = note

                    };
                    if (_appointmentRepository.UpdateCheckinStatus(txtAppointmentId.Text))
                    {
                        _medicalRecord.Add(medicalRecord);
                        ResetData();
                        RefreshDatagrid();
                        MessageBox.Show("Save successfully", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Save failed", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all the field", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ResetData()
        {
            txtAppointmentId.Clear();
            txtSymptom.Clear();
            txtNote.Clear();
            txtDiagnosis.Clear();
            txtCusName.Clear();
        }

        private void btn_MedicalRecordList_Click(object sender, RoutedEventArgs e)
        {
            DoctorMedicalRecord doctorMedicalRecordWindow = new DoctorMedicalRecord(DoctorId);
            doctorMedicalRecordWindow.Show();
            Close();
        }
    }
}
