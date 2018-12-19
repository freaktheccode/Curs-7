using System;
using System.Collections.Generic;
using Logging;
namespace Games.DiceGames
{
    /// <summary>
    /// basic game where the first player that reaches 100 wins
    /// </summary>
    class FirstTo100 : DiceGame
    {
        private Dictionary<Player, int> playerScores;
        private Random randomGenerator = new Random();
        /// <summary>
        /// Public constructor that initializes the player, dice and score lists for the game
        /// </summary>
        /// <param name="players"></param>
        public FirstTo100(List<Player> players) : base(players)
        {
            DiceList.Add(new Dice(6, randomGenerator));
            DiceList.Add(new Dice(6, randomGenerator));
            playerScores = new Dictionary<Player, int>();
            foreach (Player player in PlayerList)
            {
                playerScores.Add(player, 0);
            }
        }
        /// <summary>
        /// Method called for playing the game
        /// </summary>
        /// <returns></returns>
        public override GameResults PlayGame()
        {
            bool stillPlaying = true;
            GameResults results = new GameResults();
            while (stillPlaying)
            {
                foreach(Player player in PlayerList)
                {
                    foreach(Dice dice in DiceList)
                    {
                        dice.RollDice();
                        playerScores[player] += dice.UpFace;
                    }
                    Logger.Instance.LogInfoMessage(string.Format("{0} has the following score: {1}", player.PlayerName, playerScores[player].ToString()));
                    if(playerScores[player]>=100)
                    {
                        results.GameWinner = player;
                        results.GameWinner.PlayerRecord = playerScores[player];
                        stillPlaying = false;
                        break;
                    }
                }
            }
            Logger.Instance.LogInfoMessage(string.Format("The winner is {0} with a score of {1} points", results.GameWinner.PlayerName, results.GameWinner.PlayerRecord));
            return results;
        }
    }
}
