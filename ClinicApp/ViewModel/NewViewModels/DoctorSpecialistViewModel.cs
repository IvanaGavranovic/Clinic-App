using ClinicApp.Core;
using ClinicApp.View;
using ClinicApp.View.All;
using ClinicApp.View.NewView;
using ClinicApp.View.NewViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class DoctorSpecialistViewModel: ValidationBase
    {
        #region Fields and properties

        private int selectedTab2;
        private object specialistListReviewTab;
        private object reviewTab;
        private object referralTab;
        private object therapyTab;
        private object logOutTab;

        public int SelectedTab2
        {
            get { return selectedTab2; }
            set
            {
                if (selectedTab2 != value)
                {
                    selectedTab2 = value;
                    OnPropertyChanged("SelectedTab2");
                }
            }
        }
        public object SpecialistListReviewTab
        {
            get { return specialistListReviewTab; }
            set
            {
                if (specialistListReviewTab != value)
                {
                    specialistListReviewTab = value;
                    OnPropertyChanged("SpecialistListReviewTab");
                }
            }
        }
        public object ReviewTab
        {
            get { return reviewTab; }
            set
            {
                if (reviewTab != value)
                {
                    reviewTab = value;
                    OnPropertyChanged("ReviewTab");
                }
            }
        }
        public object ReferralTab
        {
            get { return referralTab; }
            set
            {
                if (referralTab != value)
                {
                    referralTab = value;
                    OnPropertyChanged("ReferralTab");
                }
            }
        }
        public object TherapyTab
        {
            get { return therapyTab; }
            set
            {
                if (therapyTab != value)
                {
                    therapyTab = value;
                    OnPropertyChanged("TherapyTab");
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
     
        public MyICommand LogOutCommand { get; set; }

        public DoctorSpecialistViewModel()
        {
            try
            {
                ChangeTabCommand = new RelayCommand<int>(OnChangeTab);

                SpecialistListReviewTab = new SpecialistListReviewView();
                ReviewTab = new ReviewView();
                TherapyTab = new TherapyView();
                ReferralTab = new ReferralView();

                LogOutCommand = new MyICommand(OnLogOut);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region Methods
        public void OnChangeTab(int tabNum)
        {
            SelectedTab2 = tabNum;
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
