using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FestivalApp.ViewModel
{
    class ApplicationVM : ObservableObject
    {
        public ApplicationVM()
        {
            _pages = new ObservableCollection<IPage>();

            //hieronder voegen we al een eerste IPage-object toe
            //bij nieuwe Pages moet deze lijst aangevuld worden met telkens
            //de bijhorende viewmodel-klasse
            _pages.Add(new HomePageVM());
            _pages.Add(new LineUpPageVM());
            _pages.Add(new ContactPageVM());
            _pages.Add(new TicketingPageVM());

            //default zetten we de CurrentPage in op eerste IPage (Hier HomePage)
            _currentPage = Pages[0];
        }

        private IPage _currentPage;
        public IPage CurrentPage
        {
            get
            {
                return _currentPage;        //huidige page (dat nu getoond wordt) 
            }
            set
            {
                _currentPage = value;
                //ik maak aan de buitenwereld bekend dat er de property "CurrentPage"
                //gewijzigd is. Eventuele controls die er aan gebind zijn, worden nu
                //aangepast. 
                OnPropertyChanged("CurrentPage");
            }
        }

        private ObservableCollection<IPage> _pages;

        public ObservableCollection<IPage> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
                OnPropertyChanged("Pages");
            }
        }

        //onderstaande komen uit de cursus!
        //deze 2 methodes worden gebruikt door de buttons (op mainwindow.xaml)
        //en kan het juiste commando activeren. Hier is dat het wisselen van Page.
        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }

        private void ChangePage(IPage page)
        {
            CurrentPage = page;
        }
    }
}
