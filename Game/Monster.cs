using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
 public class Monster
  {
    public string Name { get; set; }
    public int Attack{ get; set; }
    public int Health{ get; set; }
    public Monster(string name, int attack, int health)
    {
      Name = name;
      Attack = attack;
      Health = health;
    }
  }
}