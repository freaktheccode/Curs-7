using System.Collections.Generic;

namespace Games
{
    /// <summary>
    /// This is the common interface for all the games
    /// This is exposed to outside assemblies 
    /// </summary>
    public interface IGame
    {
        List<Player> PlayerList { get; set; }
        GameResults PlayGame();
    }
}
