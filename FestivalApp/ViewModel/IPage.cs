using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.ViewModel
{
    //elke viewmodel-klasse zal deze interface MOETEN implementeren
    //zo kan ik later een lijst van objecten van klassen gaan bijhouden waarvan 
    //de klasse deze interface implementeert. Deze lijst zit in de klassa ApplicationVM
    interface IPage
    {
        //één property in steken. Elke klasse moet deze property gaan uitwerken.
        string Name { get; }
    }
}
