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
    class Genre
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
    }
}
