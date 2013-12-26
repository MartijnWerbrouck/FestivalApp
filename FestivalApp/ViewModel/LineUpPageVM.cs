using FestivalApp.Model;
using FestivalApp.View;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
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
    class LineUpPageVM: ObservableObject, IPage
    {
        public string Name {
            get {
                return "Line Up";
            }
        }

        public LineUpPageVM() {
            //STAGE
            _stages = Stage.GetStages();

            //BANDS
            _bands = Band.GetBands();

            //LINEUP 
            _lineup = LineUp.GetLineUp();
            _selectedDate = DateTime.Now;

            //GENRE
            _genres = Genre.GetGenres();
        }

        #region Stages tabblad

        private ObservableCollection<Stage> _stages;
        public ObservableCollection<Stage> Stages {
            get {
                return _stages;
            }
            set {
                _stages = value;
                OnPropertyChanged("Stages");
            }
        }

        private Stage _stageSelected;
        public Stage SelectedStage {
            get {
                return _stageSelected;
            }
            set {
                _stageSelected = value;
                OnPropertyChanged("SelectedStage");
            }
        }

        public ICommand NewStageCommand {
            get {
                return new RelayCommand(NewStage);
            }
        }
        public ICommand EditStageCommand {
            get {
                return new RelayCommand(EditStage);
            }
        }
        public ICommand DeleteStageCommand {
            get {
                return new RelayCommand(DeleteStage);
            }
        }

        private void NewStage() {
            Stage s = new Stage();

            s.Name = _stageSelected.Name;

            Stage.AddStage(s);

            MessageBox.Show("Er werd een nieuwe stage toegevoegd");
        }
        private void EditStage() {
            Stage s = new Stage();

            s.ID = _stageSelected.ID;
            s.Name = _stageSelected.Name;

            Stage.ModifyStage(s);

            MessageBox.Show("Er werd een stage gewijzigd");
        } 
        private void DeleteStage() {
            Stage s = new Stage();
            s = _stageSelected;

            Stage.DeleteStage(s);

            MessageBox.Show("De stage werd succesvol verwijderd.");
        }
        
        #endregion

        #region Bands tabblad

        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Bands {
            get {
                return _bands;
            }
            set {
                _bands = value;
                OnPropertyChanged("Bands");
            }
        }

        private Band _bandSelected;
        public Band SelectedBand {
            get {
                return _bandSelected;
            }
            set {
                _bandSelected = value;
                OnPropertyChanged("SelectedBand");
            }
        }

        private String _pictureSelected;
        public String SelectedPicture {
            get {
                return _pictureSelected;
            }
            set {
                _pictureSelected = value;
                OnPropertyChanged("SelectedPicture");
            }
        }

        private Genre _selectedBandGenre;
        public Genre SelectedBandGenre {
            get {
                return _selectedBandGenre;
            }
            set {
                _selectedBandGenre = value;
                OnPropertyChanged("SelectedBandGenre");
            }
        }

        private ObservableCollection<Genre> _selectedBandGenres = new ObservableCollection<Genre>();
        public ObservableCollection<Genre> SelectedBandGenres {
            get {
                return _selectedBandGenres;
            }
            set {
                _selectedBandGenres = value;
                OnPropertyChanged("SelectedBandGenres");
            }
        }

        public ICommand SelectPictureCommand {
            get {
                return new RelayCommand(SelectPicture);
            }
        }
        public ICommand NewBandCommand {
            get {
                return new RelayCommand(NewBand);
            }
        }
        public ICommand EditBandCommand {
            get {
                return new RelayCommand(EditBand);
            }
        }
        public ICommand DeleteBandCommand {
            get {
                return new RelayCommand(DeleteBand);
            }
        }
        public ICommand SelectGenresCommand {
            get {
                return new RelayCommand(SelectGenres);
            }
        }
        public ICommand CommitGenresCommand {
            get {
                return new RelayCommand(CommitGenres);
            }
        }

        private void SelectPicture() {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Pictures (.jpg)|*.jpg|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            bool? userClickedOK = openFileDialog.ShowDialog();

            if (userClickedOK == true) {
                _pictureSelected = openFileDialog.SafeFileName;
                OnPropertyChanged("SelectedPicture");
            }
        }
        private void NewBand() {
            if (_pictureSelected != null) {
                Band b = new Band();

                b.Name = _bandSelected.Name;
                b.Picture = _pictureSelected;
                b.Description = _bandSelected.Description;
                b.Twitter = _bandSelected.Twitter;
                b.Facebook = _bandSelected.Facebook;

                Band.AddBand(b);

                MessageBox.Show("Er is een nieuwe band toegevoegd");
            }
            else {
                MessageBox.Show("Gelieve een afbeelding te selecteren");
            }
        }
        private void EditBand() {
            Band b = new Band();

            b.ID = _bandSelected.ID;
            b.Name = _bandSelected.Name;
            if (_pictureSelected != null) {
                b.Picture = _pictureSelected;
            }
            else {
                b.Picture = _bandSelected.Picture;
            }
            b.Description = _bandSelected.Description;
            b.Twitter = _bandSelected.Twitter;
            b.Facebook = _bandSelected.Facebook;

            Band.ModifyBand(b);

            MessageBox.Show("De band werd gewijzigd");
        }
        private void DeleteBand() {
            Band b = new Band();

            b.Name = _bandSelected.Name;

            Band.DeleteBand(b);

            MessageBox.Show("De band werd verwijderd");
        }
        private void SelectGenres() {
            ObservableCollection<Genre> lijst = _selectedBandGenres;
            if (_selectedBandGenre != null) {
                lijst.Add(_selectedBandGenre);
            }
            else {
                MessageBox.Show("Gelieve een genre te selecteren");
            }
        }
        private void CommitGenres() {
            if (_bandSelected != null) {
                Band b = new Band();
                ObservableCollection<Genre> lijst = _selectedBandGenres;

                b.ID = _bandSelected.ID;

                Band.CommitGenresToBand(b, lijst);

                MessageBox.Show("De genres werden gekoppeld aan de door u gekozen band");
                
                _selectedBandGenres.Clear();
                OnPropertyChanged("SelectedBandGenres");
            }
            else {
                MessageBox.Show("Gelieve een band te selecteren");
            }
        }

        #endregion

        #region LineUp Tabblad 
        
        private ObservableCollection<LineUp> _lineup;
        public ObservableCollection<LineUp> LineUps {
            get {
                return _lineup;
            }
            set {
                _lineup = value;
                OnPropertyChanged("LineUps");
            }
        }

        private LineUp _selectedLineUp;
        public LineUp SelectedLineUp {
            get {
                return _selectedLineUp;
            }
            set {
                _selectedLineUp = value;
                OnPropertyChanged("SelectedLineUp");
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate {
            get {
                return _selectedDate;
            }
            set {
                _selectedDate = value;
                OnPropertyChanged("SelectedDate");
            }
        }

        private Band _selectedLineUpBand;
        public Band SelectedLineUpBand {
            get {
                return _selectedLineUpBand;
            }
            set {
                _selectedLineUpBand = value;
                OnPropertyChanged("SelectedLineUpBand");
            }
        }

        private Stage _selectedLineUpStage;
        public Stage SelectedLineUpStage {
            get {
                return _selectedLineUpStage;
            }
            set {
                _selectedLineUpStage = value;
                OnPropertyChanged("SelectedLineUpStage");
            }
        }

        public ICommand ShowDetailsCommand {
            get {
                return new RelayCommand(ShowDetails);
            }
        }
        public ICommand NewLineUpCommand {
            get {
                return new RelayCommand(NewLineUp);
            }
        }
        public ICommand EditLineUpCommand {
            get {
                return new RelayCommand(EditLineUp);
            }
        }
        public ICommand DeleteLineUpCommand { 
            get { 
                return new RelayCommand(DeleteLineUp);
            }
        }

        private void ShowDetails() {
            String name = _selectedLineUpBand.Name;
            String pic = _selectedLineUpBand.Picture;
            String desc = _selectedLineUpBand.Description;
            String twit = _selectedLineUpBand.Twitter;
            String face = _selectedLineUpBand.Facebook;
            ObservableCollection<Genre> genres = _selectedLineUpBand.Genres;
            List<String> lijst = new List<String>();

            foreach(Genre g in genres) {
                String n = g.Name;
                lijst.Add(n);
            }

            var detailsBand = new DetailBand();
            detailsBand.DetailsInvullen(name, pic, desc, twit, face, lijst);
            detailsBand.Show();
        }
        private void NewLineUp() {
            if (_selectedLineUpBand != null) {
                if (_selectedLineUpStage != null) {
                    LineUp lu = new LineUp();

                    lu.Date = _selectedDate;
                    lu.From = _selectedLineUp.From;
                    lu.Until = _selectedLineUp.Until;
                    lu.Band = _selectedLineUpBand;
                    lu.Stage = _selectedLineUpStage;

                    LineUp.AddLineUp(lu);

                    MessageBox.Show("Er werd een nieuwe line up toegevoegd");
                }
                else {
                    MessageBox.Show("Gelieve een Stage te selecteren");
                }
            }
            else {
                MessageBox.Show("Gelieve een Band te selecteren");
            }
        }
        private void EditLineUp() {
            LineUp lu = new LineUp();

            lu.ID = _selectedLineUp.ID;
            lu.Date = _selectedLineUp.Date;
            lu.From = _selectedLineUp.From;
            lu.Until = _selectedLineUp.Until;
            if (_selectedLineUpBand != null) {
                lu.Band = _selectedLineUpBand;
            }
            else {
                lu.Band = _selectedLineUp.Band;
            }
            if (_selectedLineUpStage != null) {
                lu.Stage = _selectedLineUpStage;
            }
            else {
                lu.Stage = _selectedLineUp.Stage;
            }

            LineUp.ModifyLineUp(lu);

            MessageBox.Show("De line up werd gewijzigd");
        }
        private void DeleteLineUp() {
            LineUp lu = new LineUp();

            lu.Date = _selectedLineUp.Date;
            lu.From = _selectedLineUp.From;
            lu.Until = _selectedLineUp.Until;

            LineUp.DeleteLineUp(lu);

            MessageBox.Show("De lineup werd succesvol verwijderd");
        }

        #endregion

        #region Genres tabblad

        private ObservableCollection<Genre> _genres;
        public ObservableCollection<Genre> Genres {
            get {
                return _genres;
            }
            set {
                _genres = value;
                OnPropertyChanged("Genres");
            }
        }

        private Genre _genreSelected;
        public Genre SelectedGenre {
            get {
                return _genreSelected;
            }
            set {
                _genreSelected = value;
                OnPropertyChanged("SelectedGenre");
            }
        }

        public ICommand NewGenreCommand {
            get {
                return new RelayCommand(NewGenre);
            }
        }
        public ICommand EditGenreCommand {
            get {
                return new RelayCommand(EditGenre);
            }
        }
        public ICommand DeleteGenreCommand {
            get {
                return new RelayCommand(DeleteGenre);
            }
        }

        private void NewGenre() {
            Genre g = new Genre();

            g.Name = _genreSelected.Name;

            Genre.AddGenre(g);

            MessageBox.Show("Er werd een nieuw genre toegevoegd");
        }
        private void EditGenre() {
            Genre g = new Genre();

            g.ID = _genreSelected.ID;
            g.Name = _genreSelected.Name;

            Genre.ModifyGenre(g);

            MessageBox.Show("Er werd een genre gewijzigd");
        }
        private void DeleteGenre() {
            Genre g = new Genre();
            g = _genreSelected;

            Genre.DeleteGenre(g);

            MessageBox.Show("Het genre werd succesvol verwijderd");
        }

        #endregion
    }
}
