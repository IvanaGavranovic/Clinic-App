using ClinicApp.ViewModel;
using System.Windows.Controls;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for GeneralPracticionerView.xaml
    /// </summary>
    public partial class GeneralPracticionerView : UserControl
    {
        public GeneralPracticionerView()
        {
            InitializeComponent();
            this.DataContext = new GeneralPracticionerViewModel();
        }
    }
}
