using FestivalApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FestivalApp.ViewModel
{
    class HomePageVM : ObservableObject, IPage
    {
        public string Name {
            get { 
                return "Home"; 
            }
        }

        public HomePageVM() {
            _festival = Festival.GetFestival();
        }

        private Festival _festival;
        public Festival Festivals {
            get {
                return _festival;
            }
            set {
                _festival = value;
                OnPropertyChanged("Festivals");
            }
        }

        //Command waar de button aan gebind is
        public ICommand EditFestivalCommand {
            get {
                return new RelayCommand(EditFestival);
            }
        }

        private void EditFestival() {
            Festival editFestival = new Festival();
            editFestival.Name = Festivals.Name;
            editFestival.StartDate = Festivals.StartDate;
            editFestival.EndDate = Festivals.EndDate;

            Festival.SaveFestival(editFestival);

            MessageBox.Show("De wijzigingen werden opgeslaan.");
        }
    }
}
