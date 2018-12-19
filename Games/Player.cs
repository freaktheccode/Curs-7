namespace Games
{
    /// <summary>
    /// This class represents a player and can be modified to add new player features as needed.
    /// </summary>
    public class Player
    {
        public string PlayerName { get; set; }
        public int PlayerRecord { get; set; }
        public Player(string playerName)
        {
            PlayerName = playerName;
            PlayerRecord = 0;
        }
    }
}
