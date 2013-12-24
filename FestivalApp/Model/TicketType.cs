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
    class TicketType : IDataErrorInfo
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

        [Required]
        [Range(0.0, Double.MaxValue)]
        private Double _Price;
        public Double Price {
            get {
                return _Price;
            }
            set {
                _Price = value;
            }
        }

        [Required]
        [Range(0, Int32.MaxValue)]
        private int _AvailableTickets;
        public int AvailableTickets {
            get {
                return _AvailableTickets;
            }
            set {
                _AvailableTickets = value;
            }
        }

        //Ophalen uit de database
        public static ObservableCollection<TicketType> GetTicketTypes() {
            ObservableCollection<TicketType> lijst = new ObservableCollection<TicketType>();

            String sSQL = "SELECT * FROM TicketType";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read()) {
                TicketType tt = new TicketType();

                tt._ID = reader["TicketTypeID"].ToString();
                tt._Name = reader["Name"].ToString();
                tt._Price = Convert.ToDouble(reader["Price"].ToString());
                tt._AvailableTickets = Convert.ToInt32(reader["AvailableTickets"].ToString());

                lijst.Add(tt);
            }
            return lijst;
        }

        public static TicketType GetTicketTypeByID(String TicketTypeID) {
            ObservableCollection<TicketType> lijst = TicketType.GetTicketTypes();
            return lijst.Where(tt => tt._ID == TicketTypeID).SingleOrDefault();
        }

        public static TicketType GetTicketByName(String TicketName) {
            ObservableCollection<TicketType> lijst = TicketType.GetTicketTypes();
            return lijst.Where(tt => tt._Name == TicketName).SingleOrDefault();
        }

        //Update in de database 
        public static void UpdateTicketType(TicketType tt) {
            String sSQL = "UPDATE TicketType SET Name = @Name, Price = @Price, AvailableTickets = @AvailableTickets WHERE TicketTypeID = @ID";

            DbParameter par1 = Database.AddParameter("@Name", tt._Name);
            DbParameter par2 = Database.AddParameter("@Price", Convert.ToDouble(tt._Price));
            DbParameter par3 = Database.AddParameter("@AvailableTickets", Convert.ToInt32(tt._AvailableTickets));
            DbParameter par4 = Database.AddParameter("@ID", tt._ID);

            Database.ModifyData(sSQL, par1, par2, par3, par4);
        }

        public string Error {
            get {
                return "Model not valid";
            }
        }

        public string this[string columnName] {
            get {
                try {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) {
                        MemberName = columnName
                    });
                } catch (ValidationException ex) {
                    return ex.Message;
                }
                return String.Empty;
            }
        }
    }
}
