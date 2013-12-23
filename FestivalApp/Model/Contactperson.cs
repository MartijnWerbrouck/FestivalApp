using _6Oefening1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class Contactperson : IDataErrorInfo
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

        private String _Company;
        public String Company {
            get {
                return _Company;
            }
            set {
                _Company = value;
            }
        }

        private ContactpersonType _JobRole;
        public ContactpersonType JobRole {
            get {
                return _JobRole;
            }
            set {
                _JobRole = value;
            }
        }

        private String _City;
        public String City {
            get {
                return _City;
            }
            set {
                _City = value;
            }
        }

        private String _Email;
        public String Email {
            get {
                return _Email;
            }
            set {
                _Email = value;
            }
        }

        private String _Phone;
        public String Phone {
            get {
                return _Phone;
            }
            set {
                _Phone = value;
            }
        }

        private String _Cellphone;
        public String Cellphone {
            get {
                return _Cellphone;
            }
            set {
                _Cellphone = value;
            }
        }

        //Ophalen uit de database
        public static ObservableCollection<Contactperson> GetContactPersons() {
            ObservableCollection<Contactperson> lijst = new ObservableCollection<Contactperson>();

            String sSQL = "SELECT * FROM ContactPerson";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read()) {
                Contactperson c = new Contactperson();

                c._ID = reader["ContactPersonID"].ToString();
                c._Name = reader["Name"].ToString();
                c._Company = reader["Company"].ToString();
                c._JobRole = ContactpersonType.GetJobeRoleByID(reader["JobRoleID"].ToString());
                c._City = reader["City"].ToString();
                c._Email = reader["Email"].ToString();
                c._Phone = reader["Phone"].ToString();
                c._Cellphone = reader["Cellphone"].ToString();

                lijst.Add(c);
            }
            return lijst;
        }

        //Filteren op een JobRole
        public static ObservableCollection<Contactperson> FilterContactpersons(String ID) {
            ObservableCollection<Contactperson> lijst = new ObservableCollection<Contactperson>();

            String sSQL = "SELECT * FROM ContactPerson WHERE JobRoleID = @JobRoleID";
            DbParameter par1 = Database.AddParameter("@JobRoleID", Convert.ToInt32(ID));
            DbDataReader reader = Database.GetData(sSQL, par1);

            while (reader.Read()) {
                Contactperson c = new Contactperson();

                c._ID = reader["ContactPersonID"].ToString();
                c._Name = reader["Name"].ToString();

                if (!DBNull.Value.Equals(reader["Company"]))
                    c._Company = reader["Company"].ToString();
                else
                    c._Company = null;

                c._JobRole = ContactpersonType.GetJobeRoleByID(reader["JobRoleID"].ToString());

                if (!DBNull.Value.Equals(reader["City"]))
                    c._City = reader["City"].ToString();
                else
                    c._City = null;

                if (!DBNull.Value.Equals(reader["Email"]))
                    c._Email = reader["Email"].ToString();
                else
                    c._City = null;

                if (!DBNull.Value.Equals(reader["Phone"]))
                    c._Phone = reader["Phone"].ToString();
                else
                    c._Phone = null;

                if (!DBNull.Value.Equals(reader["Cellphone"]))
                    c._Cellphone = reader["Cellphone"].ToString();
                else
                    c._Cellphone = null;

                lijst.Add(c);
            }
            return lijst;
        }

        //Insert in de database
        public static void InsertContactperson(Contactperson c) {
            String sSQL = "INSERT INTO ContactPerson (Name, Company, JobRoleID, City, Email, Phone, Cellphone) VALUES (@Name, @Company, @JobRoleID, @City, @Email, @Phone, @Cellphone)";
            
            DbParameter par1 = Database.AddParameter("@Name", c._Name);
            DbParameter par2 = Database.AddParameter("@Company", c._Company);
            DbParameter par3 = Database.AddParameter("@JobRoleID", Convert.ToInt32(c._JobRole.ID));
            DbParameter par4 = Database.AddParameter("@City", c._City);
            DbParameter par5 = Database.AddParameter("@Email", c._Email);
            DbParameter par6 = Database.AddParameter("@Phone", c._Phone);
            DbParameter par7 = Database.AddParameter("@Cellphone", c._Cellphone);

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6, par7);
        }

        //Update in de database 
        public static void UpdateContactperson(Contactperson c) {
            String sSQL = "UPDATE ContactPerson SET Name = @Name, Company = @Company, JobRoleID = @JobRoleID, City = @City, Email = @Email, Phone = @Phone, Cellphone = @Cellphone WHERE ContactPersonID = @ID";

            DbParameter par1 = Database.AddParameter("@Name", c._Name);
            DbParameter par2 = Database.AddParameter("@Company", c._Company);
            DbParameter par3 = Database.AddParameter("@JobRoleID", Convert.ToInt32(c._JobRole.ID));
            DbParameter par4 = Database.AddParameter("@City", c._City);
            DbParameter par5 = Database.AddParameter("@Email", c._Email);
            DbParameter par6 = Database.AddParameter("@Phone", c._Phone);
            DbParameter par7 = Database.AddParameter("@Cellphone", c._Cellphone);
            DbParameter par8 = Database.AddParameter("@ID", c._ID);

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6, par7, par8);
        }

        //Delete in de database 
        public static void DeleteContactperson(Contactperson c) {
            String sSQL = "DELETE FROM ContactPerson WHERE Name = @Name";

            DbParameter par1 = Database.AddParameter("@Name", c._Name);

            Database.ModifyData(sSQL, par1);
        }

        public string Error {
            get {
                return "Model not valid";
            }
        }

        public string this[string columnName] {
            get { 
                string error = string.Empty;
                switch(columnName) {
                    case "Name":
                        if(string.IsNullOrEmpty(_Name))
                            error = "De naam is verplicht";
                    break;
   
                    case "Company":
                        if (string.IsNullOrEmpty(_Company))
                            error = "Het bedrijf is verplicht";
                    break;

                    case "City":
                        if (string.IsNullOrEmpty(_City))
                            error = "De stad is verplicht";
                    break;

                    case "Email":
                        if (string.IsNullOrEmpty(_Email))
                            error = "Het emailadres is verplicht";
                    break;

                    case "Phone":
                    if (string.IsNullOrEmpty(_Phone))
                        error = "Het telefoonnummer is verplicht";
                    break;

                    case "Cellphone":
                    if (string.IsNullOrEmpty(_Cellphone))
                        error = "Het gsmnummer is verplicht";
                    break;
                }
                return error;
            }
        }
    }
}
