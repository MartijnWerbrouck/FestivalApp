using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FestivalApp.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FestivalApp.ViewModel
{
    class TicketingPageVM : ObservableObject, IPage
    {
        public TicketingPageVM() {
            _tickettypes = TicketType.GetTicketTypes();
            _tickets = Ticket.GetTickets();
            Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "/Tickets");
        }

        public string Name {
            get {
                return "Ticketing";
            }
        }

        #region TicketTypes 

        private ObservableCollection<TicketType> _tickettypes;
        public ObservableCollection<TicketType> TicketTypes {
            get {
                return _tickettypes;
            }
            set {
                _tickettypes = value;
                OnPropertyChanged("TicketTypes");
            }
        }

        private TicketType _selectedTicketType;
        public TicketType SelectedTicketType {
            get {
                return _selectedTicketType;
            }
            set {
                _selectedTicketType = value;
                OnPropertyChanged("SelectedTicketType");
            }
        }

        public ICommand EditTicketTypeCommand {
            get {
                return new RelayCommand(EditTicketType);
            }
        }

        private void EditTicketType() {
            TicketType tt = new TicketType();

            tt.ID = _selectedTicketType.ID;
            tt.Name = _selectedTicketType.Name;
            tt.Price = _selectedTicketType.Price;
            tt.AvailableTickets = _selectedTicketType.AvailableTickets;

            TicketType.UpdateTicketType(tt);

            MessageBox.Show("De prijs en aantal voor " + _selectedTicketType.Name + " zijn bevestigd");
            OnPropertyChanged("TicketTypes");
        }

        #endregion

        #region Tickets

        private ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets {
            get {
                return _tickets;
            }
            set {
                _tickets = value;
                OnPropertyChanged("Tickets");
            }
        }

        private Ticket _selectedTicket;
        public Ticket SelectedTicket {
            get {
                return _selectedTicket;
            }
            set {
                _selectedTicket = value;
                OnPropertyChanged("SelectedTicket");
            }
        }

        private TicketType _selectedHolderTicketType;
        public TicketType SelectedHolderTicketType {
            get {
                return _selectedHolderTicketType;
            }
            set {
                _selectedHolderTicketType = value;
                OnPropertyChanged("SelectedHolderTicketType");
            }
        }

        public ICommand NewTicketCommand {
            get {
                return new RelayCommand(NewTicket);
            }
        }
        public ICommand BeschikbaarheidCommand {
            get {
                return new RelayCommand(CheckBeschikbaarheid);
            }
        }
        public ICommand ExportFiletoWordCommand {
            get {
                return new RelayCommand(ExportFiletoWord);
            }
        }

        private void NewTicket() {
            Ticket t = new Ticket();

            t.Ticketholder = _selectedTicket.Ticketholder;
            t.TicketholderEmail = _selectedTicket.TicketholderEmail;
            t.TicketType = _selectedHolderTicketType;
            t.Amount = _selectedTicket.Amount;

            Ticket.InsertTicket(t);

            MessageBox.Show("De reservatie voor klant is bevestigd.");
            OnPropertyChanged("Tickets");
        }
        private void CheckBeschikbaarheid() { 
            ObservableCollection<Ticket> lijst = Ticket.GetTickets();
            int aantal1 = TicketType.GetTicketByName("Combi").AvailableTickets;
            int aantal2 = TicketType.GetTicketByName("Vrijdag").AvailableTickets;
            int aantal3 = TicketType.GetTicketByName("Zaterdag").AvailableTickets;
            int aantal4 = TicketType.GetTicketByName("Zondag").AvailableTickets;

            foreach (Ticket t in lijst) {
                if (t.TicketType.Name == "Combi") {
                    aantal1 = aantal1 - t.Amount;
                }

                if (t.TicketType.Name == "Vrijdag") {
                    aantal2 = aantal2 - t.Amount;
                }

                if (t.TicketType.Name == "Zaterdag") {
                    aantal3 = aantal3 - t.Amount;
                }

                if (t.TicketType.Name == "Zondag") {
                    aantal4 = aantal4 - t.Amount;
                }
            }

            MessageBox.Show("Er zijn nog " + aantal1 + " combi tickets, " + aantal2 + " vrijdag tickets, " + aantal3 + " zaterdag tickets, " + aantal4 + " zondag tickets");
        }
        private void ExportFiletoWord() {
            Ticket t = _selectedTicket;
            
            for (int i = 0; i < t.Amount; i++) { 
            string filename = i + "_" + t.Ticketholder + ".docx";
            File.Copy("Template.docx", filename, true);
            WordprocessingDocument newdoc = WordprocessingDocument.Open(filename, true);
            IDictionary<String, BookmarkStart> bookmarks = new Dictionary<String, BookmarkStart>();
            foreach (BookmarkStart bms in newdoc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()) {
                bookmarks[bms.Name] = bms;
            }

            bookmarks["Naam"].Parent.InsertAfter<Run>(new Run(new Text(t.Ticketholder)), bookmarks["Naam"]);
            bookmarks["Email"].Parent.InsertAfter<Run>(new Run(new Text(t.TicketholderEmail)), bookmarks["Email"]);
            bookmarks["Aantal"].Parent.InsertAfter<Run>(new Run(new Text(t.Amount.ToString())), bookmarks["Aantal"]);

            Run run = new Run(new Text(i + t.Ticketholder));
            RunProperties prop = new RunProperties();
            RunFonts font = new RunFonts() { Ascii = "Free 3 of 9 Extended", HighAnsi = "Free 3 of 9 Extended" };
            FontSize size = new FontSize() { Val = "50" };

            prop.Append(font);
            prop.Append(size);
            run.PrependChild<RunProperties>(prop);

            bookmarks["Barcode"].Parent.InsertAfter<Run>(run, bookmarks["Barcode"]);

            newdoc.Close();
            }
            MessageBox.Show("De tickets werden afgeprint");
        }

        #endregion 
    }
}
