using Logging;
using Games;
using Games.DiceGames;
using System.Collections.Generic;
namespace CursStudentiInfo
{
    /// <summary>
    /// Test application for our games and Logger
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main thread
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Logger.Instance.InitializeLogger("fileName.xml", System.Diagnostics.TraceLevel.Verbose, WriterTypes.XmlWriter);
            Logger.Instance.LogInfoMessage("Program started");
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            var playerList = new List<Player>() { player1, player2 };
            IGame myDiceGame = new DiceGameFactory().GetDiceGame(DiceGameTypes.HighestRoll, playerList);
            myDiceGame.PlayGame();
            Logger.Instance.LogInfoMessage("Program ended");
        }
    }
}
