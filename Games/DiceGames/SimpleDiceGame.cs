using System.Collections.Generic;
using System.Linq;
using Logging;
using System;

namespace Games.DiceGames
{
    /// <summary>
    /// This is an internal class that extends the DiceGame abstract class and molds a playable game
    /// </summary>
    class SimpleDiceGame : DiceGame
    {
        private Dictionary<Player, int> playerScores;
        private Random randomGenerator = new Random();
        /// <summary>
        /// This constructor initializes all the fields and properties that are used during the game. It uses the base class logic and adds new specific logic
        /// This game uses standard dices with 6 faces
        /// </summary>
        /// <param name="players">The list of players that are in the game</param>
        public SimpleDiceGame(List<Player> players) : base(players)
        {
            DiceList.Add(new Dice(6,randomGenerator));
            DiceList.Add(new Dice(6,randomGenerator));
            playerScores = new Dictionary<Player, int>();
            foreach(Player player in PlayerList)
            {
                playerScores.Add(player, 0);
            }
        }
        /// <summary>
        /// This represents the game algorithm 
        /// The rule is simple: every player rolls the dices and the one with the biggest score wins. If there are multiple players with the same score, the process is repeated until there's only one winner
        /// </summary>
        /// <returns></returns>
        public override GameResults PlayGame()
        {
            
            bool stillPlaying = true;
            GameResults results = new GameResults();
            int maxScore = 0;
            while (stillPlaying)
            {
                maxScore = 0;
                foreach (Player player in PlayerList)
                {
                    playerScores[player] = 0;
                    foreach (Dice dice in DiceList)
                    {
                        dice.RollDice();
                        playerScores[player] += dice.UpFace;
                    }
                    Logger.Instance.LogInfoMessage(string.Format("The player {0} rolled {1}", player.PlayerName,playerScores[player].ToString()));
                    maxScore = maxScore < playerScores[player] ? playerScores[player] : maxScore;
                }
                var playersWithMaxScore = playerScores.Where(x => x.Value == maxScore).ToList();
                if(playersWithMaxScore.Count==1)
                {
                    stillPlaying = false;
                }
            }
            
            results.GameWinner = playerScores.Where(x=>x.Value==maxScore).Select(x=>x.Key).FirstOrDefault();
            Logger.Instance.LogInfoMessage(string.Format("The winner is {0}", results.GameWinner.PlayerName));
            return results;
        }
    }
}
