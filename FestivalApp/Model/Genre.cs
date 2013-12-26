using _6Oefening1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class Genre : IDataErrorInfo
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

        public static ObservableCollection<Genre> GetGenres() {
            ObservableCollection<Genre> lijst = new ObservableCollection<Genre>();

            String sSQL = "SELECT * FROM Genre";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read()) {
                Genre aNieuw = new Genre();

                aNieuw._ID = reader["GenreID"].ToString();
                aNieuw._Name = reader["Name"].ToString();

                lijst.Add(aNieuw);
            }
            return lijst;
        }

        //Genre toevoegen aan database
        public static void AddGenre(Genre g) {
            String sSQL = "INSERT INTO Genre (Name) VALUES (@Name)";

            DbParameter par1 = Database.AddParameter("@Name", g._Name);

            Database.ModifyData(sSQL, par1);
        }

        //Genre aanpassen in database 
        public static void ModifyGenre(Genre g) {
            String sSQL = "UPDATE Genre SET Name = @Name WHERE GenreID = @ID";

            DbParameter par1 = Database.AddParameter("@ID", g._ID);
            DbParameter par2 = Database.AddParameter("@Name", g._Name);

            Database.ModifyData(sSQL, par1, par2);
        }

        //Genre verwijderen van database
        public static void DeleteGenre(Genre g) {
            String sSQL = "DELETE FROM Genre WHERE Name = @Name";

            DbParameter par1 = Database.AddParameter("@Name", g._Name);

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
                switch (columnName) {
                    case "Name":
                        if (string.IsNullOrEmpty(_Name))
                            error = "De naam is verplicht";
                        break;
                }
                return error;
            }
        }
    }
}
