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
    class Band
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

        private String _Picture;

        public String Picture {
            get {
                return _Picture;
            }
            set {
                _Picture = value;
            }
        }

        private String _Description;

        public String Description {
            get {
                return _Description;
            }
            set {
                _Description = value;
            }
        }

        private String _Twitter;

        public String Twitter {
            get {
                return _Twitter;
            }
            set {
                _Twitter = value;
            }
        }

        private String _Facebook;

        public String Facebook {
            get {
                return _Facebook;
            }
            set {
                _Facebook = value;
            }
        }

        private ObservableCollection<Genre> _Genres;

        public ObservableCollection<Genre> Genres {
            get {
                return _Genres;
            }
            set {
                _Genres = value;
            }
        }

        public static ObservableCollection<Band> GetBands() {
            ObservableCollection<Band> lijst = new ObservableCollection<Band>();

            String sSQL = "SELECT * FROM Band"; 
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read()) {
                Band aNieuw = new Band();

                aNieuw._ID = reader["BandID"].ToString();
                String BandID = reader["BandID"].ToString();

                aNieuw._Name = reader["Name"].ToString();

                if (!DBNull.Value.Equals(reader["Picture"]))
                    aNieuw._Picture = reader["Picture"].ToString();
                else
                    aNieuw._Picture = null;

                if (!DBNull.Value.Equals(reader["Description"]))
                    aNieuw._Description = reader["Description"].ToString();
                else
                    aNieuw._Description = null;

                if (!DBNull.Value.Equals(reader["Twitter"]))
                    aNieuw._Twitter = reader["Twitter"].ToString();
                else
                    aNieuw._Twitter = null;

                if (!DBNull.Value.Equals(reader["Facebook"]))
                    aNieuw._Facebook = reader["Facebook"].ToString();
                else
                    aNieuw._Facebook = null;

                aNieuw._Genres = GetAllGenresFromBand(BandID);

                lijst.Add(aNieuw);
            }
            return lijst;
        }

        private static ObservableCollection<Genre> GetAllGenresFromBand(String BandID) {
            ObservableCollection<Genre> lijst = new ObservableCollection<Genre>();
            ObservableCollection<Genre> genres = Genre.GetGenres(); 

            String sSQL = "SELECT * FROM BandGenre WHERE BandID = @BandID";
            DbParameter par1 = Database.AddParameter("@BandID", BandID);
            DbDataReader reader = Database.GetData(sSQL, par1);

            while (reader.Read()) {
                Genre aNieuw = new Genre();

                foreach(Genre genre in genres) {
                    if (genre.ID == reader["GenreID"].ToString()) {
                        aNieuw.ID = genre.ID;
                        aNieuw.Name = genre.Name;
                    }
                }

                lijst.Add(aNieuw);
            }
            return lijst; 
        }
    }
}
