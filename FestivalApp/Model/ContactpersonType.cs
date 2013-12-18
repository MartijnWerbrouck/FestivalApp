using _6Oefening1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class ContactpersonType
    {
        private String _ID;

        public String ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }

        private String _Name;

        public String Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        public static ObservableCollection<ContactpersonType> GetTypes() {
            ObservableCollection<ContactpersonType> lijst = new ObservableCollection<ContactpersonType>();

            String sSQL = "SELECT * FROM ContactPersonType";
            DbDataReader reader = Database.GetData(sSQL);

            while(reader.Read()) {
                ContactpersonType ct = new ContactpersonType();

                ct._ID = reader["ContactPersonTypeID"].ToString();
                ct._Name = reader["Name"].ToString();

                lijst.Add(ct);
            }
            return lijst; 
        }

        public static ContactpersonType GetJobeRoleByID(String JobRoleID) {
            ObservableCollection<ContactpersonType> lijst = ContactpersonType.GetTypes();
            return lijst.Where(ct => ct._ID == JobRoleID).SingleOrDefault();
        }

        public static ContactpersonType GetJobeRoleByName(ContactpersonType ct) {
            ObservableCollection<ContactpersonType> lijst = ContactpersonType.GetTypes();
            return lijst.Where(cpt => cpt == ct).SingleOrDefault();
        }

        public override string ToString() {
            return this._Name;
        }
    }
}
