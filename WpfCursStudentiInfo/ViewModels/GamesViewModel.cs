using Games;
using Games.DiceGames;
using Logging;
using MVVMApplication.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfNew.Models;

namespace WpfNew.ViewModels
{
    /// <summary>
    /// The class is a view model. 
    /// This class acts as an intermediary between the view and the model
    /// and is responsible for handling the view logic.
    /// This class implementing INotifyPropertyChanged interface.
    /// </summary>
    public sealed class GamesViewModel : INotifyPropertyChanged
    {
        #region Members
        private GamesModel gamesModel = null;
        List<Player> playerList = new List<Player>();
        IGame myDiceGame = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Public constructor. 
        /// Set the GamesModel property.
        /// </summary>
        public GamesViewModel()
        {
            GamesModel = new GamesModel();
        }
        #endregion

        #region Properties
        /// <summary>
        /// This class get and set the GamesModel object.
        /// </summary>
        public GamesModel GamesModel
        {
            get
            {
                return gamesModel;
            }
            set
            {
                if (value != gamesModel)
                {
                    gamesModel = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commmands
        /// <summary>
        /// Return the command that want to be executed.
        /// </summary>
        public RelayCommand StartGame
        {
            get
            {
                return new RelayCommand(StartButton, true);
            }
        }
        #endregion

        #region Actions
        /// <summary>
        /// Action to be executed when you press the start button.
        /// </summary>
        public void StartButton()
        {          
            try
            {
                Logger.Instance.InitializeLogger("c:/log.csv", System.Diagnostics.TraceLevel.Verbose, WriterTypes.CsvWriter);
                Logger.Instance.LogInfoMessage("Game started");
                GamesModel.Results.Clear();
                playerList = new List<Player>();
                for (int i = 1; i <= GamesModel.PlayersNumber; i++)
                {
                    playerList.Add( new Player(string.Format("Player{0}",i.ToString())));
                }
                myDiceGame = new DiceGameFactory().GetDiceGame(GamesModel.ComboBoxSelectedItem, playerList);
                GameResults myResult = myDiceGame.PlayGame();
                GamesModel.Results.Add(string.Format("The winner is {0}", myResult.GameWinner.PlayerName));
            }
            catch (Exception ex)
            {
                Logger.Instance.LogErrorMessage(ex.Message);
            }
            finally
            {
                Logger.Instance.LogInfoMessage("Game ended");
            }
        }
        #endregion

        #region INotifyPropertyChanged Member
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called to fire event whenever a property changes.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
