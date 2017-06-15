using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void StartGame()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n-----------DungeonZ-----------\n");
      Console.WriteLine("Welcome to the warrens of Emirkol the Chaotic!\n");
      Console.ForegroundColor = ConsoleColor.Yellow;
    }
    public void Reset()
    {

    }

    public void Setup()
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}