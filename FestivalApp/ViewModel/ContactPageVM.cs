using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.ViewModel
{
    class ContactPageVM : ObservableObject, IPage
    {
        public string Name {
            get {
                return "Contact"; 
            }
        }
    }
}
