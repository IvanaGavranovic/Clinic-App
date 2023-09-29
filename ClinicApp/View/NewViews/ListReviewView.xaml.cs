using ClinicApp.ViewModel.NewViewModels;
using System.Windows.Controls;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for ListReviewView.xaml
    /// </summary>
    public partial class ListReviewView : UserControl
    {
        public ListReviewView()
        {
            InitializeComponent();
            this.DataContext = new ListReviewViewModel();
        }
    }
}
