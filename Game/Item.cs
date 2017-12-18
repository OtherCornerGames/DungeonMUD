using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int Attack{ get; set; }
    public int Health{ get; set; }
    public string Type { get; set; }
    public Item(string name, string description, string type, int attack, int health)
    {
      Name = name;
      Description = description;
      Type = type;
      Attack = attack;
      Health = health;
    }
  }
}