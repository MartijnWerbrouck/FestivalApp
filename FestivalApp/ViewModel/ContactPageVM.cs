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
    class ContactPageVM : ObservableObject, IPage
    {
        public ContactPageVM() {
            _contactpersons = CheckContactperson(_selectedType);
            _types = ContactpersonType.GetTypes();
        }

        public string Name {
            get {
                return "Contact"; 
            }
        }

        private ObservableCollection<Contactperson> _contactpersons;
        private ObservableCollection<ContactpersonType> _types;

        public ObservableCollection<Contactperson> Contactpersons { 
            get {
                return _contactpersons;
            }
            set {
                _contactpersons = value;
                OnPropertyChanged("Contactpersons");
            }
        }
        public ObservableCollection<ContactpersonType> Types {
            get {
                return _types;
            }
            set {
                _types = value;
                OnPropertyChanged("Types");
            }
        }

        private ContactpersonType _selectedType;
        public ContactpersonType SelectedType {
            get {
                return _selectedType;
            }
            set {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
                CheckContactperson(_selectedType);
            }
        }

        private ObservableCollection<Contactperson> CheckContactperson(ContactpersonType type) {
            if (type != null) {
                if (type.Name == "Alle") {
                    return _contactpersons = Contactperson.GetContactPersons();
                } else {
                    return _contactpersons = Contactperson.FilterContactpersons(type.ID);
                }
            } else {
                return _contactpersons = Contactperson.GetContactPersons();
            }
        }

        private Contactperson _contactperson;
        public Contactperson SelectedContactperson {
            get {
                return _contactperson;
            }
            set {
                _contactperson = value;
                OnPropertyChanged("SelectedContactperson");
            }
        }

        public ICommand NewContactPersonCommand {
            get {
                return new RelayCommand(NewContactperson);
            }
        }

        private void NewContactperson() {
            Contactperson c = new Contactperson();
            
            c.Name = _contactperson.Name;
            c.Company = _contactperson.Company;
            c.JobRole = _contactperson.JobRole;
            c.City = _contactperson.City;
            c.Email = _contactperson.Email;
            c.Phone = _contactperson.Phone;
            c.Cellphone = _contactperson.Cellphone;
            
            Contactperson.InsertContactperson(c);
            
            MessageBox.Show("De wijzigingen werden opgeslaan.");
        }
    }
}
