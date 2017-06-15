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
    public void BuildRooms()
    {
      Room room1 = new Room("Room 1", "a room");
      Room room2 = new Room("room 2", " a room as well.");

      room1.AddRoom("east", room2);
      room2.AddRoom("west", room1);
      CurrentRoom = room1;
    }
  }
}