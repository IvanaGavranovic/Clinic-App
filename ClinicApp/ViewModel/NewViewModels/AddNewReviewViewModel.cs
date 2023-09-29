using ClinicApp.Core;
using ClinicApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class AddNewReviewViewModel : ValidationBase
    {
        #region Fields and properties
        // lista zakazanih pregleda
        private ObservableCollection<PregledView> pregledi = new ObservableCollection<PregledView>();
        private int doktor_Id;
        private int termins_Id;

        private PregledView selectedItem;
        private int currentIndex;
        private bool isUpdate = false;
        private string btnContent;

        public string DeleteButton { get; set; }

        private List<Termin> TerminsForSelectedDoctors;

        // forma za zakazivanje pregleda
        private List<string> listaDoktora = new List<string>();
        private string selectedType1;
        private List<string> listaTermina = new List<string>();
        private string selectedType2;
        private bool btnEnable;

        public bool BtnEnable
        {
            get
            { return btnEnable; }
            set
            {
                btnEnable = value;
                OnPropertyChanged("BtnEnable");
            }
        }

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
        public PregledView SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != null && selectedItem != value)
                {
                    selectedItem = value;
                    BtnEnable = true;
                    OnPropertyChanged("SelectedItem");
                }
                else if (value != null && selectedItem.Id == value.Id)
                {
                    selectedItem = null;
                    BtnEnable = false;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }
        public int Doktor_Id
        {
            get { return doktor_Id; }
            set
            {
                if (doktor_Id != value)
                {
                    doktor_Id = value;
                    OnPropertyChanged("Doktor_Id");
                }
            }
        }
        public int Termins_Id
        {
            get { return termins_Id; }
            set
            {
                if (termins_Id != value)
                {
                    termins_Id = value;
                    OnPropertyChanged("Termins_Id");
                }
            }
        }

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
            TerminsForSelectedDoctors = DbContextHandler.Instance.GetTermins(doctorId);
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
        public string BtnContent
        {
            get { return btnContent; }
            set
            {
                if (btnContent != value)
                {
                    btnContent = value;
                    OnPropertyChanged("BtnContent");
                }
            }
        }
        #endregion


        #region Constructor and metods
        public MyICommand AddCommand { get; set; }
        public MyICommand ChangeCommand { get; set; }
        public static RelayCommand DeleteCommand { get; set; }

        public AddNewReviewViewModel()
        {
            BtnContent = "Zakažite";
            AddCommand = new MyICommand(OnAdd);
            ChangeCommand = new MyICommand(OnSaveChanges);
            DeleteCommand = new RelayCommand(OnDelete);

            DbContextHandler.Instance.GetAllViews(SingletonUser.Instance.UserId).ForEach(pregled => Pregledi.Add(pregled));
            // forma
            ListaDoktora = DbContextHandler.Instance.GetGeneralPracticioner().Select(x=>x.Ime).ToList();
        }

        public void OnAdd()
        {
            this.Validate();

            if (this.IsValid)
            {
                if (!isUpdate)
                {
                    var Doktor = DbContextHandler.Instance.GetAllDoctors().Where(x => x.Ime == this.selectedType1).FirstOrDefault();
                    var selectedTermin = TerminsForSelectedDoctors.Where(x => x.Datum.Equals(selectedType2.Split(' ')[0]) && x.Vreme.Equals(selectedType2.Split(' ')[1])).FirstOrDefault();
                    var Pacijent = DbContextHandler.Instance.GetPacientById(SingletonUser.Instance.UserId);

                    Pregled newPregled = new Pregled()
                    {
                        Termins = selectedTermin,
                        Ishod_Pregleda = null,
                        Doktor = (Doktor)Doktor,
                        Pacijent = (Pacijent)Pacijent,
                        Opis = " ",
                        Obvljen = "Ne"
                    };
                    DbContextHandler.Instance.CreateReview(newPregled);

                    Pregledi.Clear();
                    DbContextHandler.Instance.GetAllViews(SingletonUser.Instance.UserId).ForEach(pregled => Pregledi.Add(pregled));
                    SelectedType1 = null;
                    SelectedType2 = null;
                }
                else
                {
                    BtnContent = "Izmenite";
           
                   var Doktor = (Doktor)DbContextHandler.Instance.GetAllDoctors().Where(x => x.Ime == this.selectedType1).FirstOrDefault();
                   if(Doktor.Specijalizacija == "Specijalista")
                   {
                        MessageBox.Show("Ne možete menjati pregled specijaliste!");
                        return;
                   }
                    var selectedTermin = TerminsForSelectedDoctors.Where(x => x.Datum.Equals(selectedType2.Split(' ')[0]) && x.Vreme.Equals(selectedType2.Split(' ')[1])).FirstOrDefault();
                    var Pacijent = (Pacijent)DbContextHandler.Instance.GetPacientById(SingletonUser.Instance.UserId);

                    Pregled updatedPregled = DbContextHandler.Instance.GetPregled(selectedItem.Id);
                    updatedPregled.Termins = selectedTermin;
                    updatedPregled.Doktor = Doktor;
                    updatedPregled.Pacijent = Pacijent;

                    DbContextHandler.Instance.UpdateReview(updatedPregled);
                    MessageBox.Show("Izmena pregleda!");

                    Pregledi.Clear();
                    DbContextHandler.Instance.GetAllViews(SingletonUser.Instance.UserId).ForEach(pregled => Pregledi.Add(pregled));
                    isUpdate = false;
                    BtnContent = "Zakažite";
                    SelectedType1 = null;
                    SelectedType2 = null;
                    SelectedItem = null;
                    BtnEnable = false;
                }
            }
        }
        public void OnSaveChanges()
        {
            var tempTermin = DateTime.Parse(selectedItem.TerminPregleda);
            if (tempTermin <= (DateTime.Now.AddDays(+1)))
            {
                MessageBox.Show("Nije moguce izmeniti pregled !");
                return;
            }
            Termins_Id = SelectedItem.IdTermina;
            Doktor_Id = SelectedItem.IdDoktora;
            SelectedType1 = SelectedItem.ImeDoktora;
            listaTermina.Insert(0, SelectedItem.TerminPregleda);
            SelectedType2 = SelectedItem.TerminPregleda;
            isUpdate = true;
            BtnContent = "Izmenite";
        }

        public void OnDelete()
        {

            int pregledId = Pregledi.ElementAt(CurrentIndex).Id;
            var tempTermin = DateTime.Parse(selectedItem.TerminPregleda);
            if (tempTermin <= (DateTime.Now.AddDays(+1)))
            {
                MessageBox.Show("Nije moguce izmeniti pregled !");
                return;
            }
            // DeleteButton.IsEnabled = true;
            DbContextHandler.Instance.DeleteReviewById(pregledId);

            MessageBox.Show("Obrisali ste pregled!");
            Pregledi.RemoveAt(CurrentIndex);
        }
        protected override void ValidateSelf()
        {
            // throw new NotImplementedException();
        }

        #endregion
    }
}
