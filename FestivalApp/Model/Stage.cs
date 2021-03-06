﻿using _6Oefening1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalApp.Model
{
    class Stage : IDataErrorInfo
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

        //Ophalen uit de database
        public static ObservableCollection<Stage> GetStages() {
            ObservableCollection<Stage> lijst = new ObservableCollection<Stage>();

            String sSQL = "SELECT * FROM Stage";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read()) {
                Stage aNieuw = new Stage();
                aNieuw._ID = reader["StageID"].ToString();
                aNieuw._Name = reader["Name"].ToString();
                lijst.Add(aNieuw);
            }
            return lijst;
        }

        //Stage toevoegen aan database
        public static void AddStage(Stage stage) { 
            String sSQL = "INSERT INTO Stage (Name) VALUES (@Name)";

            DbParameter par1 = Database.AddParameter("@Name", stage._Name);

            Database.ModifyData(sSQL, par1);
        }

        //Stage aanpassen in database 
        public static void ModifyStage(Stage stage) { 
            String sSQL = "UPDATE Stage SET Name = @Name WHERE StageID = @StageID";

            DbParameter par1 = Database.AddParameter("@StageID", stage._ID);
            DbParameter par2 = Database.AddParameter("@Name", stage._Name);

            Database.ModifyData(sSQL, par1, par2);
        }

        //Stage verwijderen van database
        public static void DeleteStage(Stage stage) {
            String sSQL = "DELETE FROM Stage WHERE Name = @Name";

            DbParameter par1 = Database.AddParameter("@Name", stage._Name);

            Database.ModifyData(sSQL, par1);
        } 

        public override string ToString() {
            return this._Name;
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
                    case "Name":
                        if (string.IsNullOrEmpty(_Name))
                            error = "De naam is verplicht";
                        break;
                }
                return error;
            }
        }
    }
}
