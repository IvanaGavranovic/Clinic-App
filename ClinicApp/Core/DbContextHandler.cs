using ClinicApp.Model;
using ClinicApp.ViewModel.NewViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicApp.Core
{
    public class DbContextHandler
    {
        private static DbContextHandler instance;
        public static DbContextHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbContextHandler();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }

        #region Registration

        public bool Registration(Korisnik korisnik, bool jeDoktor = true)
        {
            using (var dbContext = new ClinicDBEntities())
            {
                var user = dbContext.Korisniks.Where(x => x.Korisnicko_Ime == korisnik.Korisnicko_Ime).FirstOrDefault();
                if (user == null)
                {
                    if (jeDoktor)
                    {
                        dbContext.Departmen.Attach(((Doktor)korisnik).Departmen);
                        dbContext.Klinikas.Attach(((Doktor)korisnik).Departmen.Klinika);

                    }
                    dbContext.Korisniks.Add(korisnik);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Korisnik sa ovim korisnickim imenom vec postoji!");
                }
            }
            return true;
        }
        #endregion

        #region Logging in
        public bool Logging(string username, string password)
        {
            using (var dbContext = new ClinicDBEntities())
            {

                foreach (var k in dbContext.Korisniks)
                {
                    if (k.Korisnicko_Ime == username && k.Lozinka == password)
                    {
                        // uspesno se logovao
                        SingletonUser.Instance.UserId = k.Id;
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        public Korisnik GetPacientById(int id)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Korisniks
                        where pacijent.Id == id
                        select pacijent).First();
            }
        }
        public Korisnik GetDoctorById(int id)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doctor in db.Korisniks
                        where doctor.Id == id
                        select doctor).First();
            }
        }

        #region Departman
        public List<string> GetAllDepartmentsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        select departman.Naziv).ToList();
            }
        }

        public int GetDeparmentIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        where departman.Naziv == name
                        select departman.Id).First();
            }
        }
        #endregion
        #region CRUD DOCTOR
        // C-Create
        public void CreateDoctor(string ime, string prezime, string specijalizacija, int klinika_Id, int departman_Id, string kontakt, string korisnickoIme, string lozinka, string email, string ulica, string grad, string broj, string uloga)
        {
            Korisnik doktor = new Doktor(ime, prezime, korisnickoIme, lozinka, uloga, kontakt, email, ulica, grad, broj, specijalizacija);
            using (var db = new ClinicDBEntities())
            {
                db.Korisniks.Add(doktor);
                db.SaveChanges();
            }
        }
        // R-Read
        public List<Korisnik> GetAllDoctors()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Korisniks
                        select doktor).ToList();
            }
        }


        public List<Korisnik> GetGeneralPracticioner()
        {
            using (var db = new ClinicDBEntities())
            {
                var korisnici = (from doktor in db.Korisniks
                                 select doktor).ToList();
                var ret = new List<Korisnik>();
                foreach (var k in korisnici)
                {
                    if (k is Doktor && (k as Doktor).Specijalizacija == "opsta praksa")
                    {
                        ret.Add(k);
                    }
                }
                return ret;
            }
        }

        public List<Korisnik> GetDoctorsWithSpecialization()
        {
            using (var db = new ClinicDBEntities())
            {
                var korisnici = (from doktor in db.Korisniks
                                 select doktor).ToList();
                var ret = new List<Korisnik>();
                foreach (var k in korisnici)
                {
                    if (k is Doktor && (k as Doktor).Specijalizacija == "specijalista")
                    {
                        ret.Add(k);
                    }
                }
                return ret;
            }
        }


        // pronaci sve zakazane termine prijavljenog pacijenta
        public List<PregledView> GetAllViews(int pacijentId)
        {
            using (var db = new ClinicDBEntities())
            {
                var temp = (from pregled in db.Pregleds
                            where pregled.Pacijent.Id == pacijentId
                            select pregled).ToList()
                        .Select(pregled => new PregledView
                        {
                            ImeDoktora = pregled.Doktor.Ime,
                            TerminPregleda = pregled.Termins.Datum + " " + pregled.Termins.Vreme,
                            Obavljen = pregled.Obvljen,
                            Id = pregled.Id,
                            IdTermina = pregled.Termins.Id,
                            IdDoktora = pregled.Doktor.Id
                        });
                return temp.OrderBy(x=>x.IdTermina).ToList();
            }
        }

        //CREATE
        public void CreateTermin(string datum, string vreme)
        {
            Termin termin = new Termin(datum, vreme);
            using (var db = new ClinicDBEntities())
            {
                db.Termins.Add(termin);
                db.SaveChanges();
            }
        }

        public void CreateTerminSpecialiste(string datum, string vreme)
        {
            Termin_Specijaliste termin = new Termin_Specijaliste(datum, vreme);
            using (var db = new ClinicDBEntities())
            {
                db.Termin_Specijaliste.Add(termin);
                db.SaveChanges();
            }
        }

        // READ
        public List<Termin> GetTermins(int doctorId)
        {
            using (var db = new ClinicDBEntities())
            {
                var termins = (from termin in db.Termins
                               where
                               !(from pregled in db.Pregleds
                                 where pregled.Doktor.Id == doctorId
                                 select pregled.Termins.Id).ToList().Contains(termin.Id)
                               select termin).ToList();
                List<Termin> retVal = new List<Termin>();
                foreach (var termin in termins)
                {
                    var tempTermin = DateTime.Parse(termin.Datum);
                    if (tempTermin > DateTime.Now)
                    {
                        retVal.Add(termin);
                    }
                }
                return retVal;
            }
        }
        public List<Termin_Specijaliste> GetTerminsDoctorSpecijalist(int doctorId)
        {
            using (var db = new ClinicDBEntities())
            {
                var termins = (from termin in db.Termin_Specijaliste
                               where
                               !(from pregled in db.Pregleds
                                 where pregled.Doktor.Id == doctorId
                                 select pregled.Termins.Id).ToList().Contains(termin.Id)
                               select termin).ToList();
                List<Termin_Specijaliste> retVal = new List<Termin_Specijaliste>();
                foreach (var termin in termins)
                {
                    var tempTermin = DateTime.Parse(termin.Datum);
                    
                  if (tempTermin > DateTime.Now)
                    {
                        retVal.Add(termin);
                    }
                }
                return retVal;
            }
        }


        // D-Delete
        public void DeleteDoctorById(int doctorId)
        {
            Korisnik doktor;

            using (var db = new ClinicDBEntities())
            {
                doktor = db.Korisniks.Where(x => x.Id == doctorId).FirstOrDefault();
                db.Entry(doktor).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion

        #region CRUD PATIENT
        // C = CREATE
        public void CreatePatient(string ime, string prezime, string kontakt, string ulica, string broj, string grad, string email, string korisnickoIme, string lozinka)
        {
            Korisnik pacijent = new Korisnik(ime, prezime, kontakt, ulica, broj, grad, email, korisnickoIme, lozinka, UserType.PATIENT.ToString());
            using (var db = new ClinicDBEntities())
            {
                db.Korisniks.Add(pacijent);
                db.SaveChanges();
            }
        }

        // R = Read
        public List<Korisnik> GetAllPatients()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Korisniks
                        select pacijent).ToList();
            }
        }
        // U = UPDATE
        public void UpdatePatient(int patientId, string ime, string prezime, string kontakt, string ulica, string broj, string grad, string email, string lozinka, string korisnIme)
        {
            Pacijent pacijent;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                pacijent = db.Korisniks.Where(x => x.Id == patientId).FirstOrDefault() as Pacijent;
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!pacijent.Ime.Equals(ime))
            {
                pacijent.Ime = ime;
                haveChanges = true;
            }

            if (!pacijent.Prezime.Equals(prezime))
            {
                pacijent.Prezime = prezime;
                haveChanges = true;
            }
            if (!pacijent.Kontakt.Equals(kontakt))
            {
                pacijent.Kontakt = kontakt;
                haveChanges = true;
            }
            if (!pacijent.Ulica.Equals(ulica))
            {
                pacijent.Ulica = ulica;
                haveChanges = true;
            }
            if (!pacijent.Broj.Equals(broj))
            {
                pacijent.Broj = broj;
                haveChanges = true;
            }
            if (!pacijent.Grad.Equals(grad))
            {
                pacijent.Grad = grad;
                haveChanges = true;
            }
            if (!pacijent.Email.Equals(email))
            {
                pacijent.Email = email;
                haveChanges = true;
            }
            if (!pacijent.Korisnicko_Ime.Equals(korisnIme))
            {
                pacijent.Korisnicko_Ime = korisnIme;
                haveChanges = true;
            }
            if (!pacijent.Lozinka.Equals(lozinka))
            {
                pacijent.Lozinka = lozinka;
                haveChanges = true;
            }
            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(pacijent).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }


        // D = Delete
        public void DeletePatientById(int patientId)
        {
            Pacijent pacijent;

            using (var db = new ClinicDBEntities())
            {
                pacijent = db.Korisniks.Where(x => x.Id == patientId).FirstOrDefault() as Pacijent;
                db.Entry(pacijent).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #endregion

        #region Clinic
        public List<string> GetAllClinicsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from klinika in db.Klinikas
                        select klinika.Naziv).ToList();
            }
        }

        public int GetClinicIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from klinika in db.Klinikas
                        where klinika.Naziv == name
                        select klinika.Id).First();
            }
        }
        #endregion
        #region CRUD DEPARTMENT

        // C = Create
        //public void CreateDepartment(string naziv, string sprat, int clinicId)
        //{
        //    // dodavanje u tabelu departman
        //    Departman departman = new Departman(naziv, sprat);
        //    using (var db = new ClinicDBEntities())
        //    {
        //        db.Departmen.Add(departman);
        //        db.SaveChanges();
        //    }

        //    // dodavanje u medjutabelu
        //    Klinika_Departman kd = new Klinika_Departman()
        //    {
        //        KlinikaKlinika_Id = clinicId,
        //        DepartmanDepartman_Id = departman.Departman_Id
        //    };

        //    using (var db = new ClinicDBEntities())
        //    {
        //        db.Klinika_Departman.Add(kd);
        //        db.SaveChanges();
        //    }
        //}

        // R = Read
        public List<GetAllDepartments_Result> GetAllDepartments()
        {
            //using (var db = new ClinicDBEntities())
            //{
            //    return (from departman in db.Departmen
            //            select departman).ToList();
            //}

            //using (var db = new ClinicDBEntities())
            //{
            //    return (from departman in db.Departmen
            //            from clinic in db.Klinikas
            //            from kd in db.Klinika_Departman
            //            where departman.Departman_Id == kd.DepartmanDepartman_Id && clinic.Klinika_Id == kd.KlinikaKlinika_Id
            //            select new ExtendedDepartment { Name = departman.Naziv, Floor = departman.Sprat, DepartmanId = departman.Departman_Id, ClinicName = clinic.Naziv}).ToList();
            //}

            // funkcija
            using (var db = new ClinicDBEntities())
            {
                return db.GetAllDepartments().ToList();
            }
        }

        // za update 
        public string GetDepartmentNameById(int departmentId)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from departman in db.Departmen
                        where departman.Id == departmentId
                        select departman.Naziv).FirstOrDefault();
            }
        }

        // U = Update
        public void UpdateDepartment(int departmanId, string naziv, string sprat)
        {
            Departman departman;
            // preuzimanje podataka trenutnog doktora
            using (var db = new ClinicDBEntities())
            {
                departman = db.Departmen.Where(x => x.Id == departmanId).FirstOrDefault();
            }

            bool haveChanges = false;

            // menjanje vrednosti atributa
            if (!departman.Naziv.Equals(naziv))
            {
                departman.Naziv = naziv;
                haveChanges = true;
            }

            if (!departman.Sprat.Equals(sprat))
            {
                departman.Sprat = sprat;
                haveChanges = true;
            }

            // cuvanje izmena
            if (haveChanges)
            {
                using (var db = new ClinicDBEntities())
                {
                    db.Entry(departman).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        // da li doktor radi na nekom departmanu
        public List<int> GetAllDepartmentIds()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Korisniks
                        select doktor.Id).ToList();
            }
        }


        #endregion

        #region Patient
        public List<string> GetAllPatientsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Korisniks
                        select pacijent.Ime).ToList();
            }
        }

        public int GetPatientIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from pacijent in db.Korisniks
                        where pacijent.Ime == name
                        select pacijent.Id).First();
            }
        }
        #endregion
        #region Doctor
        public List<string> GetAllDoctorsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Korisniks
                        where doktor.Uloga.ToUpper() == "DOCTOR"
                        select doktor.Ime).ToList();
            }
        }
        //public List<string> GetGeneralPracticionerList()
        //{
        //    using (var db = new ClinicDBEntities())
        //    {
        //        return (from doktor in db.Korisniks
        //                where doktor.Uloga.ToUpper() == "DOCTOR" && doktor.Specijalizacija == "opsta praksa"
        //                select doktor.Ime).ToList();
        //    }
        //}
        // treba da vrati sve slobodne termin za gore izabranog doktora
        public List<string> GetAllTerminsList()
        {
            using (var db = new ClinicDBEntities())
            {
                return (from termin in db.Termins
                        select termin.Datum).ToList();
            }
        }

        public int GetDoctorIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from doktor in db.Korisniks
                        where doktor.Ime == name
                        select doktor.Id).First();
            }
        }


        public List<string> GetFreeTermins(int idDoktora)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from termin in db.Termins
                        from pregled in db.Pregleds
                        where pregled.Termins.Id == termin.Id &&

                              pregled.Doktor.Id == idDoktora
                        select termin.Datum + " " + termin.Vreme).ToList();
            }
        }
        #endregion

        //#region CRUD REVIEW

        // C = CREATE
        public void CreateReview(Pregled pregled)
        {
            using (var db = new ClinicDBEntities())
            {
                db.Korisniks.Attach(pregled.Doktor);
                db.Korisniks.Attach(pregled.Pacijent);
                db.Termins.Attach(pregled.Termins);
                db.Pregleds.Add(pregled);
                db.SaveChanges();
            }
        }

        public List<IshodView> GetReviewOutcomeLoggedPatient(int idPacijenta)
        {
            using (var db = new ClinicDBEntities())
            {
                var temp = (from ishod in db.Ishod_Pregleda
                            where ishod.Pregleds.Pacijent.Id == idPacijenta
                            select ishod).ToList().OrderBy(x => x.Pregleds.Termins.Id)
                       .Select(ishod => new IshodView
                       {
                           TerminPregleda = ishod.Pregleds.Termins.Datum + " " + ishod.Pregleds.Termins.Vreme,
                           ImeDoktora = ishod.Pregleds.Doktor.Ime,
                           Opis = ishod.Opis,
                           forOrder = ishod.Pregleds.Termins.Id
                           // Dijagnoza = ishod.
                       });

                var temp2 = (from pregled in db.Pregled_Specijaliste
                            // join terapija in db.Ishod_Pregleda on pregled.Ishod_Pregleda.Id equals terapija.Id
                             where pregled.Pacijent.Id == idPacijenta select new IshodView
                             {
                                  TerminPregleda = pregled.Termin_Specijaliste.Datum + " " + pregled.Termin_Specijaliste.Vreme,
                                  ImeDoktora = pregled.Doktor_Specijalista.Ime,
                                  Opis = "Opis obavljenog pregleda",
                                  forOrder= pregled.Termin_Specijaliste.Id
                             }).ToList();

                return (temp.Concat(temp2).ToList()).OrderByDescending(x=>x.forOrder).ToList();
            }
        }

        public List<UputView> GetReferralLoggedPatient(int idPacijenta)
        {
            using (var db = new ClinicDBEntities())
            {
                var temp = (from uput in db.Pregled_Specijaliste
                            where uput.Pacijent.Id == idPacijenta
                            select uput).ToList().OrderBy(x => x.Termin_Specijaliste.Id);
                var retVal = temp.Select(pregled => new UputView
                {
                    TerminPregleda = pregled.Termin_Specijaliste.Datum + " " + pregled.Termin_Specijaliste.Vreme,
                    ImeDoktoraOpstePrakse = pregled.Doktor_Specijalista.Ime,
                    Opis = pregled.Uput.Opis
                }); ;
                return retVal.ToList();
            }
        }
        public List<Terapija> GetTherapyListLoggedPatient(int idPacijenta)
        {
            using (var db = new ClinicDBEntities())
            {
                var temp = (from terapija in db.Terapijas
                            where terapija.Dijagnoza.Pregleds.Pacijent.Id == idPacijenta
                            select terapija).ToList().OrderBy(x => x.Dijagnoza.Pregleds.Termins.Id)
                       .Select(terapija => new Terapija
                       {
                           Naziv = terapija.Naziv,
                           Vrsta_Terapije = terapija.Vrsta_Terapije,
                           Opis = terapija.Opis
                       });
                return temp.ToList();
            }
        }


        public List<PregledView> GetReviewsLoggedInDoctor(int idDoktora)
        {
            using (var db = new ClinicDBEntities())
            {
                var temp = (from pregled in db.Pregleds
                            where pregled.Doktor.Id == idDoktora
                            select pregled).ToList().OrderBy(x => x.Termins.Id)
                       .Select(pregled => new PregledView
                       {
                           Id = pregled.Id,
                           TerminPregleda = pregled.Termins.Datum + " " + pregled.Termins.Vreme,
                           ImePacijenta = pregled.Pacijent.Ime,
                           Obavljen = pregled.Obvljen
                       });

                temp = temp.Where(x => DateTime.Parse(x.TerminPregleda).Date == DateTime.Now.Date);
                return temp.ToList();
            }
        }
        public List<UputView> GetReviewsLoggedInDoctorSpecialist(int idDoktora)
        {
            using (var db = new ClinicDBEntities())
            {
                var temp = (from pregled in db.Pregled_Specijaliste
                            where pregled.Doktor_Specijalista.Id == idDoktora
                            select pregled).ToList().OrderBy(x => x.Termin_Specijaliste.Id)
                       .Select(pregled => new UputView
                       {
                           Id = pregled.Id,
                           TerminPregleda = pregled.Termin_Specijaliste.Datum + " " + pregled.Termin_Specijaliste.Vreme,
                           ImePacijenta = pregled.Pacijent.Ime,
                           ImeDoktoraOpstePrakse = pregled.Doktor_Opste_Prakse.Ime,
                           Opis = pregled.Uput.Opis,
                           Obavljen = pregled.Ishod_Pregleda == null ? "Ne" : "Da"
                           //Obavljen = pregled.Ishod_Pregleda.Pregleds.Obvljen
                       });

                temp = temp.Where(x => DateTime.Parse(x.TerminPregleda).Date == DateTime.Now.Date);
                return temp.ToList();
            }
        }

        public Korisnik GetPatientByPregledId(int idPregleda)
        {
            using (var db = new ClinicDBEntities())
            {
                return db.Pregleds.FirstOrDefault(x => x.Id == idPregleda).Pacijent;
            }
            return null;
        }

        public void CreateTherapy(string naziv, string opis, string vrsta_Terapije, int idDijagnoze)
        {
            Terapija terapija = new Terapija(naziv, opis, vrsta_Terapije);
            using (var db = new ClinicDBEntities())
            {
                terapija.Dijagnoza = (Dijagnoza)db.Ishod_Pregleda.FirstOrDefault(x => x.Id == idDijagnoze);
                db.Ishod_Pregleda.Attach(terapija.Dijagnoza);
                db.Terapijas.Add(terapija);
                db.SaveChanges();
            }
        }

        public void CreatePregledSpecijaliste(int drSpecijalistaId, int drOpstePrakseId, int pacijentId, int terminSpecijalisteId)
        {
            Pregled_Specijaliste pregledSpecijaliste = new Pregled_Specijaliste();
            using (var db = new ClinicDBEntities())
            {
                pregledSpecijaliste.Uput = (Uput)db.Ishod_Pregleda.FirstOrDefault(x => x.Id == ReviewViewModel.StaticUputId);
                pregledSpecijaliste.Pacijent = (Pacijent)db.Korisniks.FirstOrDefault(x => x.Id == pacijentId);
                pregledSpecijaliste.Doktor_Specijalista = (Doktor)db.Korisniks.FirstOrDefault(x => x.Id == drSpecijalistaId);
                pregledSpecijaliste.Doktor_Opste_Prakse = (Doktor)db.Korisniks.FirstOrDefault(x => x.Id == drOpstePrakseId);
                pregledSpecijaliste.Termin_Specijaliste = (Termin_Specijaliste)db.Termin_Specijaliste.FirstOrDefault(x => x.Id == terminSpecijalisteId);

                db.Ishod_Pregleda.Attach(pregledSpecijaliste.Uput);
                db.Korisniks.Attach(pregledSpecijaliste.Pacijent);
                db.Korisniks.Attach(pregledSpecijaliste.Doktor_Opste_Prakse);
                db.Korisniks.Attach(pregledSpecijaliste.Doktor_Specijalista);
                db.Termin_Specijaliste.Attach(pregledSpecijaliste.Termin_Specijaliste);

                db.Pregled_Specijaliste.Add(pregledSpecijaliste);
                db.SaveChanges();
                /* var uput = pregledSpecijaliste.Uput;
                 uput.Pregled_Specijaliste1 = pregledSpecijaliste;
                 db.Entry(uput).State = System.Data.Entity.EntityState.Modified;
                 db.SaveChanges();
                */


            }
        }

        public void UpdateReview(Pregled pregled)
        {
            using (var db = new ClinicDBEntities())
            {
                var pregledForUpdate = db.Pregleds.FirstOrDefault(x => x.Id == pregled.Id);
                if (pregledForUpdate == null) return;
                if (pregled.Doktor.Id != pregledForUpdate.Doktor.Id)
                {
                    pregledForUpdate.Doktor = (Doktor)db.Korisniks.FirstOrDefault(x => x.Id == pregled.Doktor.Id);
                }
                if (pregled.Termins.Id != pregledForUpdate.Termins.Id)
                {
                    pregledForUpdate.Termins = db.Termins.FirstOrDefault(x => x.Id == pregled.Termins.Id);
                }
                db.Korisniks.Attach(pregledForUpdate.Doktor);
                db.Termins.Attach(pregledForUpdate.Termins);

                db.Entry(pregledForUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public Pregled GetPregled(int id)
        {
            using (var db = new ClinicDBEntities())
            {
                return db.Pregleds.FirstOrDefault(x => x.Id == id);
            }
        }
        // D-Delete
        public void DeleteReviewById(int reviewId)
        {
            Pregled pregled;

            using (var db = new ClinicDBEntities())
            {
                pregled = db.Pregleds.Where(x => x.Id == reviewId).FirstOrDefault();
                db.Entry(pregled).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void FinishedReview(int reviewId)
        {
            using (var db = new ClinicDBEntities())
            {

                var pregled = db.Pregleds.Where(x => x.Id == reviewId).FirstOrDefault();
                pregled.Obvljen = "Da";
                db.Entry(pregled).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //#endregion

        //#region CRUD REVIEW OUTCOME

        // C = CREATE
        public void CreateReviewOutcome(string naziv, string opis, int pregledId)
        {
            // string ishodStr = isUput == true ? "Uput" : "Dijagnoza";

            Ishod_Pregleda ishod = new Ishod_Pregleda(naziv, opis);
            using (var db = new ClinicDBEntities())
            {
                db.Ishod_Pregleda.Add(ishod);
                db.Entry(ishod).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                var pregled = db.Pregleds.FirstOrDefault(x => x.Id == pregledId);
                pregled.Ishod_Pregleda = ishod;
                db.Entry(pregled).State = System.Data.Entity.EntityState.Modified;
                db.Entry(pregled.Ishod_Pregleda).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
        public int CreateReferral(string naziv, string opis, int pregledId)
        {
            Uput uput = new Uput();
            using (var db = new ClinicDBEntities())
            {
                uput.Naziv = naziv;
                uput.Opis = opis;

                db.Ishod_Pregleda.Add(uput);
                db.Entry(uput).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                var pregled = db.Pregleds.FirstOrDefault(x => x.Id == pregledId);
                pregled.Ishod_Pregleda = uput;
                db.Entry(pregled).State = System.Data.Entity.EntityState.Modified;
                db.Entry(pregled.Ishod_Pregleda).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return uput.Id;
            }
        }

        public int CreateDiagnosis(string naziv, string opis, int pregledId)
        {
            Dijagnoza dijagnoza = new Dijagnoza();
            using (var db = new ClinicDBEntities())
            {
                dijagnoza.Naziv = naziv;
                dijagnoza.Opis = opis;

                db.Ishod_Pregleda.Add(dijagnoza);
                db.Entry(dijagnoza).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                var pregled = db.Pregleds.FirstOrDefault(x => x.Id == pregledId);
                pregled.Ishod_Pregleda = dijagnoza;
                db.Entry(pregled).State = System.Data.Entity.EntityState.Modified;
                db.Entry(pregled.Ishod_Pregleda).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                return dijagnoza.Id;
            }
        }

        public int GetDiagnosisIdByName(string name)
        {
            using (var db = new ClinicDBEntities())
            {
                return (from dijagnoza in db.Ishod_Pregleda
                        where dijagnoza.Naziv == name
                        select dijagnoza.Id).First();
            }
        }
    }
}
