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
    class Festival
    {
        private DateTime _StartDate;

        public DateTime StartDate {
            get {
                return _StartDate;
            }
            set {
                _StartDate = value;
            }
        }
        
        private DateTime _EndDate;

        public DateTime EndDate {
            get {
                return _EndDate;
            }
            set {
                _EndDate = value;
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

        //Ophalen uit de database
        public static Festival GetFestival() {
            Festival festival = new Festival();

            String sSQL = "SELECT * FROM Festival";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read()) {
                Festival aNieuw = new Festival();

                aNieuw._Name = reader["Name"].ToString();
                aNieuw._StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                aNieuw._EndDate = Convert.ToDateTime(reader["EndDate"].ToString());

                festival = aNieuw;
            }
            return festival;
        }

        //Festivaleigenschappen aanpassen
        public static void SaveFestival(Festival editFestival) {
            String sSQL = "UPDATE Festival SET Name = @Name, StartDate = @StartDate, EndDate = @EndDate";

            DbParameter par1 = Database.AddParameter("@Name", editFestival._Name);
            DbParameter par2 = Database.AddParameter("@StartDate", editFestival._StartDate);
            DbParameter par3 = Database.AddParameter("@EndDate", editFestival._EndDate);

            Database.ModifyData(sSQL, par1, par2, par3);
        }
    }
}
