using System.Collections.Generic;

namespace Games.DiceGames
{
    /// <summary>
    /// This class uses the Factory pattern and it's main use is for returning a DiceGame instance based on the gameType parameter
    /// It hides the real game type and implementation from the user by returning an IGame derived object
    /// </summary>
    public class DiceGameFactory
    {
        /// <summary>
        /// This method returns a DiceGame derived instance based on the user's options
        /// </summary>
        /// <param name="gameType">Represents the game type wanted based on the options set in the DiceGameTypes enum</param>
        /// <param name="playerList">Represents the list of players that will play the game</param>
        /// <returns></returns>
        public IGame GetDiceGame(DiceGameTypes gameType, List<Player> playerList)
        {
            switch(gameType)
            {
                case DiceGameTypes.HighestRoll:
                    return new HighestRoll(playerList);
                case DiceGameTypes.FirstTo100:
                    return new FirstTo100(playerList);
                default:
                    return new HighestRoll(playerList);
            }
        }
    }
}
