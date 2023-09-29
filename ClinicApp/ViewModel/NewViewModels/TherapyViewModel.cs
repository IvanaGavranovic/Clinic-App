using ClinicApp.Core;
using ClinicApp.Model;
using ClinicApp.ViewModel.NewViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ClinicApp.ViewModel
{
    public class TherapyViewModel : ValidationBase
    {
        #region Fields and properties
        private string naziv;
        private string opis;
        private List<string> vrstaTerapije = new List<string>() { "Lek", "Injekcija", "Infuzija", "Bolničko lečenje", "Operacija" };
        private string selectedType;

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
        public string SelectedType
        {
            get { return selectedType; }
            set
            {
                if (selectedType != value)
                {
                    selectedType = value;
                    OnPropertyChanged("SelectedType");
                }
            }
        }
        public List<string> VrstaTerapije
        {
            get { return vrstaTerapije; }
            set
            {
                if (vrstaTerapije != value)
                {
                    vrstaTerapije = value;
                    OnPropertyChanged("VrstaTerapije");
                }
            }
        }

        #endregion

        #region Validations
        protected override void ValidateSelf()
        {
           
            // Naziv
            if (String.IsNullOrWhiteSpace(this.naziv))
            {
                this.ValidationErrors["Naziv"] = "Required field!";
            }
            else if (Regex.IsMatch(this.naziv.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Naziv"] = "Can't start with number!";
            }
            else if (this.naziv.Length < 3)
            {
                this.ValidationErrors["Naziv"] = "Must have more than 3 characters";
            }
            else if (this.naziv.Length > 200)
            {
                this.ValidationErrors["Naziv"] = "Must be less than 200 characters";
            } 
            // Opis
            if (String.IsNullOrWhiteSpace(this.opis))
            {
                this.ValidationErrors["Opis"] = "Required field!";
            }
            else if (Regex.IsMatch(this.opis.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Opis"] = "Can't start with number!";
            }
            else if (this.opis.Length < 3)
            {
                this.ValidationErrors["Opis"] = "Must have more than 3 characters";
            }
            else if (this.opis.Length > 200)
            {
                this.ValidationErrors["Opis"] = "Must be less than 200 characters";
            }
            // Vrsta terapije
            if (String.IsNullOrWhiteSpace(this.VrstaTerapije.ToString()))
            {
                this.ValidationErrors["VrstaTerapije"] = "Required field!";
            }

        }
        #endregion

        #region Constructor and metods
        public MyICommand AddTherapyCommand { get; set; }
        public MyICommand BackCommand { get; set; }

        public TherapyViewModel()
        {
            AddTherapyCommand = new MyICommand(OnAdd);
            BackCommand = new MyICommand(OnBack);
        }
        public void OnAdd()
        { 
                MessageBox.Show("Propisana je terapija za pacijenta!");
                DbContextHandler.Instance.CreateTherapy(naziv, opis, selectedType, ReviewViewModel.StaticDijagnozaId);

                Naziv = " ";
                Opis = " ";
                SelectedType = null;

        }
        public void OnBack()
        {
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.GENERAL_PRACTICIONER_VIEW);
        }
        #endregion

    }
}
