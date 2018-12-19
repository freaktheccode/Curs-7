using Games;
using Games.DiceGames;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfNew.Models
{
    /// <summary>
    /// The class is a model. 
    /// This class is an implementation of the application's domain model that includes a data model along with business and validation logic. 
    /// This class implementing INotifyPropertyChanged interface.
    /// </summary>
    public sealed class GamesModel: INotifyPropertyChanged
    {
        #region Members
        private int playersNumber = 2;
        private ObservableCollection<DiceGameTypes> comboBoxContent;
        private DiceGameTypes comboBoxSelectedItem;
        private bool enableStartButton = true;
        private ObservableCollection<string> gameResults = new ObservableCollection<string>();
        #endregion
        #region Constructor
        public GamesModel()
        {
            comboBoxContent = new ObservableCollection<DiceGameTypes>();
            foreach (DiceGameTypes diceGame in Enum.GetValues(typeof(DiceGameTypes)))
            {
                comboBoxContent.Add(diceGame);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// This property set and get the number of players
        /// if value is equal with 2 game can start.
        /// </summary>
        public int PlayersNumber
        {
            get
            {
                return playersNumber;
            }
            set
            {
                if (value != playersNumber)
                {
                    playersNumber = value;
                    EnableStartButton = value < 2 ? false : true;                 
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This property set and get the winner player.
        /// </summary>
        public ObservableCollection<string> Results
        {
            get
            {
                return gameResults;
            }
            set
            {
                if (value != gameResults)
                {
                    gameResults = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This property set and get type of games.
        /// This property has a private set.
        /// </summary>
        public ObservableCollection<DiceGameTypes> ComboBoxContent
        {
            get
            {
                return comboBoxContent;
            }
            private set
            {
                if (value != comboBoxContent)
                {
                    comboBoxContent = value;   
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This property enable or not the start button.
        /// </summary>
        public bool EnableStartButton
        {
            get
            {
                return enableStartButton;
            }
            set
            {
                if (value != enableStartButton)
                {
                    enableStartButton = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// This property set and get type of game that user want to play.
        /// </summary>
        public DiceGameTypes ComboBoxSelectedItem
        {
            get
            {
                return comboBoxSelectedItem;
            }
            set
            {
                if (value != comboBoxSelectedItem)
                {
                    comboBoxSelectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Member
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called to fire event when ever property changes.
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
