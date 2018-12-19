using System;

namespace Games.DiceGames
{
    /// <summary>
    /// This class is the mold for a real life dice.
    /// </summary>
    class Dice
    {
        private Random rand;
        public readonly int  diceFaces;
        public int UpFace { get; private set; }
        /// <summary>
        /// This is the constructor
        /// </summary>
        /// <param name="faces">This is the number of faces for the dice being created and could be different based on what the game needs</param>
        /// <param name="randomGenerator">This is a random number generator that will be used when rolling the dice</param>
        public Dice(int faces, Random randomGenerator)
        {
            this.diceFaces = faces;
            rand = randomGenerator;
        }
        /// <summary>
        /// This method changes the UpFace of the dice with a random face number.
        /// </summary>
        public void RollDice()
        {           
            this.UpFace = rand.Next(1, this.diceFaces+1);            
        }
    }
}
