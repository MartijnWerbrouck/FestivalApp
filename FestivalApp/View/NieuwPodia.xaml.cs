using FestivalApp.Model;
using GalaSoft.MvvmLight.Command;
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
using System.Windows.Shapes;

namespace FestivalApp.View
{
    /// <summary>
    /// Interaction logic for NieuwPodia.xaml
    /// </summary>
    public partial class NieuwPodia : Window
    {
        private int ID; 

        public NieuwPodia() {
            InitializeComponent();
            ID = 5;
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e) {
            ID += 1;
            Stage newStage = new Stage();
            newStage.ID = Convert.ToString(ID);
            newStage.Name = txtNaam.Text;
            Stage.AddStage(newStage);

            MessageBox.Show("De wijzigingen werden opgeslaan.");
            this.Close();
        }
    }
}
