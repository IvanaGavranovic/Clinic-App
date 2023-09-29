using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel.NewViewModels
{
    public class ListReviewViewModel : ValidationBase
    {
        #region Fields and properties
        private string terminPregleda;
        private string imePacijenta;
        private string obavljen;

        private ObservableCollection<PregledView> pregledi = new ObservableCollection<PregledView>();
        private int currentIndex;
        private PregledView selectedItem;

        public ObservableCollection<PregledView> Pregledi
        {
            get { return pregledi; }
            set
            {
                if (pregledi != value)
                {
                    pregledi = value;
                    OnPropertyChanged("Pregledi");
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

        public PregledView SelectedItem
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
        public ListReviewViewModel()
        {
            IshodCommand = new MyICommand(OnReviewView);
            //tabela
            // lista svih zakazanig pregleda ulogovanog doktora
            DbContextHandler.Instance.GetReviewsLoggedInDoctor(SingletonUser.Instance.UserId).ForEach(pregled => Pregledi.Add(pregled));
        }
        public void OnReviewView()
        {
            ReviewViewModel.SelectedPregled = SelectedItem;
           
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.REVIEW_VIEW);
        }
        protected override void ValidateSelf()
        {
            throw new NotImplementedException();
        }
    }
}
