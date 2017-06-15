using System;
using CastleGrimtol.Game;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game.Game game = new Game.Game();
            Boolean playing = true;

            game.Setup();


            while(playing)
            {
                string userAction = game.GetUserInput();
            }
        }
    }
}
