using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.ObjectModel;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class PatientTherapyViewModel : ValidationBase
    {
        #region Fields and properties
        private string naziv;
        private string vrsta_Terapije;
        private string opis;

        private ObservableCollection<Terapija> terapije = new ObservableCollection<Terapija>();

        public ObservableCollection<Terapija> Terapije
        {
            get { return terapije; }
            set
            {
                if (terapije != value)
                {
                    terapije = value;
                    OnPropertyChanged("Terapije");
                }
            }
        }

        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
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
        public string Vrsta_Terapije
        {
            get { return vrsta_Terapije; }
            set
            {
                if (vrsta_Terapije != value)
                {
                    vrsta_Terapije = value;
                    OnPropertyChanged("Vrsta_Terapije");
                }
            }
        }
        #endregion

        public PatientTherapyViewModel()
        {
            DbContextHandler.Instance.GetTherapyListLoggedPatient(SingletonUser.Instance.UserId).ForEach(terapija => Terapije.Add(terapija));
        }
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
