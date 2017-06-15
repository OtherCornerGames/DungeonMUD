using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public void Setup()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n-----------DungeonZ-----------\n");
      Console.WriteLine("Welcome to the warrens of Emirkol the Chaotic!\n");
      Console.ForegroundColor = ConsoleColor.White;
      CurrentPlayer = new Player();
      CurrentRoom = new Room("Entry","You find yourself standing in the entry.");
      System.Console.WriteLine(CurrentRoom.Description);
    }
    public string GetUserInput()
    {
      System.Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine();
      return input;
    
    }
    public void Reset()
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}