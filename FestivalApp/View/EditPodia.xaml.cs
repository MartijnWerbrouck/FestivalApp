using FestivalApp.Model;
using FestivalApp.ViewModel;
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
    /// Interaction logic for EditPodia.xaml
    /// </summary>
    public partial class EditPodia : Window
    {
        private String ID; 

        public EditPodia(String SelectedID)
        {
            ID = SelectedID;
            InitializeComponent();
        }

        private void btnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            Stage editStage = new Stage();
            editStage.ID = ID;
            editStage.Name = txtNaam.Text.ToString();
            LineUpPageVM.UpdateStage(editStage);

            MessageBox.Show("De wijzigingen werden opgeslaan.");
            this.Close();
        }
    }
}
