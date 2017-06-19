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
      Console.ForegroundColor = ConsoleColor.Cyan;
      System.Console.WriteLine($"{game.CurrentRoom.Name}:\n{game.CurrentRoom.Description}");
      Console.ForegroundColor = ConsoleColor.White;

      while (playing)
      {
        string userAction = game.GetUserInput().ToLower();
        Room nextRoom;
        game.CurrentRoom.Exits.TryGetValue(userAction, out nextRoom);

        if (userAction == "l" || userAction == "look")
        {
          System.Console.WriteLine("\n");
          game.Look(game.CurrentRoom);
        }
        else if (userAction == "h" || userAction == "help")
        {
          game.Help();
        }
        else if (userAction == "t" || userAction == "take")
        {
          System.Console.WriteLine("Take");
        }
        else if (userAction == "i" || userAction == "inventory")
        {
          System.Console.WriteLine("Inventory");
        }
        else if (userAction == "q" || userAction == "quit")
        {
          playing = game.Quit(playing);
        }
        else if (nextRoom != null)
        {
          game.CurrentRoom = nextRoom;
          System.Console.WriteLine("\n");
          game.Look(game.CurrentRoom);
        }
        else
        {
          System.Console.WriteLine("After attempting...you realize this is not the action you wanted to take. You should try again.\n");
        }
      }
    }
  }
}
