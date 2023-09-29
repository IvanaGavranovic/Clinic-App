using ClinicApp.ViewModel;
using System.Windows.Controls;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for DoctorRegistrationView.xaml
    /// </summary>
    public partial class DoctorRegistrationView : UserControl
    {
        public DoctorRegistrationView()
        {
            InitializeComponent();
            this.DataContext = new DoctorRegistrationViewModel();
        }
    }
}
