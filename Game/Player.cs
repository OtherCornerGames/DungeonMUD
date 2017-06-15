using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Player : IPlayer
  {
    public string CharacterName;
    public int Score { get; set; }
    public List<Item> Inventory { get; set; }
    public Player()
    {
      CharacterName = NameCharacter();
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
  }
}