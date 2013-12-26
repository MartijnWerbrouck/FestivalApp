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

namespace FestivalApp.View
{
    /// <summary>
    /// Interaction logic for LineUpPage.xaml
    /// </summary>
    public partial class LineUpPage : UserControl
    {
        public LineUpPage() {
            InitializeComponent();

            //Stage
            btnPodiaNieuw.IsEnabled = false;
            btnPodiaAanpassen.IsEnabled = false;
            btnPodiaVerwijderen.IsEnabled = false;

            //Bands
            btnBandsNieuw.IsEnabled = false;
            btnBandsAanpassen.IsEnabled = false;
            btnBandsVerwijderen.IsEnabled = false;
            btnAfbeeldingToevoegen.IsEnabled = false;
            cboGenresToevoegen.IsEnabled = false;
            btnGenresToevoegen.IsEnabled = false;
            btnGenresBevestigen.IsEnabled = false;

            //LineUp 
            btnLineUpNieuw.IsEnabled = false;
            btnLineUpAanpassen.IsEnabled = false;
            btnLineUpVerwijderen.IsEnabled = false;
            dpDatum.IsEnabled = false;
            cboBandKiezen.IsEnabled = false;
            btnToonDetails.IsEnabled = false;
            cboStageKiezen.IsEnabled = false; 
        }

        private void dgPodia_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnPodiaNieuw.IsEnabled = true;
            btnPodiaAanpassen.IsEnabled = true;
            btnPodiaVerwijderen.IsEnabled = true;
        }

        private void dgBands_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnBandsNieuw.IsEnabled = true;
            btnBandsAanpassen.IsEnabled = true;
            btnBandsVerwijderen.IsEnabled = true;
            btnAfbeeldingToevoegen.IsEnabled = true;
            cboGenresToevoegen.IsEnabled = true;
            btnGenresToevoegen.IsEnabled = true;
        }

        private void cboGenresToevoegen_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnGenresBevestigen.IsEnabled = true;
        }

        private void dgLineUp_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnLineUpNieuw.IsEnabled = true;
            btnLineUpAanpassen.IsEnabled = true;
            btnLineUpVerwijderen.IsEnabled = true;
            dpDatum.IsEnabled = true;
            cboBandKiezen.IsEnabled = true;
            btnToonDetails.IsEnabled = true;
            cboStageKiezen.IsEnabled = true; 
        }
    }
}
