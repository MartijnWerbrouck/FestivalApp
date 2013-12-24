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
        public LineUpPage()
        {
            InitializeComponent();
        }

        private void btnBandsNieuw_Click(object sender, RoutedEventArgs e)
        {
            var nieuwBand = new NieuwBand();
            nieuwBand.Show();
        }

        private void btnToonDetails_Click(object sender, RoutedEventArgs e)
        {
            var detailsBand = new DetailBand();
            detailsBand.Show();
        }

        private void btnBandsAanpassen_Click(object sender, RoutedEventArgs e)
        {
            var editBand = new EditBand();
            editBand.Show();
        }

        private void btnBandsVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("De band werd verwijderd");
        }
    }
}
