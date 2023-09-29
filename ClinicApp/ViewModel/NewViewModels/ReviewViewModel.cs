using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class ReviewViewModel : ValidationBase
    {
        #region Fields and properties
        public static PregledView SelectedPregled;

        // kad  napravim novi view : public static UputView Selected uput;

        private string pacijent;
        private string datum;
        private string opis;
        private string izvestaj;
        private string doktor;
        private bool isUput = false;

        public static int StaticDijagnozaId { get; set; }
        public static int StaticUputId { get; set; }

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
        
        public string Opis
        {
            get { return opis; }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        public string Izvestaj
        {
            get { return izvestaj; }
            set
            {
                if (izvestaj != value)
                {
                    izvestaj = value;
                    OnPropertyChanged("Izvestaj");
                }
            }
        }
        public string Doktor
        {
            get { return doktor; }
            set
            {
                if (doktor != value)
                {
                    doktor = value;
                    OnPropertyChanged("Doktor");
                }
            }
        }
        public string Datum
        {
            get { return datum; }
            set
            {
                if (datum != value)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }
        public bool IsUput
        {
            get { return isUput; }
            set
            {
                if (isUput != value)
                {
                    isUput = value;
                    OnPropertyChanged("IsUput");
                }
            }
        }
        #endregion

        #region Validation
        protected override void ValidateSelf()
        {          
            // Opis
            if (String.IsNullOrWhiteSpace(this.opis))
            {
                this.ValidationErrors["Opis"] = "Required field!";
            }
            else if (Regex.IsMatch(this.opis.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Opis"] = "Can't start with number!";
            }         
           
        }
        #endregion Validation

        public MyICommand RegisterCommand { get; set; }
        public MyICommand BackCommand { get; set; }
        public ReviewViewModel()
        {
            if(SelectedPregled != null)
            {
                Datum = SelectedPregled.TerminPregleda;
                Pacijent = SelectedPregled.ImePacijenta;
                Doktor = DbContextHandler.Instance.GetDoctorById(SingletonUser.Instance.UserId).Ime;
            }
            RegisterCommand = new MyICommand(OnRegister);
            BackCommand = new MyICommand(OnBack);
        }
        public void OnRegister()
        {
            this.Validate();
            if (this.IsValid)
            {
                if(isUput)
                {
                    StaticUputId = DbContextHandler.Instance.CreateReferral(izvestaj, opis, SelectedPregled.Id);
                    MessageBox.Show("Dodali ste uput!");

                    Datum = null;
                    Pacijent = null;
                    Doktor = null;
                    Izvestaj = " ";
                    Opis = " ";

                    DbContextHandler.Instance.FinishedReview(SelectedPregled.Id);
                    MainWindowViewModel.ChangeViewCommand.Execute(ViewType.REFERRAL_VIEW);
                }
                else
                {
                    StaticDijagnozaId = DbContextHandler.Instance.CreateDiagnosis(izvestaj, opis, SelectedPregled.Id);
                    MessageBox.Show("Dodali ste dijagnozu pregleda!");

                    Datum = null;
                    Pacijent = null;
                    Doktor = null;
                    Izvestaj = " ";
                    Opis = " ";
                    DbContextHandler.Instance.FinishedReview(SelectedPregled.Id);
                    MainWindowViewModel.ChangeViewCommand.Execute(ViewType.THERAPY_VIEW);
                }
            }
        }
       public void OnBack()
        {
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.GENERAL_PRACTICIONER_VIEW);
        }
    }
}
