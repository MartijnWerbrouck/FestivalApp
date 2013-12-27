using DBHelper;
using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalAppWeb.Models.DAL
{
    public class BandRepository
    {
        public static List<Band> GetBands() {
            List<Band> lijst = new List<Band>();
            string sSQL = "SELECT * FROM [Band]";

            DbDataReader reader = Database.GetData(sSQL, null);

            if (reader != null && reader.HasRows) {
                while (reader.Read()) {
                    Band aNieuw = new Band();

                    aNieuw.ID = reader["BandID"].ToString();
                    aNieuw.Name = reader["Name"].ToString();
                    aNieuw.Picture = reader["Picture"].ToString();
                    aNieuw.Description = reader["Description"].ToString();
                    aNieuw.Twitter = reader["Twitter"].ToString();
                    aNieuw.Facebook = reader["Facebook"].ToString();

                    lijst.Add(aNieuw);         
                }
            }
            return lijst;
        }

        public static Band GetBand(int index) {
            return GetBands()[index];
        }
    }
}