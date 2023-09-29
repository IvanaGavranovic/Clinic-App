using ClinicApp.Core;
using ClinicApp.Model;
using ClinicApp.View.All;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ClinicApp.ViewModel
{
    public class LoginViewModel : ValidationBase
    {

        #region Fields and properties
        private string username;
        private string password;

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public void ExecutePasswordChangedCommand(PasswordBox obj)
        {
            if (obj != null)
                Password = obj.Password;
        }
        #endregion Fields and properties

        #region Validation
        protected override void ValidateSelf()
        {
            if (String.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Required field!";
            }
            else if (Regex.IsMatch(this.username.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Username"] = "Can't start with number!";
            }

            if (String.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Required field!";
            }
            else if (this.password.Trim().Length <= 6)
            {
                this.ValidationErrors["Password"] = "Must have more than 6 characters!";
            }

            using (var dbContext = new ClinicDBEntities())
            {
                var user = dbContext.Korisniks.Where(x => x.Korisnicko_Ime == this.Username && x.Lozinka == this.Password).FirstOrDefault();
                if (user == null)
                {
                    this.ValidationErrors["Password"] = "Wrong Username or Password!";
                }
            }
        }
        #endregion Validation

        public MyICommand LogInCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LogInCommand = new MyICommand(OnLogIn);
            RegisterCommand = new MyICommand(OnRegister);
            CreateTermins();
            CreateSpecialistTermins();
        }

        public void OnLogIn()
        {
            // validacija popunjenih polja
            Password = LoginView.Password;
            this.Validate();

            if (this.IsValid)
            {
                //string hashPassword = SecurityHandler.CreateHash(Password);
                using (var dbContext = new ClinicDBEntities())
                {
                    var user = dbContext.Korisniks.Where(korisnik => korisnik.Korisnicko_Ime == username && korisnik.Lozinka == password).FirstOrDefault();


                    if (user is Doktor)
                    {
                        var doktor = user as Doktor;
                        if (doktor.Specijalizacija == "specijalista")
                        {
                            DbContextHandler.Instance.Logging(Username, password);
                            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.DOCTOR_SPECIALIST_VIEW);
                        }
                        else
                        {
                            DbContextHandler.Instance.Logging(Username, password);
                            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.GENERAL_PRACTICIONER_VIEW);

                        }

                    }
                    else if (user is Pacijent)
                    {
                        DbContextHandler.Instance.Logging(Username, password);
                        MainWindowViewModel.ChangeViewCommand.Execute(ViewType.PATIENT_VIEW);
                    }
                }
            }
        }

        public void OnRegister()
        {
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.REGISTER_VIEW);
        }

        public void CreateTermins()
        {
            var datum = DateTime.Now;
            var vremena = new List<string>() { "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00" };
            for (int i = 0; i < 10; i++)
            {
                foreach (var item in vremena)
                {

                    var noviDatum = datum.ToString("dd/MM/yyyy");
                    var novoVreme = item;

                    using (var dbContext = new ClinicDBEntities())
                    {
                        var terminUBazi = dbContext.Termins.Where(x => x.Datum == noviDatum && x.Vreme == novoVreme).FirstOrDefault();
                        if (terminUBazi != null)
                        {
                            continue;
                        }                    
                    }
                    DbContextHandler.Instance.CreateTermin(noviDatum, novoVreme);
                }
                datum = datum.AddDays(1);
            }
        }
        public void CreateSpecialistTermins()
        {
            var datum = DateTime.Now;
            var vremena = new List<string>() { "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00" };
            for (int i = 0; i < 10; i++)
            {
                foreach (var item in vremena)
                {

                    var noviDatum = datum.ToString("dd/MM/yyyy");
                    var novoVreme = item;

                    using (var dbContext = new ClinicDBEntities())
                    {
                        var terminSpecijalisteUBazi = dbContext.Termin_Specijaliste.Where(x => x.Datum == noviDatum && x.Vreme == novoVreme).FirstOrDefault();
                        if (terminSpecijalisteUBazi != null)
                        {
                            continue;
                        }
                        if (terminSpecijalisteUBazi != null)
                        {
                            continue;
                        }
                    }
                    DbContextHandler.Instance.CreateTerminSpecialiste(noviDatum, novoVreme);
                }
                datum = datum.AddDays(1);
            }
        }
    }
}
