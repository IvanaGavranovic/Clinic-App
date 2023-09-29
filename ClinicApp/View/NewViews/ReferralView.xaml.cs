using ClinicApp.ViewModel;
using ClinicApp.ViewModel.NewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClinicApp.View.NewViews
{
    /// <summary>
    /// Interaction logic for ReferralView.xaml
    /// </summary>
    public partial class ReferralView : UserControl
    {
        public ReferralView()
        {
            InitializeComponent();
            this.DataContext = new ReferralViewModel();
        }
    }
}
