using ClinicApp.Core;
using ClinicApp.View.All;
using ClinicApp.View.NewViews;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModel
{
    public class GeneralPracticionerViewModel : ValidationBase
    {
        #region Fields and properties

        private int selectedTab1;
        private object listReviewTab;
        private object reviewTab;
        private object referralTab;
        private object therapyTab;
        private object logOutTab;

        public int SelectedTab1
        {
            get { return selectedTab1; }
            set
            {
                if (selectedTab1 != value)
                {
                    selectedTab1 = value;
                    OnPropertyChanged("SelectedTab1");
                }
            }
        }
        public object ListReviewTab
        {
            get { return listReviewTab; }
            set
            {
                if (listReviewTab != value)
                {
                    listReviewTab = value;
                    OnPropertyChanged("ListReviewTab");
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

        public GeneralPracticionerViewModel()
        {
            try { 
            
            ChangeTabCommand = new RelayCommand<int>(OnChangeTab);

            ListReviewTab = new ListReviewView();
            ReviewTab = new ReviewView();
            TherapyTab = new TherapyView();
            ReferralTab = new ReferralView();

            LogOutCommand = new MyICommand(OnLogOut);
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region Methods
        public void OnChangeTab(int tabNum)
        {
            SelectedTab1 = tabNum;
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
