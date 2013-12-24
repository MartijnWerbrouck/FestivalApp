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
    /// Interaction logic for TicketingPage.xaml
    /// </summary>
    public partial class TicketingPage : UserControl
    {
        public TicketingPage()
        {
            InitializeComponent();

            //Prijsbevestiging
            txtPrijsAantal.IsEnabled = false;
            txtPrijsTicket.IsEnabled = false;
            btnPrijsBevestigen.IsEnabled = false;

            //Klanten
            cboTicketTypes.IsEnabled = false;
            btnReserveer.IsEnabled = false;
            btnExportToWord.IsEnabled = false;
        }

        private void cboDagen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrijsAantal.IsEnabled = true;
            txtPrijsTicket.IsEnabled = true;
            btnPrijsBevestigen.IsEnabled = true;
        }

        private void dgKlanten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboTicketTypes.IsEnabled = true;
            btnReserveer.IsEnabled = true;
            btnExportToWord.IsEnabled = true;
        }
    }
}
