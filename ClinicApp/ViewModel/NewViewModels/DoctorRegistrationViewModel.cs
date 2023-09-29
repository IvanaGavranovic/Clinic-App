using ClinicApp.Core;
using ClinicApp.Model;
using ClinicApp.View.All;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class DoctorRegistrationViewModel : ValidationBase
    {
        #region Fields and properties
        private bool isGeneralPracticioner = false;
        private string specialization;
        private List<string> clinics = new List<string>();
        private string selectedType1;
        private List<string> departments = new List<string>();
        private string selectedType2;
        private ObservableCollection<Doktor> doktori = new ObservableCollection<Doktor>();
        public static Doktor Doctor { get; set; }
        public bool IsGeneralPracticioner
        {
            get { return isGeneralPracticioner; }
            set
            {
                if (isGeneralPracticioner != value)
                {
                    isGeneralPracticioner = value;
                    OnPropertyChanged("IsGeneralPracticioner");
                }
            }
        }
        public string Specialization
        {
            get { return specialization; }
            set
            {
                if (specialization != value)
                {
                    specialization = value;
                    OnPropertyChanged("Specialization");
                }
            }
        }
        public List<string> Clinics
        {
            get { return clinics; }
            set
            {
                if (clinics != value)
                {
                    clinics = value;
                    OnPropertyChanged("Clinics");
                }
            }
        }
        public string SelectedType1
        {
            get { return selectedType1; }
            set
            {
                if (selectedType1 != value)
                {
                    selectedType1 = value;
                    OnPropertyChanged("SelectedType1");
                }
            }
        }
        public List<string> Departments
        {
            get { return departments; }
            set
            {
                if (departments != value)
                {
                    departments = value;
                    OnPropertyChanged("Departments");
                }
            }
        }
        public string SelectedType2
        {
            get { return selectedType2; }
            set
            {
                if (selectedType2 != value)
                {
                    selectedType2 = value;
                    OnPropertyChanged("SelectedType2");
                }
            }
        }
        public ObservableCollection<Doktor> Doktori
        {
            get { return doktori; }
            set
            {
                if (doktori != value)
                {
                    doktori = value;
                    OnPropertyChanged("Doktori");
                }
            }
        }
        #endregion

        #region Validation
        protected override void ValidateSelf()
        {
        }
        #endregion

        #region Constructor and metods
        public MyICommand RegisterCommand { get; set; }

        public DoctorRegistrationViewModel()
        {
            RegisterCommand = new MyICommand(OnRegister);

            Clinics = DbContextHandler.Instance.GetAllClinicsList();
            Departments = DbContextHandler.Instance.GetAllDepartmentsList();
        }
        public void OnRegister()
        {
            this.Validate();

            if (this.IsValid)
            {
                int clinicId = DbContextHandler.Instance.GetClinicIdByName(this.selectedType1);
                int departmentId = DbContextHandler.Instance.GetDeparmentIdByName(this.selectedType2);
                if (IsGeneralPracticioner)
                {
                    Specialization = "opsta praksa";
                }
                else
                    Specialization = "specijalista";

                if (isGeneralPracticioner)
                {
                    Doctor.Departmen = new Departman()
                    {
                        Klinika = new Klinika()
                    };
                   
                    Doctor.Departmen.Klinika.Id = clinicId;
                    Doctor.Departmen.Id = departmentId;
                    Doctor.Specijalizacija = Specialization;
                    DbContextHandler.Instance.Registration(Doctor);
                    MessageBox.Show("Registrovali ste se!");
                    MainWindowViewModel.ChangeViewCommand.Execute(ViewType.LOGIN_VIEW);
                }
                else
                {
                    Doctor.Departmen = new Departman()
                    {
                        Klinika = new Klinika()
                    };
                    Doctor.Departmen.Klinika.Id = clinicId;
                    Doctor.Departmen.Id = departmentId;
                    Doctor.Specijalizacija = Specialization;
                    DbContextHandler.Instance.Registration(Doctor);
                    MessageBox.Show("Registrovali ste se!");
                    MainWindowViewModel.ChangeViewCommand.Execute(ViewType.LOGIN_VIEW);
                }
            }
        }

        #endregion

    }
}
