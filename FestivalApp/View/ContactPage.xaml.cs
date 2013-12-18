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
    /// Interaction logic for ContactPage.xaml
    /// </summary>
    public partial class ContactPage : UserControl
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private void btnNieuw_Click(object sender, RoutedEventArgs e)
        {
            var nieuwContact = new NieuwContact();
            nieuwContact.Show();
        }

        private void btnAanpassen_Click(object sender, RoutedEventArgs e)
        {
            var editContact = new EditContact();
            editContact.Show();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Het contactpersoon werd verwijderd");
        }
    }
}
