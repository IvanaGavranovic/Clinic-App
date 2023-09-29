using ClinicApp.ViewModel.NewViewModels;
using System.Windows.Controls;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for PatientReviewOutcomeView.xaml
    /// </summary>
    public partial class PatientReviewOutcomeView : UserControl
    {
        public PatientReviewOutcomeView()
        {
            InitializeComponent();
            this.DataContext = new PatientReviewOutcomeViewModel();
        }
    }
}
