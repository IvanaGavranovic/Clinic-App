using ClinicApp.ViewModel.NewViewModels;
using System.Windows.Controls;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for PatientReferralView.xaml
    /// </summary>
    public partial class PatientReferralView : UserControl
    {
        public PatientReferralView()
        {
            InitializeComponent();
            this.DataContext = new PatientReferralViewModel();
        }
    }
}
