using ClinicApp.Core;
using ClinicApp.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using static ClinicApp.ViewModel.LoginViewModel;

namespace ClinicApp.ViewModel
{
    public class RegisterViewModel : ValidationBase
    {
        private int registerStatus = 0;

        #region Fields and properties
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string city;
        private string street;
        private string number;
        private string contact;
        private string email;
        private bool isDoctor = false;

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
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        public string Street
        {
            get { return street; }
            set
            {
                if (street != value)
                {
                    street = value;
                    OnPropertyChanged("Street");
                }
            }
        }
        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        public string Contact
        {
            get { return contact; }
            set
            {
                if (contact != value)
                {
                    contact = value;
                    OnPropertyChanged("Contact");
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public bool IsDoctor
        {
            get { return isDoctor; }
            set
            {
                if (isDoctor != value)
                {
                    isDoctor = value;
                    OnPropertyChanged("IsDoctor");
                }
            }
        }

        #endregion

        #region Validation
        protected override void ValidateSelf()
        {

            // USERNAME
            if (String.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Required field!";
            }
            else if (Regex.IsMatch(this.username.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Username"] = "Can't start with number!";
            }

            using (var dbContext = new ClinicDBEntities())
            {
                var korisnik = dbContext.Korisniks.Where(x => x.Korisnicko_Ime == this.Username).FirstOrDefault();
                if (korisnik != null)
                {
                    this.ValidationErrors["Username"] = "User with this username already exists!";
                }
            }

            // PASSWORD
            if (String.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Required field!";
            }
            else if (this.password.Trim().Length <= 6)
            {
                this.ValidationErrors["Password"] = "Must have more than 6 characters!";
            }

            // FIRST NAME
            if (String.IsNullOrWhiteSpace(this.firstName))
            {
                this.ValidationErrors["FirstName"] = "Popunite ovo polje!";
            }
            else if (Regex.IsMatch(this.firstName.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["FirstName"] = "Can't start with number!";
            }

            // LAST NAME
            if (String.IsNullOrWhiteSpace(this.lastName))
            {
                this.ValidationErrors["LastName"] = "Required field!";
            }
            else if (Regex.IsMatch(this.firstName.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["LastName"] = "Can't start with number!";
            }

            // EMAIL
            if (String.IsNullOrWhiteSpace(this.email))
            {
                this.ValidationErrors["Email"] = "Required field!";
            }
            else if (!(new EmailAddressAttribute().IsValid(this.email)))
            {
                this.ValidationErrors["Email"] = "Invalid format for email address.";
            }

            // CITY
            if (String.IsNullOrWhiteSpace(this.city))
            {
                this.ValidationErrors["City"] = "Required field!";
            }
            else if (Regex.IsMatch(this.city.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["City"] = "Can't start with number!";
            }

            // STREET
            if (String.IsNullOrWhiteSpace(this.street))
            {
                this.ValidationErrors["Street"] = "Required field!";
            }
            else if (Regex.IsMatch(this.street.Substring(0, 1), "[0-9]"))
            {
                this.ValidationErrors["Street"] = "Can't start with number!";
            }

            // NUMBER
            if (String.IsNullOrWhiteSpace(this.number))
            {
                this.ValidationErrors["Number"] = "Required field!";
            }
            else if (Regex.IsMatch(this.number.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["Number"] = "Must start with number!";
            }

            // CONTACT
            if (String.IsNullOrWhiteSpace(this.contact))
            {
                this.ValidationErrors["Contact"] = "Required field!";
            }
            else if (Regex.IsMatch(this.contact.Substring(0, 1), "[^0-9]"))
            {
                this.ValidationErrors["Contact"] = "Must include only numbers.";
            }
        }
        #endregion Validation

        #region Constructor and metods
        public MyICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new MyICommand(OnRegister);
        }
        public void OnRegister()
        {
            this.Validate();

            if (this.IsValid)
            {
                if (isDoctor)
                {
                    Doktor doktor = new Doktor(firstName, lastName, username, password, UserType.DOCTOR.ToString(), contact, email, street, city, number, null);
                    DoctorRegistrationViewModel.Doctor = doktor;
                    MainWindowViewModel.ChangeViewCommand.Execute(ViewType.DOCTOR_VIEW);
                }
                else
                {
                    Pacijent pacijent = new Pacijent(firstName, lastName, contact,street,number,city,email,username,password,  UserType.PATIENT.ToString());
                    DbContextHandler.Instance.Registration(pacijent,false);
                    MessageBox.Show("Registrovali ste se!");
                    MainWindowViewModel.ChangeViewCommand.Execute(ViewType.LOGIN_VIEW);
                }
            }
        }
        #endregion
    }
}
