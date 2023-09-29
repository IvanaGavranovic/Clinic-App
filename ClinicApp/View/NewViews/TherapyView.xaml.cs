using ClinicApp.ViewModel;
using System.Windows.Controls;


namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for TherapyView.xaml
    /// </summary>
    public partial class TherapyView : UserControl
    {
        public TherapyView()
        {
            InitializeComponent();
            this.DataContext = new TherapyViewModel();
        }
    }
}
