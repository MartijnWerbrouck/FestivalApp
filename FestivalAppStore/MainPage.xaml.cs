using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using Windows.Data.Json;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FestivalAppStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpClient client = new HttpClient(); 
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml")); 

            HttpResponseMessage response = await client.GetAsync("http://localhost:6225/api/band"); 
            if (response.IsSuccessStatusCode) {        
                Stream stream = await response.Content.ReadAsStreamAsync();
                DataContractSerializer dxml = new DataContractSerializer(typeof(List<Band>)); 
                List<Band> list = dxml.ReadObject(stream) as List<Band>;
                bandslist.ItemsSource = list;

            }
        }

        private void bandslist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band band = (Band)(bandslist.SelectedItem);
            txtNaam.Text = band.Name;
            txtOmschrijving.Text = band.Description;
            txtFacebook.Text = band.Facebook;
            txtTwitter.Text = band.Twitter;

            BitmapImage img = new BitmapImage();
            img.UriSource = new Uri(this.BaseUri, "Images/" + band.Picture);
            imgBand.Source = img;   
        }
    }
}
