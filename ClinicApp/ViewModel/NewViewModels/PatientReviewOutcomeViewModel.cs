using ClinicApp.Core;
using System;
using System.Collections.ObjectModel;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class PatientReviewOutcomeViewModel : ValidationBase
    {
        #region Fields and properties
        private string terminPregleda;
        private string imeDoktora;
        private string opis;
        private string dijagnoza;

        private ObservableCollection<IshodView> ishodiPregleda = new ObservableCollection<IshodView>();

        public ObservableCollection<IshodView> IshodiPregleda
        {
            get { return ishodiPregleda; }
            set
            {
                if (ishodiPregleda != value)
                {
                    ishodiPregleda = value;
                    OnPropertyChanged("IshodiPregleda");
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
        public string ImeDoktora
        {
            get { return imeDoktora; }
            set
            {
                if (imeDoktora != value)
                {
                    imeDoktora = value;
                    OnPropertyChanged("ImeDoktora");
                }
            }
        }
        public string Dijagnoza
        {
            get { return dijagnoza; }
            set
            {
                if (dijagnoza != value)
                {
                    dijagnoza = value;
                    OnPropertyChanged("Dijagnoza");
                }
            }
        }
        #endregion

        public PatientReviewOutcomeViewModel()
        {
            DbContextHandler.Instance.GetReviewOutcomeLoggedPatient(SingletonUser.Instance.UserId).ForEach(ishod => IshodiPregleda.Add(ishod));
        }
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
