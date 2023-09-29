using ClinicApp.Core;
using ClinicApp.View.All;
using ClinicApp.View.NewViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ClinicApp.ViewModel
{
    public enum ViewType
    {
        LOGIN_VIEW,
        REGISTER_VIEW,
        PATIENT_VIEW,
        DOCTOR_VIEW,
        DOCTOR_SPECIALIST_VIEW,
        GENERAL_PRACTICIONER_VIEW,
        REVIEW_VIEW,
        REFERRAL_VIEW,
        THERAPY_VIEW
    }
    public class MainWindowViewModel: BindableBase
    {
        private object currentView = new LoginView();

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        public static RelayCommand<ViewType> ChangeViewCommand { get; set; }

        public MainWindowViewModel()
        {
            CurrentView = new LoginView();
            ChangeViewCommand = new RelayCommand<ViewType>(OnChangeView);
        }

        public void OnChangeView(ViewType nextView)
        {
            switch (nextView)
            {
                case ViewType.LOGIN_VIEW:
                    CurrentView = new LoginView();
                    break;

                case ViewType.REGISTER_VIEW:
                    CurrentView = new RegistrationView();
                    break;

                case ViewType.PATIENT_VIEW:
                    CurrentView = new PatientView();
                    break;

                case ViewType.DOCTOR_VIEW:
                    CurrentView = new DoctorRegistrationView();
                    break;

                case ViewType.DOCTOR_SPECIALIST_VIEW:
                    CurrentView = new DoctorSpecialistView();
                    break;

                case ViewType.GENERAL_PRACTICIONER_VIEW:
                    CurrentView = new GeneralPracticionerView();
                    break;
                case ViewType.REVIEW_VIEW:
                    CurrentView = new ReviewView();
                    break;
                case ViewType.REFERRAL_VIEW:
                    CurrentView = new ReferralView();
                    break;
                case ViewType.THERAPY_VIEW:
                    CurrentView = new TherapyView();
                    break;
                default:
                    break;
            }
        }
    }
}
