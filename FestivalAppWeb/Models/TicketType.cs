using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FestivalApp.Model
{
    class TicketType
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

        private Double _Price;
        public Double Price {
            get {
                return _Price;
            }
            set {
                _Price = value;
            }
        }

        private int _AvailableTickets;
        public int AvailableTickets {
            get {
                return _AvailableTickets;
            }
            set {
                _AvailableTickets = value;
            }
        }
    }
}
