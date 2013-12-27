using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
    }
}
