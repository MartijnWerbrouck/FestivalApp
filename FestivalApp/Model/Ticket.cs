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
    class Ticket : IDataErrorInfo
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

        private String _Ticketholder;
        public String Ticketholder {
            get {
                return _Ticketholder;
            }
            set {
                _Ticketholder = value;
            }
        }

        private String _TicketholderEmail;
        public String TicketholderEmail {
            get {
                return _TicketholderEmail;
            }
            set {
                _TicketholderEmail = value;
            }
        }

        private TicketType _TicketType;
        public TicketType TicketType {
            get {
                return _TicketType;
            }
            set {
                _TicketType = value;
            }
        }
        
        [Required]
        [Range(0, Int32.MaxValue)]
        private int _Amount;
        public int Amount {
            get {
                return _Amount;
            }
            set {
                _Amount = value;
            }
        }

        //Ophalen uit de database
        public static ObservableCollection<Ticket> GetTickets() {
            ObservableCollection<Ticket> lijst = new ObservableCollection<Ticket>();
            
            String sSQL = "SELECT * FROM Ticket";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read()) {
                Ticket t = new Ticket();

                t._ID = reader["TicketID"].ToString();
                t._Ticketholder = reader["Ticketholder"].ToString();
                t._TicketholderEmail = reader["TicketholderEmail"].ToString();
                t._TicketType = TicketType.GetTicketTypeByID(reader["TicketTypeID"].ToString());
                t._Amount = Convert.ToInt32(reader["Amount"].ToString());

                lijst.Add(t);
            }
            return lijst;
        }

        //Insert in de database
        public static void InsertTicket(Ticket t) {
            String sSQL = "INSERT INTO Ticket (Ticketholder, TicketholderEmail, TicketTypeID, Amount) VALUES (@Ticketholder, @TicketholderEmail, @TicketTypeID, @Amount)";

            DbParameter par1 = Database.AddParameter("@Ticketholder", t._Ticketholder);
            DbParameter par2 = Database.AddParameter("@TicketholderEmail", t._TicketholderEmail);
            DbParameter par3 = Database.AddParameter("@TicketTypeID", Convert.ToInt32(t._TicketType.ID));
            DbParameter par4 = Database.AddParameter("@Amount", Convert.ToInt32(t._Amount));

            Database.ModifyData(sSQL, par1, par2, par3, par4);
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
                    case "Ticketholder":
                        if (string.IsNullOrEmpty(_Ticketholder))
                            error = "De naam is verplicht";
                        break;

                    case "TicketholderEmail":
                        if (string.IsNullOrEmpty(_TicketholderEmail))
                            error = "Het emailadres is verplicht";
                        break;
                }
                return error;
            }
        }
    }
}
