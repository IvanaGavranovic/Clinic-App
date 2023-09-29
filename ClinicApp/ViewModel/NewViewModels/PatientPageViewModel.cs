using ClinicApp.Core;
using ClinicApp.View.NewViews;
using GalaSoft.MvvmLight.Command;

namespace ClinicApp.ViewModel
{
    public class PatientPageViewModel : ValidationBase
    {
        #region Fields and properties

        private object newReviewTab;
        private object patientReviewOutcomeTab;
        private object patientTherapyTab;
        private object patientReferralTab;
        private int selectedTab3;
        private object logOutTab;

        public object NewReviewTab
        {
            get { return newReviewTab; }
            set
            {
                if (newReviewTab != value)
                {
                    newReviewTab = value;
                    OnPropertyChanged("NewReviewTab");
                }
            }
        }
        public object PatientReviewOutcomeTab
        {
            get { return patientReviewOutcomeTab; }
            set
            {
                if (patientReviewOutcomeTab != value)
                {
                    patientReviewOutcomeTab = value;
                    OnPropertyChanged("PatientReviewOutcomeTab");
                }
            }
        }
        public object PatientTherapyTab
        {
            get { return patientTherapyTab; }
            set
            {
                if (patientTherapyTab != value)
                {
                    patientTherapyTab = value;
                    OnPropertyChanged("PatientTherapyTab");
                }
            }
        }
        public object PatientReferralTab
        {
            get { return patientReferralTab; }
            set
            {
                if (patientReferralTab != value)
                {
                    patientReferralTab = value;
                    OnPropertyChanged("PatientReferralTab");
                }
            }
        }
        public int SelectedTab3
        {
            get { return selectedTab3; }
            set
            {
                if (selectedTab3 != value)
                {
                    selectedTab3 = value;
                    OnPropertyChanged("SelectedTab3");
                }
            }
        }

        public object LogOutTab
        {
            get { return logOutTab; }
            set
            {
                if (logOutTab != value)
                {
                    logOutTab = value;
                    OnPropertyChanged("LogOutTab");
                }
            }
        }
        public static RelayCommand<int> ChangeTabCommand { get; set; }
        #endregion

        #region Constructor

        public MyICommand AddCommand { get; set; }
        public MyICommand LogOutCommand { get; set; }

        public PatientPageViewModel()
        {
            AddCommand = new MyICommand(OnAdd);
          
            ChangeTabCommand = new RelayCommand<int>(OnChangeTab);

            NewReviewTab = new AddNewReview();
            PatientReferralTab = new PatientReferralView();
            PatientReviewOutcomeTab = new PatientReviewOutcomeView();
            PatientTherapyTab = new PatientTherapyView();
         
            LogOutCommand = new MyICommand(OnLogOut);
        }
        #endregion

        #region Methods
        public void OnChangeTab(int tabNum)
        {
            SelectedTab3 = tabNum;
        }
        public void OnAdd()
        {
        }
       
        public void OnLogOut()
        {
            SingletonUser.Instance = null;
            MainWindowViewModel.ChangeViewCommand.Execute(ViewType.LOGIN_VIEW);
        }

        protected override void ValidateSelf()
        {
            // throw new NotImplementedException();
        }
        #endregion
    }
}
