using ClinicApp.ViewModel.NewViewModels;
using System.Windows.Controls;

namespace ClinicApp.View.NewView

{
    /// <summary>
    /// Interaction logic for SpecialistListReviewView.xaml
    /// </summary>
    public partial class SpecialistListReviewView : UserControl
    {
        public SpecialistListReviewView()
        {
            InitializeComponent();
            this.DataContext = new SpecialistListReviewViewModel();
        }
    }
}
