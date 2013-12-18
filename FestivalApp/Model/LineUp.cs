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
    class LineUp
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

        public static ObservableCollection<LineUp> GetLineUpDay1() {
            Festival festival = Festival.GetFestival();
            DateTime date = festival.StartDate;
            ObservableCollection<LineUp> lijst = new ObservableCollection<LineUp>();

            String sSQL = "SELECT * FROM LineUp WHERE Date = @Date ORDER BY [From] ASC";
            DbParameter par1 = Database.AddParameter("@Date", date);
            DbDataReader reader = Database.GetData(sSQL, par1);

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

        public static ObservableCollection<LineUp> GetLineUpDay2() {
            Festival festival = Festival.GetFestival();
            DateTime date = festival.EndDate.Subtract(TimeSpan.FromDays(1));
            ObservableCollection<LineUp> lijst = new ObservableCollection<LineUp>();

            String sSQL = "SELECT * FROM LineUp WHERE Date = @Date ORDER BY [From] ASC";
            DbParameter par1 = Database.AddParameter("@Date", date);
            DbDataReader reader = Database.GetData(sSQL, par1);

            while (reader.Read())
            {
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

        public static ObservableCollection<LineUp> GetLineUpDay3() {
            Festival festival = Festival.GetFestival();
            DateTime date = festival.EndDate;
            ObservableCollection<LineUp> lijst = new ObservableCollection<LineUp>();

            String sSQL = "SELECT * FROM LineUp WHERE Date = @Date ORDER BY [From] ASC";
            DbParameter par1 = Database.AddParameter("@Date", date);
            DbDataReader reader = Database.GetData(sSQL, par1);

            while (reader.Read())
            {
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

        //SelectedItem => Stage 
        public static ObservableCollection<LineUp> GetLineUp1FromStage(Stage stage) {
            ObservableCollection<LineUp> lijst = LineUp.GetLineUpDay1();
            ObservableCollection<LineUp> lijst2 = new ObservableCollection<LineUp>();
            foreach (LineUp lineup in lijst) {
                if (lineup.Stage == stage) {
                    lijst2.Add(lineup);
                }
            }
            return lijst2;
        }

        public static ObservableCollection<LineUp> GetLineUp2FromStage(Stage stage)
        {
            ObservableCollection<LineUp> lijst = LineUp.GetLineUpDay2();
            ObservableCollection<LineUp> lijst2 = new ObservableCollection<LineUp>();
            foreach (LineUp lineup in lijst)
            {
                if (lineup.Stage == stage)
                {
                    lijst2.Add(lineup);
                }
            }
            return lijst2;
        }

        public static ObservableCollection<LineUp> GetLineUp3FromStage(Stage stage)
        {
            ObservableCollection<LineUp> lijst = LineUp.GetLineUpDay3();
            ObservableCollection<LineUp> lijst2 = new ObservableCollection<LineUp>();
            foreach (LineUp lineup in lijst)
            {
                if (lineup.Stage == stage)
                {
                    lijst2.Add(lineup);
                }
            }
            return lijst2;
        }

        public override string ToString() {
            return this._Band.Name + " speelt van " + this._From + " tot " + this._Until + " op " + this._Stage.Name;
        }
    }
}
