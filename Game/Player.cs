using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Player : IPlayer
  {
    public string CharacterName;
    public int Score { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Attack { get; set; }
    public List<Item> Inventory { get; set; }
    public Player()
    {
      CharacterName = NameCharacter();
      Score = 0;
      Health = 100;
      MaxHealth = 100;
      Attack = 1;
      Inventory = new List<Item>();
    }
    public string NameCharacter()
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("What would you like your character's name to be?\n");
      Console.ForegroundColor = ConsoleColor.Red;
      string CharacterName = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("\nGreat! Your character is now named " + CharacterName + "\n");
      Console.ForegroundColor = ConsoleColor.White;
      return CharacterName;
    }
    public void ShowInventory(Player player)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      System.Console.WriteLine("\nYour inventory:\n");
      for (int i = 0; i < player.Inventory.Count; i++)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine($"{player.Inventory[i].Name}");
        Console.ForegroundColor = ConsoleColor.Magenta;        
        System.Console.WriteLine($"{player.Inventory[i].Description}\n");
      }
        Console.ForegroundColor = ConsoleColor.White;
    }
  }
}