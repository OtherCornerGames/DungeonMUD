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
      game.Playing = true;
      game.Setup();
      game.BuildRooms();
      game.BuildMonsters();
      game.Loot();

      Console.ForegroundColor = ConsoleColor.Cyan;
      game.Look(game.CurrentRoom);
      Console.ForegroundColor = ConsoleColor.White;

      while (game.Playing)
      {
        string userChoice = game.GetUserInput().ToLower();
        string[] userAction = userChoice.Split(' ');

        if (userAction[0] == "l" || userAction[0] == "look")
        {
          System.Console.WriteLine("\n");
          game.Look(game.CurrentRoom);
        }
        else if (userAction[0] == "h" || userAction[0] == "help")
        {
          game.Help();
        }
        else if (userAction[0] == "t" || userAction[0] == "take" && userAction[1] != null)
        {
          game.TakeItem(userAction[1]);
        }
        else if (userAction[0] == "i" || userAction[0] == "inventory")
        {
          game.CurrentPlayer.ShowInventory(game.CurrentPlayer);
        }
        else if (userAction[0] == "q" || userAction[0] == "quit")
        {
          game.Playing = game.Quit(game.Playing);
        }
        else if (userAction[0] == "u" || userAction[0] == "use")
        {
          game.UseItem(userAction[1]);
          game.Look(game.CurrentRoom);
        }
        else if (userAction[0] == "g" || userAction[0] == "go" || userAction[0] == "m" || userAction[0] == "move")
        {
          string direction;
          if(userAction[1] == "north")
          {
            userAction[1] = "n";
          }
          else if(userAction[1] == "east")
          {
            userAction[1] = "e";
          }
          else if(userAction[1] == "south")
          {
            userAction[1] = "s";
          }
          else if(userAction[1] == "west")
          {
            userAction[1] = "w";
          }
          
          if(3 > userAction.Length)
          {
            Array.Resize(ref userAction, userAction.Length + 1);
            userAction[userAction.Length - 1] = "1";
          }

          direction = userAction[1] + userAction[2];
          Room nextRoom;
          game.CurrentRoom.Exits.TryGetValue(direction, out nextRoom);
          
          if (nextRoom == null){
            return;
          }

          Random rnd = new Random();
          int chance = rnd.Next(1, 101);
          if (chance > 50)
          {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\nYou are under Attack!\n");
            Console.ForegroundColor = ConsoleColor.White;
            game.Encounter();
          }
          if (!game.Playing)
          {
            System.Console.WriteLine("\nGoodBye");
          }
          else
          {
            game.CurrentRoom = nextRoom;
            game.CurrentPlayer.Score += 10;
            game.Look(game.CurrentRoom);
          }
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          System.Console.WriteLine("\nAfter attempting...you realize this is not the action you wanted to take. You should try again.\n");
          Console.ForegroundColor = ConsoleColor.White;
        }
      }
    }
  }
}
