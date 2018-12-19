using System.Collections.Generic;

namespace Games.DiceGames
{
    /// <summary>
    /// Abstract class that sets a pattern for all the dice games that will be implemented 
    /// </summary>
    abstract class DiceGame:IGame
    {
        public List<Dice> DiceList { get; private set; }
        public List<Player> PlayerList { get; set; }
        /// <summary>
        /// The constructor will initialize the player list and the dice list that will be used for playing the game
        /// </summary>
        /// <param name="players"></param>
        public DiceGame(List<Player> players)
        {
            PlayerList = players;
            DiceList = new List<Dice>();
        }
        /// <summary>
        /// This method will be implemented by every specific dice game based on their rules
        /// </summary>
        /// <returns></returns>
        public abstract GameResults PlayGame();
    }
}
