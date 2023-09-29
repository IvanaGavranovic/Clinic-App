using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class ReferralViewModel : ValidationBase
    {
        #region Fields and properties

        
        private List<string> listaDoktora = new List<string>();
        private string selectedType1;
        private List<string> listaTermina = new List<string>();
        private string selectedType2;
        private List<Termin_Specijaliste> TerminsForSelectedDoctors;
        private string pacijent;

        public List<string> ListaTermina
        {
            get { return listaTermina; }
            set
            {
                if (listaTermina != value)
                {
                    listaTermina = value;
                    OnPropertyChanged("ListaTermina");
                }
            }
        }
        public List<string> ListaDoktora
        {
            get { return listaDoktora; }
            set
            {
                if (listaDoktora != value)
                {
                    listaDoktora = value;
                    OnPropertyChanged("ListaDoktora");
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
                    GetTerminsBydoctorName(value);
                }
            }
        }
        private void GetTerminsBydoctorName(string name)
        {
            if (string.IsNullOrEmpty(name)) return;
            int doctorId = DbContextHandler.Instance.GetDoctorIdByName(this.selectedType1);
            TerminsForSelectedDoctors = DbContextHandler.Instance.GetTerminsDoctorSpecijalist(doctorId);
            ListaTermina = TerminsForSelectedDoctors.Select(x => x.Datum + " " + x.Vreme).ToList();
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

        public string Pacijent
        {
            get { return pacijent; }
            set
            {
                if (pacijent != value)
                {
                    pacijent = value;
                    OnPropertyChanged("Pacijent");
                }
            }
        }
        #endregion

        #region Validation
        protected override void ValidateSelf()
        {
            // throw new NotImplementedException();
        }
        #endregion 
        private Korisnik selectedPacijent;
        public MyICommand RegisterCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        public ReferralViewModel()
        {
            RegisterCommand = new MyICommand(OnRegister);
            ListaDoktora = DbContextHandler.Instance.GetDoctorsWithSpecialization().Select(x=>x.Ime).ToList();
            if (ReviewViewModel.SelectedPregled != null)
            {
                selectedPacijent = DbContextHandler.Instance.GetPatientByPregledId(ReviewViewModel.SelectedPregled.Id);
                Pacijent = ReviewViewModel.SelectedPregled.ImePacijenta;
            }
            BackCommand = new MyICommand(OnBack);
        }
        public void OnRegister()
        {
            this.Validate();
            if (this.IsValid)
            {
                var Doktor = DbContextHandler.Instance.GetDoctorsWithSpecialization().Where(x => x.Ime == this.selectedType1).FirstOrDefault();
                var selectedTermin = TerminsForSelectedDoctors.Where(x => x.Datum.Equals(selectedType2.Split(' ')[0]) && x.Vreme.Equals(selectedType2.Split(' ')[1])).FirstOrDefault();

                DbContextHandler.Instance.CreatePregledSpecijaliste(Doktor.Id,
                   SingletonUser.Instance.UserId, selectedPacijent.Id,selectedTermin.Id);

                MessageBox.Show("Zakazali ste pregled kod doktora specijaliste!");

                SelectedType1 = null;
                SelectedType2 = null;
                Pacijent = " ";
            }
        }
        public void OnBack()
        {
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.GENERAL_PRACTICIONER_VIEW);
        }
    }
}
