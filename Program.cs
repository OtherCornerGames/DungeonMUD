using System;
using System.Collections.Generic;
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
            game.BuildRooms();

            while(playing)
            {
                string userAction = game.GetUserInput().ToLower();
                Room nextRoom;
                game.CurrentRoom.Exits.TryGetValue(userAction, out nextRoom);

                if(nextRoom != null)
                {
                    game.CurrentRoom = nextRoom;
                    System.Console.WriteLine(game.CurrentRoom.Description);
                }
                else if(userAction == "q" || userAction == "quit")
                {
                    playing = false;
                }
                else{
                    System.Console.WriteLine("Cant go that way");
                }
            }
        }
    }
}
