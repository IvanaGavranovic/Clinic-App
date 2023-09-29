using ClinicApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class SpecialistListReviewViewModel : ValidationBase
    {
        #region Fields and properties

        private string imeDoktoraOpstePrakse;
        private string terminPregleda;
        private string imePacijenta;
        private string obavljen;

        private ObservableCollection<UputView> uputi = new ObservableCollection<UputView>();

        private int currentIndex;
        private UputView selectedItem;

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

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                if (currentIndex != value)
                {
                    currentIndex = value;
                    OnPropertyChanged("CurrentIndex");
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
        public string Obavljen
        {
            get { return obavljen; }
            set
            {
                if (obavljen != value)
                {
                    obavljen = value;
                    OnPropertyChanged("Obavljen");
                }
            }
        }
        public string ImePacijenta
        {
            get { return imePacijenta; }
            set
            {
                if (imePacijenta != value)
                {
                    imePacijenta = value;
                    OnPropertyChanged("ImePacijenta");
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
        public UputView SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
        #endregion
        public MyICommand IshodCommand { get; set; }
        public SpecialistListReviewViewModel()
        {
            IshodCommand = new MyICommand(OnReviewView);
            //tabela
            // lista svih zakazanig pregleda ulogovanog doktora
            DbContextHandler.Instance.GetReviewsLoggedInDoctorSpecialist(SingletonUser.Instance.UserId).ForEach(uput => Uputi.Add(uput));
        }
        public void OnReviewView()
        {
           // ReviewViewModel.SelectedUput = SelectedItem;
           

            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.REVIEW_VIEW);
        }
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
