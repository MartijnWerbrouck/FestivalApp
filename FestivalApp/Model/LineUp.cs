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
    class LineUp : IDataErrorInfo
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

        private DateTime _Date;
        public DateTime Date {
            get {
                return _Date;
            }
            set {
                _Date = value;
            }
        }

        private String _From;
        public String From {
            get {
                return _From;
            }
            set {
                _From = value;
            }
        }

        private String _Until;
        public String Until {
            get {
                return _Until;
            }
            set {
                _Until = value;
            }
        }

        private Stage _Stage;
        public Stage Stage {
            get {
                return _Stage;
            }
            set {
                _Stage = value;
            }
        }

        private Band _Band;
        public Band Band {
            get {
                return _Band;
            }
            set {
                _Band = value;
            }
        }

        public static ObservableCollection<LineUp> GetLineUp() {
            ObservableCollection<LineUp> lijst = new ObservableCollection<LineUp>();

            String sSQL = "SELECT * FROM LineUP";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read()) {
                LineUp aNieuw = new LineUp();

                aNieuw._ID = reader["LineUpID"].ToString();
                aNieuw._Date = Convert.ToDateTime(reader["Date"].ToString());
                aNieuw._From = reader["From"].ToString();
                aNieuw._Until = reader["Until"].ToString();

                aNieuw._Stage = GetStageFromLineUp(reader["StageID"].ToString());
                aNieuw._Band = GetBandFromLineUp(reader["BandID"].ToString());

                lijst.Add(aNieuw);
            }
            return lijst;
        }

        private static Stage GetStageFromLineUp(string StageID) {
            ObservableCollection<Stage> lijst = Stage.GetStages();
            return lijst.Where(stage => stage.ID == StageID).SingleOrDefault();
        }
        private static Band GetBandFromLineUp(string BandID) {
            ObservableCollection<Band> lijst = Band.GetBands();
            return lijst.Where(band => band.ID == BandID).SingleOrDefault();
        }
        
        //LineUp toevoegen aan database
        public static void AddLineUp(LineUp lu) {
            String sSQL = "INSERT INTO LineUp (Date, [From], Until, StageID, BandID) VALUES (@Date, @From, @Until, @StageID, @BandID)";

            DbParameter par1 = Database.AddParameter("@Date", Convert.ToDateTime(lu._Date));
            DbParameter par2 = Database.AddParameter("@From", lu._From);
            DbParameter par3 = Database.AddParameter("@Until", lu._Until);
            DbParameter par4 = Database.AddParameter("@StageID", Convert.ToInt32(lu._Stage.ID));
            DbParameter par5 = Database.AddParameter("@BandID", Convert.ToInt32(lu._Band.ID));

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5);
        }

        //LineUp aanpassen in database 
        public static void ModifyLineUp(LineUp lu) {
            String sSQL = "UPDATE LineUP SET Date = @Date, [From] = @From, Until = @Until, StageID = @StageID, BandID = @BandID  WHERE LineUpID = @ID";

            DbParameter par1 = Database.AddParameter("@ID", lu._ID);
            DbParameter par2 = Database.AddParameter("@Date", Convert.ToDateTime(lu._Date));
            DbParameter par3 = Database.AddParameter("@From", lu._From);
            DbParameter par4 = Database.AddParameter("@Until", lu._Until);
            DbParameter par5 = Database.AddParameter("@StageID", Convert.ToInt32(lu._Stage.ID));
            DbParameter par6 = Database.AddParameter("@BandID", Convert.ToInt32(lu._Band.ID));

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6);
        }

        //LineUp verwijderen van database
        public static void DeleteLineUp(LineUp lu) {
            String sSQL = "DELETE FROM LineUp WHERE Date = @Date AND [From] = @From AND Until = @Until";

            DbParameter par1 = Database.AddParameter("@Date", lu._Date);
            DbParameter par2 = Database.AddParameter("@From", lu._From);
            DbParameter par3 = Database.AddParameter("@Until", lu._Until);

            Database.ModifyData(sSQL, par1, par2, par3);
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
                    case "From":
                        if (string.IsNullOrEmpty(_From))
                            error = "Dit is verplicht";
                        break;

                    case "Company":
                        if (string.IsNullOrEmpty(_Until))
                            error = "Dit is verplicht";
                        break;
                }
                return error;
            }
        }
    }
}
