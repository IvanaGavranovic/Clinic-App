using ClinicApp.Core;
using System;
using System.Collections.ObjectModel;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class PatientReferralViewModel : ValidationBase
    {
        #region Fields and properties
        private string terminPregleda;
        private string imeDoktoraOpstePrakse;
        private string opis;

        private ObservableCollection<UputView> uputi = new ObservableCollection<UputView>();
       
        public ObservableCollection<UputView> Uputi
        {
            get { return uputi; }
            set
            {
                if (uputi != value)
                {
                    uputi = value;
                    OnPropertyChanged("Uputi");
                }
            }
        }

        public string TerminPregleda
        {
            get { return terminPregleda; }
            set
            {
                if (terminPregleda != value)
                {
                    terminPregleda = value;
                    OnPropertyChanged("TerminPregleda");
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
        public string ImeDoktoraOpstePrakse
        {
            get { return imeDoktoraOpstePrakse; }
            set
            {
                if (imeDoktoraOpstePrakse != value)
                {
                    imeDoktoraOpstePrakse = value;
                    OnPropertyChanged("ImeDoktoraOpstePrakse");
                }
            }
        }    
        #endregion

        public PatientReferralViewModel()
        {
            DbContextHandler.Instance.GetReferralLoggedPatient(SingletonUser.Instance.UserId).ForEach(uput => Uputi.Add(uput));
        }
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
