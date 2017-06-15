using System;
using CastleGrimtol.Game;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game.Game game = new Game.Game();
            game.StartGame();
            Player player = new Player();
        }
    }
}
