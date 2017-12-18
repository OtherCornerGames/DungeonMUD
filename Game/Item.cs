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
    public Item(string name, string description, int attack, int health)
    {
      Name = name;
      Description = description;
      Attack = attack;
      Health = health;
    }
  }
}