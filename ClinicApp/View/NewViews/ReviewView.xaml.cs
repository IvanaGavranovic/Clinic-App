using ClinicApp.ViewModel.NewViewModels;
using System.Windows.Controls;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for ReviewView.xaml
    /// </summary>
    public partial class ReviewView : UserControl
    {
        public ReviewView()
        {
            InitializeComponent();
            this.DataContext = new ReviewViewModel();
        }
    }
}
