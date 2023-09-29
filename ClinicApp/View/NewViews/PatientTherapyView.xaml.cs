using ClinicApp.ViewModel.NewViewModels;
using System.Windows.Controls;


namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for PatientTherapyView.xaml
    /// </summary>
    public partial class PatientTherapyView : UserControl
    {
        public PatientTherapyView()
        {
            InitializeComponent();
            this.DataContext = new PatientTherapyViewModel();
        }
    }
}
