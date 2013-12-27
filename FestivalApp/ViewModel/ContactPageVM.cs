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
            _changeTypes = ContactpersonType.GetTypes();
        }

        public string Name {
            get {
                return "Contact"; 
            }
        }

        private ObservableCollection<ContactpersonType> _types;
        public ObservableCollection<ContactpersonType> Types {
            get {
                return _types;
            }
            set {
                _types = value;
                OnPropertyChanged("Types");
            }
        }

        #region Contactpersonen

        private ObservableCollection<Contactperson> _contactpersons;
        private ObservableCollection<ContactpersonType> _changeTypes;
        private Contactperson _contactperson;
        private ContactpersonType _selectedType;
        private ContactpersonType _typeChange;

        public ObservableCollection<Contactperson> Contactpersons { 
            get {
                return _contactpersons;
            }
            set {
                _contactpersons = value;
                OnPropertyChanged("Contactpersons");
            }
        }
        public ObservableCollection<ContactpersonType> ChangeTypes {
            get {
                return _changeTypes;
            }
            set {
                _changeTypes = value;
                OnPropertyChanged("ChangeTypes");
            }
        }
        public Contactperson SelectedContactperson {
            get {
                return _contactperson;
            }
            set {
                _contactperson = value;
                OnPropertyChanged("SelectedContactperson");
            }
        }
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
        public ContactpersonType TypeChange {
            get {
                return _typeChange;
            }
            set {
                _typeChange = value;
                OnPropertyChanged("TypeChange");
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

        public ICommand NewContactPersonCommand {
            get {
                return new RelayCommand(NewContactperson);
            }
        }
        public ICommand EditContactPersonCommand {
            get {
                return new RelayCommand(EditContactperson);
            }
        }
        public ICommand DeleteContactPersonCommand {
            get {
                return new RelayCommand(DeleteContactperson);
            }
        }

        private void NewContactperson() {
            if (_typeChange == null) {
                MessageBox.Show("Er is geen functie geselecteerd.");
            }
            else {
                Contactperson c = new Contactperson();

                c.Name = _contactperson.Name;
                c.Company = _contactperson.Company;
                c.JobRole = _typeChange;
                c.City = _contactperson.City;
                c.Email = _contactperson.Email;
                c.Phone = _contactperson.Phone;
                c.Cellphone = _contactperson.Cellphone;

                Contactperson.InsertContactperson(c);

                MessageBox.Show("De wijzigingen werden opgeslaan.");
                OnPropertyChanged("Contactpersons");
            }
        }
        private void EditContactperson() {
            if (_typeChange == null) {
                MessageBox.Show("Er is geen functie geselecteerd.");
            } 
            else {
                Contactperson c = new Contactperson();

                c.ID = _contactperson.ID;
                c.Name = _contactperson.Name;
                c.Company = _contactperson.Company;
                c.JobRole = _typeChange;
                c.City = _contactperson.City;
                c.Email = _contactperson.Email;
                c.Phone = _contactperson.Phone;
                c.Cellphone = _contactperson.Cellphone;

                Contactperson.UpdateContactperson(c);

                MessageBox.Show("De wijzigingen werden opgeslaan.");
                OnPropertyChanged("Contactpersons");
            }
        }
        private void DeleteContactperson() {
            Contactperson c = new Contactperson();

            c.ID = _contactperson.ID;
            c.Name = _contactperson.Name;
            c.Company = _contactperson.Company;
            c.JobRole = _contactperson.JobRole;
            c.City = _contactperson.City;
            c.Email = _contactperson.Email;
            c.Phone = _contactperson.Phone;
            c.Cellphone = _contactperson.Cellphone;

            Contactperson.DeleteContactperson(c);

            MessageBox.Show("De wijzigingen werden opgeslaan.");
            OnPropertyChanged("Contactpersons");
        }

        #endregion

        #region Functies voor contactpersonen
        
        private ContactpersonType _cType;
        public ContactpersonType CType {
            get {
                return _cType;
            }
            set {
                _cType = value;
                OnPropertyChanged("CType");
            }
        }

        public ICommand NewContactpersonTypeCommand {
            get {
                return new RelayCommand(NewContactpersonType);
            }
        }
        public ICommand EditContactpersonTypeCommand {
            get {
                return new RelayCommand(EditContactpersonType);
            }
        }

        private void NewContactpersonType() {
            ContactpersonType ct = new ContactpersonType();

            ct.Name = _cType.Name;

            ContactpersonType.InsertContactpersonType(ct);

            MessageBox.Show("De nieuwe functie werd toegevoegd");
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");
        }
        private void EditContactpersonType() { 
            ContactpersonType ct = new ContactpersonType();

            ct.ID = _cType.ID;
            ct.Name = _cType.Name;

            ContactpersonType.UpdateContactpersonType(ct);

            MessageBox.Show("De functie werd gewijzigd");
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");
        }

        #endregion
    }
}
