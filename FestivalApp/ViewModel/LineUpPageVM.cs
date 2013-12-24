using FestivalApp.Model;
using FestivalApp.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //LINE UP
            _lineup1 = LineUp.GetLineUpDay1();
            _lineup2 = LineUp.GetLineUpDay2();
            _lineup3 = LineUp.GetLineUpDay3();

            //STAGE
            _stages = Stage.GetStages();

            //GENRE
            _genres = Genre.GetGenres();
        }

        #region LineUp tabblad

        private ObservableCollection<LineUp> _lineup1;
        private ObservableCollection<LineUp> _lineup2;
        private ObservableCollection<LineUp> _lineup3;

        public ObservableCollection<LineUp> LineUps1 {
            get {
                return _lineup1;
            }
            set {
                _lineup1 = value;
                OnPropertyChanged("LineUps1");
            }
        }
        public ObservableCollection<LineUp> LineUps2 {
            get {
                return _lineup2;
            }
            set {
                _lineup2 = value;
                OnPropertyChanged("LineUps2");
            }
        }
        public ObservableCollection<LineUp> LineUps3 {
            get {
                return _lineup3;
            }
            set {
                _lineup3 = value;
                OnPropertyChanged("LineUps3");
            }
        }

        #endregion

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
