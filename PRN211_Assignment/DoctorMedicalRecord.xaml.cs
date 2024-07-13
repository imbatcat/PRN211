using Entities;
using Repositories;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for DoctorMedicalRecord.xaml
    /// </summary>
    public partial class DoctorMedicalRecord : Window
    {
        private readonly IMedicalRecordRepository medicalRecordRepository;
        public Guid DoctorId;
        private List<MedicalRecord>? _list;
        public List<MedicalRecord> List
        {
            get => _list;
            set
            {
                _list = value;
            }
        }

        public DoctorMedicalRecord(Guid doctorId)
        {
            DoctorId = doctorId;
            medicalRecordRepository = new MedicalRecordRepository();
            InitializeComponent();
            btnDelMed.IsEnabled = false;
            btnUpdateMed.IsEnabled = false;
            LoadData();
        }

        public void LoadData()
        {
            List = medicalRecordRepository.GetAllMedicalRecordsByDocId(DoctorId).ToList();
            DataContext = List;
        }
        public void RefreshDatagrid() //refresh the datagrid to display new appointment list after finish a medial record
        {
            List = medicalRecordRepository.GetAllMedicalRecordsByDocId(DoctorId).ToList();
            DataContext = null;
            DataContext = List;
            btnUpdateMed.IsEnabled = false;
            btnDelMed.IsEnabled = false;
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dtg_MedList.SelectedItem is MedicalRecord medicalRecord)
            {
                txtMedId.Text = medicalRecord.MedId.ToString();
                txtDiagnosis.Text = medicalRecord.Diagnosis.ToString();
                txtName.Text = medicalRecord.CustomerName.ToString();
                txtNote.Text = medicalRecord.Note.ToString();
                txtSymptoms.Text = medicalRecord.Symptoms.ToString();
                btnUpdateMed.IsEnabled = true;
                btnDelMed.IsEnabled = true;
            }

        }
        private void btnUpdateMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string diagnosis = txtDiagnosis.Text.Trim();
                string symptoms = txtSymptoms.Text.Trim();
                string note = txtNote.Text.Trim();
                string customerName = txtName.Text.Trim();
                if (diagnosis.Length > 0 && symptoms.Length > 0 && customerName.Length>0)
                {
                    MedicalRecord? toUpdateMed = medicalRecordRepository.GetByCondition(m => m.MedId.Equals(Guid.Parse(txtMedId.Text)));
                    if(toUpdateMed != null)
                    {
                        toUpdateMed.Symptoms = symptoms;
                        toUpdateMed.Diagnosis = diagnosis;
                        toUpdateMed.Note = note;
                        toUpdateMed.CustomerName = customerName;
                        medicalRecordRepository.Save();
                        ResetData();
                        DoctorMedicalRecord doctorMedicalRecordScreen = new DoctorMedicalRecord(DoctorId);
                        doctorMedicalRecordScreen.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Can't find that medical record", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void btnDeleteMed_Click(object sender, RoutedEventArgs e)
        {
            MedicalRecord medicalRecord = medicalRecordRepository.GetByCondition(m => m.MedId.Equals(Guid.Parse(txtMedId.Text)));
            medicalRecordRepository.Delete(medicalRecord);
            RefreshDatagrid();
            ResetData();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            DoctorScreen doctorScreen = new DoctorScreen(DoctorId);
            doctorScreen.Show();
            Close();
        }
        public void ResetData()
        {
            txtDiagnosis.Clear();
            txtSymptoms.Clear();
            txtNote.Clear();
            txtName.Clear();
            txtMedId.Clear();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            HospitalAppDbContext con = new HospitalAppDbContext();
            dtg_MedList.ItemsSource = null;
            dtg_MedList.ItemsSource = con.MedicalRecords.Where(x => x.CustomerName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
        }
    }
}
