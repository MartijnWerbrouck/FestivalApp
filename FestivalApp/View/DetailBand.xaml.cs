using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace FestivalApp.View
{
    /// <summary>
    /// Interaction logic for DetailBand.xaml
    /// </summary>
    public partial class DetailBand : Window
    {
        public DetailBand()
        {
            InitializeComponent();
        }

        public void DetailsInvullen(String name, String img, String description, String twitter, String facebook, List<String> lijst) {
            txtNaam.Text = name;
            imgFoto.Source = new BitmapImage(new Uri(@"/Images/" + img, UriKind.Relative));
            txtOmschrijving.Text = description;
            txtTwitter.Text = twitter;
            txtFacebook.Text = facebook;
            foreach (String s in lijst) {
                lstGenres.Items.Add(s);
            }
        }
    }
}
