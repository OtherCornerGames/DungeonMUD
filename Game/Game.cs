using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Game : IGame
  {
    public Boolean Playing { get; set; }
    public Room CurrentRoom { get; set; }
    public List<Room> Rooms { get; set; }
    public Player CurrentPlayer { get; set; }
    public void Setup()
    {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("\n-----------DungeonZ-----------\n");
      Console.WriteLine("Welcome to the warrens of Emirkol the Chaotic!\n");
      Console.ForegroundColor = ConsoleColor.White;
      CurrentPlayer = new Player();
      Rooms = new List<Room>();
      Help();
    }
    public string GetUserInput()
    {
      System.Console.WriteLine("What would you like to do?\n");
      string input = Console.ReadLine();
      return input;
    }
    public void Reset()
    {
      Playing = true;

      Setup();
      BuildRooms();
    }
    public void UseItem(string itemName)
    {
      //not needed but just for fun to identify items
      string MagicOrb = "orb";
      string SwordOfLOSE = "sword";
      string EmirkolTaco = "taco";

      Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);

      if (item != null && item.Name.ToLower() == MagicOrb)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("\nA loud bang and a brilliant flash! You implode and then immediately reassemble, dazed, but seemingly whole. You realize you have found the way in...\n");
        Console.ForegroundColor = ConsoleColor.White;
        CurrentRoom = Rooms[1];
      }
      if (item != null && item.Name.ToLower() == SwordOfLOSE)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nYou swing the sword around with elegance. You feel like a true hero...as you go to sheathe the sword, you slip, fall, and end up using your chest as a sheathe...a rather ineffective sheathe. Everything goes dim.....\n");
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("YOU LOSE!\n");
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("Do you want to play again?Y/N\n");
        string input = Console.ReadLine().ToLower();
        if (input == "y")
        {
          Reset();
        }
        if (input == "n")
        {
          Playing = false;
        }
      }
      if (item != null && item.Name.ToLower() == EmirkolTaco)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("\nAs you begin to eat the taco he screams \"NOOOO I am Emirkol the Chaotic, all should fear me!\", you finish your tasty meal and realize, you have just vanquished Emirkol.\n");
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("YOU WIN!\n");
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("Do you want to play again?Y/N\n");
        string input = Console.ReadLine().ToLower();
        if (input == "y")
        {
          Reset();
        }
        if (input == "n")
        {
          Playing = false;
        }
      }
      if(item == null)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("\nInsufficient IQ allocation. Try something that makes more sense.\n");
        Console.ForegroundColor = ConsoleColor.White;
      }
    }
    public void TakeItem(string itemName)
    {
      Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
      if (item != null)
      {
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.Inventory.Add(item);
        CurrentPlayer.ShowInventory(CurrentPlayer);
      }
    }
    public Boolean Quit(Boolean playing)
    {
      System.Console.WriteLine("Leave the game? All progress will be lost. Y/N");
      string input = Console.ReadLine().ToLower();
      if (input == "y" || input == "yes")
      {
        return playing = false;
      }
      else
      {
        System.Console.WriteLine("OK");
        return playing = true;
      }
    }
    public void Look(Room room)
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      System.Console.WriteLine($"{room.Name}:\n{room.Description}\n");
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      System.Console.WriteLine("Items:\n");
      for (int i = 0; i < room.Items.Count; i++)
      {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine($"{room.Items[i].Name}");
        Console.ForegroundColor = ConsoleColor.Magenta;
        System.Console.WriteLine($"{room.Items[i].Description}\n");
      }
      Console.ForegroundColor = ConsoleColor.Blue;
      System.Console.WriteLine($"Score: {CurrentPlayer.Score}\n");
      Console.ForegroundColor = ConsoleColor.White;
    }
    public void Help()
    {
      System.Console.WriteLine("Valid actions are:\nMovement: First letter of the direction and number of the exit.\nEX: Exits: East 1 = e1.\nLOOK or l: which allows you to search the room for treasure, but you may disturb something...\nHELP or h: which displays this help list.\nTAKE or t: which takes an item and adds it to your inventory. EX: Take sword\nINVENTORY or i: Views the items in your inventory.\nUSE or u: uses an item. EX: use sword\nQUIT or q: leaves the game.\n");
    }
    public void BuildRooms()
    {
      Room room0 = new Room("Room 0", "A mishapen cavern mostly made of crude stonework, it does not appear to go anywhere...You start to regret ever trying to enter the Warrens. Exits: None, how did you get here?!");
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
      Room room11 = new Room("Room 11", "Dark moss partially covers the walls, even the air feels rather damp. Exits: North 1, North 2, West 1, West 2.\n");
      Room room12 = new Room("Room 12", "Dimly lit, and longer than most of the rooms, this one almost appears to be a slightly larger hallway. Exits: West 1, West 2, South 1.\n");
      Room room13 = new Room("Room 13", "Corpses, too badly decayed to discern what they once were, lay randomly about the room. Exits: North 1, East 1, South 1, West 1.\n");
      Room room14 = new Room("Room 14", "A tile labyrinth covers the floor, intricately and deliberatly installed. A shatter sword lies in ruin in the north-west corner. Exits: North 1.\n");
      Room room15 = new Room("Room 15", "The floor is covered in mud. Several sundered shields lay scattered about. Exits: East 1, East 2, South 1.\n");
      Room room16 = new Room("Room 16", "A set of frightening demonic war masks hang on the east wall. A rotting carpet and a small table sit in the west side of the room. Exits: North 1, North 2.\n");
      Room room17 = new Room("Room 17", "Someone has scrawled \"Twist the cog to reset the trap\" in dwarvish runes on the north wall. A corroded chain lies in the northwest corner of the room. Exits: North 1, West 1, South 1.\n");
      Room room18 = new Room("Room 18", "A magical statue in the south-west corner of the room answers questions with insults, A group of demonic faces have been carved into the east wall. Exits: West 1, South 1.\n");
      Room room19 = new Room("Room 19", "Empty, other than small splinters of wood. Exits: North 1, West 1, East 1.\n");
      Room room20 = new Room("Room 20", "A stone sarcophagus sits in the south-east corner of the room, A cold spot can be felt in the west side of the room. Exits: North 1, West 1, South 1, South 2.\n");
      Room room21 = new Room("Room 21", "A fountain of water sits against the west wall, The sound of drums fills the room. Exits: North 1, North 2.\n");
      Room room22 = new Room("Room 22", "Ugly paintings adorn the wall, the materials they are made out of is questionable. Exits: North 1, North 2, East 1, East 2, East 3.\n");
      Room room23 = new Room("Room 23", "A plain room, with a rather high ceiling. Exits: North 1, West 1, East 1, South 1.\n");
      Room room24 = new Room("Room 24", "Small ornamental tapestries decorate the walls in an unorganized manner. Exits: North 1, West 1, East 1.\n");
      Room room25 = new Room("Room 25", "The floor is flaked with odd spots of rust. Exits: North 1, East 1, East 2, South 1, South 2.\n");
      Room room26 = new Room("Room 26", "Spirals of red stones cover the floor, Someone has scrawled a crude drawing of a succubus on the west wall. Exits: North 1, West 1, West 2, East 1, East 2.\n");
      Room room27 = new Room("Room 27", "A torn paper reads, \"Has anyone seen my invisible cloak?\", Several pieces of rotten rope are scattered throughout the room. Exits: North 1, West 1, East 1, East 2, South 1, South 2.\n");
      Room room28 = new Room("Room 28", "A set of brittle and corroded armor leans against the east wall. Exits: West 1, West 2, South 1, South 2.\n");
      Room room29 = new Room("Room 29", "A ruined siege weapon sits in the north-east corner of the room, etchings read, \"The Legion of the Ring looted this place\" in orcish runes on the east wall. Exits: West 1, West 2, East 1, South 1.\n");
      Room room30 = new Room("Room 30", "Various torture devices are scattered throughout the room, strange writing covers most of the east wall. Exits: West 1, East 1, East 2, East 3, South 1, South 2.\n");
      Room room31 = new Room("Room 31", "A narrow shaft descends from the room into a natural cavern below, A toppled statue lies in the north side of the room. Exits: West 1, East 1, East 2, South 1.\n");
      Room room32 = new Room("Room 32", "A simple wooden table and stuffed beast sit in the south-east corner of the room, The ceiling is covered with bloodstains. Exits: North 1, West 1.\n");
      Room room33 = new Room("Room 33", "A small spring bubbles up from the north corner of the room making most of the floor slick. Exits: North 1, West 1, East 1, South 1.\n");
      Room room34 = new Room("Room 34", "An upright sarcophagus leans against the west wall. Exits: North 1, West 1, South 1.\n");
      Room room35 = new Room("Room 35", "The floor is covered in square tiles, alternating white and black, \"It's a trap\" is scribbled in draconic script on the west wall. Exits: North 1, West 1, South 1.\n");
      Room room36 = new Room("Room 36", "A set of demonic war masks hangs on the east wall, A large kiln and coal bin sit in the south side of the room. Exits: North 1, West 1, West 2, East 1.\n");
      Room room37 = new Room("Room 37", "This room once had severl wood and iron doors, all of them now completely smashed about the room. Exits: North 1, West 1, West 2.\n");
      Room room38 = new Room("Room 38", "A stair ascends to a very unstable wooden platform in the east side of the room, A set of demonic war masks hangs on the east wall. Exits: North 1, East 1, South 1.\n");
      Room room39 = new Room("Room 39", "Lit candles are scattered across the floor, Someone has scrawled an arcane symbol on the east wall. Exits: North 1.\n");
      Room room40 = new Room("Room 40", "The south and west walls have been engraved with incoherent labyrinths, A shallow pool of oil lies in the east side of the room. Exits: North 1, West 1.\n");

      AddRooms();
      BuildExits();
      BuildItems();

      void AddRooms()
      {
        Rooms.Add(room0);
        Rooms.Add(room1);
      }
      void BuildExits()
      {
        room1.AddDoor("e1", room2);
        room1.AddDoor("e2", room7);
        room1.AddDoor("s1", room16);
        room1.AddDoor("s2", room9);
        room2.AddDoor("w1", room1);
        room2.AddDoor("e1", room3);
        room2.AddDoor("e2", room24);
        room3.AddDoor("w1", room2);
        room3.AddDoor("e1", room4);
        room3.AddDoor("e2", room6);
        room3.AddDoor("e3", room8);
        room3.AddDoor("s1", room14);
        room4.AddDoor("w1", room3);
        room4.AddDoor("w2", room6);
        room4.AddDoor("s1", room8);
        room4.AddDoor("e1", room8);
        room5.AddDoor("e1", room11);
        room5.AddDoor("s1", room11);
        room6.AddDoor("w1", room3);
        room6.AddDoor("e1", room4);
        room7.AddDoor("w1", room1);
        room7.AddDoor("s1", room17);
        room8.AddDoor("n1", room4);
        room8.AddDoor("w1", room3);
        room8.AddDoor("e1", room4);
        room8.AddDoor("e2", room10);
        room8.AddDoor("s1", room13);
        room8.AddDoor("s2", room13);
        room9.AddDoor("e1", room1);
        room9.AddDoor("e2", room12);
        room10.AddDoor("w1", room8);
        room10.AddDoor("e1", room11);
        room11.AddDoor("n1", room5);
        room11.AddDoor("n2", room5);
        room11.AddDoor("w1", room10);
        room11.AddDoor("w2", room15);
        room11.AddDoor("s1", room22);
        room12.AddDoor("w1", room9);
        room12.AddDoor("w2", room16);
        room12.AddDoor("s1", room19);
        room13.AddDoor("n1", room8);
        room13.AddDoor("e1", room8);
        room13.AddDoor("s1", room20);
        room13.AddDoor("w1", room21);
        room14.AddDoor("n1", room3);
        room15.AddDoor("e1", room11);
        room15.AddDoor("e2", room18);
        room15.AddDoor("s1", room22);
        room16.AddDoor("n1", room1);
        room16.AddDoor("n2", room12);
        room17.AddDoor("n1", room7);
        room17.AddDoor("w1", room19);
        room17.AddDoor("s1", room23);
        room18.AddDoor("e1", room15);
        room18.AddDoor("s1", room22);
        room19.AddDoor("n1", room12);
        room19.AddDoor("e1", room17);
        room19.AddDoor("w1", room25);
        room20.AddDoor("n1", room13);
        room20.AddDoor("s1", room26);
        room20.AddDoor("s2", room26);
        room20.AddDoor("w1", room21);
        room21.AddDoor("n1", room13);
        room21.AddDoor("n2", room20);
        room22.AddDoor("n1", room15);
        room22.AddDoor("n2", room18);
        room22.AddDoor("e1", room11);
        room22.AddDoor("e2", room37);
        room22.AddDoor("e3", room37);
        room23.AddDoor("n1", room17);
        room23.AddDoor("e1", room24);
        room23.AddDoor("w1", room25);
        room23.AddDoor("s1", room27);
        room24.AddDoor("n1", room2);
        room24.AddDoor("e1", room26);
        room24.AddDoor("w1", room23);
        room25.AddDoor("n1", room19);
        room25.AddDoor("e1", room23);
        room25.AddDoor("e2", room27);
        room25.AddDoor("s1", room31);
        room25.AddDoor("s2", room32);
        room26.AddDoor("n1", room20);
        room26.AddDoor("e1", room20);
        room26.AddDoor("e2", room28);
        room26.AddDoor("w1", room24);
        room26.AddDoor("w2", room27);
        room27.AddDoor("n1", room23);
        room27.AddDoor("e1", room26);
        room27.AddDoor("e2", room29);
        room27.AddDoor("s1", room31);
        room27.AddDoor("s2", room35);
        room27.AddDoor("w1", room25);
        room28.AddDoor("s1", room33);
        room28.AddDoor("s2", room34);
        room28.AddDoor("w1", room26);
        room28.AddDoor("w2", room30);
        room29.AddDoor("e1", room30);
        room29.AddDoor("s1", room39);
        room29.AddDoor("w1", room27);
        room29.AddDoor("w2", room35);
        room30.AddDoor("e1", room28);
        room30.AddDoor("e2", room33);
        room30.AddDoor("e3", room36);
        room30.AddDoor("s1", room40);
        room30.AddDoor("s2", room36);
        room30.AddDoor("w1", room29);
        room31.AddDoor("e1", room32);
        room31.AddDoor("e2", room27);
        room31.AddDoor("s1", room38);
        room31.AddDoor("w1", room25);
        room32.AddDoor("w1", room31);
        room32.AddDoor("n1", room25);
        room33.AddDoor("n1", room28);
        room33.AddDoor("e1", room34);
        room33.AddDoor("s1", room36);
        room33.AddDoor("w1", room30);
        room34.AddDoor("n1", room28);
        room34.AddDoor("w1", room33);
        room34.AddDoor("s1", room37);
        room35.AddDoor("n1", room29);
        room35.AddDoor("s1", room40);
        room35.AddDoor("w1", room38);
        room36.AddDoor("n1", room33);
        room36.AddDoor("e1", room37);
        room36.AddDoor("w1", room30);
        room36.AddDoor("w2", room30);
        room37.AddDoor("n1", room34);
        room37.AddDoor("w1", room36);
        room37.AddDoor("w2", room22);
        room38.AddDoor("n1", room31);
        room38.AddDoor("e1", room35);
        room38.AddDoor("s1", room35);
        room39.AddDoor("n1", room29);
        room40.AddDoor("n1", room30);
        room40.AddDoor("w1", room35);
      }

      void BuildItems()
      {
        Item rustySword = new Item("Sword", "A rusty old sword. Looks like it once was battle ready, but probably not anymore.");
        room0.Items.Add(rustySword);
        Item smallOrb = new Item("Orb", "A small orb, probably some kids marble, dang kids....always getting into chaos.");
        room0.Items.Add(smallOrb);
        Item taco = new Item("Taco", "A Delicious taco. Are you hungry?");
        room40.Items.Add(taco);
      }
      CurrentRoom = room0;
    }
  }
}