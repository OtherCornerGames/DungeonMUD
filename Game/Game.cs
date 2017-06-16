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
      Help();
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
    public void Help()
    {
      System.Console.WriteLine("Valid actions are direction number of the exit. EX: east 1, east 2.\nLook, which allows you to search the room for treasure, but you may disturb something...\nHelp, which displays this help list.\nTake, which takes an item. EX Take Gold.\n Quit, leaves the game.\n");
    }
    public void BuildRooms()
    {
      
      Room room1 = new Room("Room 1", "Spirals of green stones cover the floor, A circle of tall stones stands in the east side of the room. Exits: East 1, East 2, South 1, South 2.\n");
      Room room2 = new Room("Room 2", "An altar of evil sits in the center of the room. You notice a pile of iron spikes lies in the north side of the room. Exits: West 1, East 1, East 2.\n");
      Room room3 = new Room("Room 3", "Someone has scrawled \"Run Away!\" in goblin runes on the north wall, Several pieces of trash are also strewn about the room. Exits: West 1, East 1, East 2, East 3, South 1.\n");
      Room room4 = new Room("Room 4", "You immediately notice the ceiling is covered in cob webs. The words \"Don't Sleep\" are etched into the East wall. Exits: West 1, West 2, East 1, South 1.\n");
      Room room5 = new Room("Room 5", "A chute descends from the room into a midden chamber below, it is too small to fit through, not that you want to. The scent of urine fills the room. Exits: East 1, South 1.\n");
      Room room6 = new Room("Room 6", "This room lacks any discernable features. Exits: West 1, East 1.\n");
      Room room7 = new Room("Room 7", "A group of draconic faces have been carved into the South wall. Near your feet you notice the words \"Kunarv was here\". Exits: West 1, South 1.\n");
      Room room8 = new Room("Room 8", "Some small piles of stone rubble ornament the floor. Exits: North 1, West 1, East 1, East 2, South 1, South 2.\n");
      Room room9 = new Room("Room 9", "The floor is smooth, but the walls of this room appear to be less worked and rough. Exits: East 1, East 2.\n");
      Room room10 = new Room("Room 10", "Several iron cages are scattered throughout the room. A pile of torn paper lies in the north-west corner of the room. Exits: West 1, East 1.\n");
      Room room11= new Room("Room 11", "Dark moss partially covers the walls, even the air feels rather damp. Exits: North 1, North 2, West 1, West 2.\n");
      Room room12 = new Room("Room 12", "Dimly lit, and longer than most of the rooms, this one almost appears to be a slightly larger hallway. Exits: West 1, West 2, South 1.\n");
      Room room13 = new Room("Room 13", "Corpses, too badly decayed to discern what they once were, lay randomly about the room. Exits: North 1, East 1, South 1, West 1.\n");
      Room room14 = new Room("Room 14", "A tile labyrinth covers the floor, intricately and deliberatly installed. A shatter sword lies in ruin in the north-west corner. Exits: North 1.\n");
      Room room15 = new Room("Room 15", "The floor is covered in mud. Several sundered shields lay scattered about. Exits: East 1, East 2, South 1.\n");
      Room room16 = new Room("Room 16", "A set of frightening demonic war masks hang on the east wall. A rotting carpet and a small table sit in the west side of the room. Exits: North 1, North 2.\n");
      Room room17 = new Room("Room 17", "Someone has scrawled \"Twist the cog to reset the trap\" in dwarvish runes on the north wall. A corroded chain lies in the northwest corner of the room. Exits: North 1, West 1, South 1.\n");
      Room room18 = new Room("Room 18", "A magical statue in the south-west corner of the room answers questions with insults, A group of demonic faces have been carved into the east wall. Exits: West 1, South 1.\n");
      Room room19 = new Room("Room 19", "Empty, other than small splinters of wood. Exits: North 1, West 1, East 1.\n");
      Room room20 = new Room("Room 20", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");
      Room room2 = new Room("Room 2", "\n");

      room1.AddDoor("east 1", room2);
      room1.AddDoor("east 2", room7);
      room1.AddDoor("south 1", room16);
      room1.AddDoor("south 2", room9);
      room2.AddDoor("West", room1);
      room2.AddDoor("East 1", room3);
      room2.AddDoor("East 2", room24);
      CurrentRoom = room1;
    }
  }
}