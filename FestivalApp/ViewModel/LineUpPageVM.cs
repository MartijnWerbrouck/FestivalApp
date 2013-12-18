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

        private ObservableCollection<LineUp> _lineup1Stage;
        private ObservableCollection<LineUp> _lineup2Stage;
        private ObservableCollection<LineUp> _lineup3Stage;

        public ObservableCollection<LineUp> LineUps1Stage{
            get {
                return _lineup1Stage;
            }
            set {
                _lineup1Stage = LineUp.GetLineUp1FromStage(_stageSelected);
                OnPropertyChanged("LineUps1Stage");
            }
        }

        public ObservableCollection<LineUp> LineUps2Stage {
            get {
                return _lineup2Stage;
            }
            set {
                _lineup2Stage = LineUp.GetLineUp2FromStage(_stageSelected);
                OnPropertyChanged("LineUps2Stage");
            }
        }

        public ObservableCollection<LineUp> LineUps3Stage {
            get {
                return _lineup3Stage;
            }
            set {
                _lineup3Stage = LineUp.GetLineUp3FromStage(_stageSelected);
                OnPropertyChanged("LineUps3Stage");
            }
        }
        
        //UPDATE
        public static void UpdateStage(Stage Stage) {
            Stage sStage = new Stage();

            sStage.ID = Stage.ID;
            sStage.Name = Stage.Name;
 
            Stage.ModifyStage(sStage);
        } 

        //DELETE 
        public ICommand DeleteStageCommand {
            get {
                return new RelayCommand(DeleteStage);
            }
        }

        private void DeleteStage() {
            Stage stage = new Stage();
            stage = SelectedStage;

            Stage.DeleteStage(stage);

            MessageBox.Show("De stage werd succesvol verwijderd.");
        }
        #endregion
    }
}
