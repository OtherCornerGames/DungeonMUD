using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Player : IPlayer
  {
    public int Score { get; set; }
    public List<Item> Inventory { get; set; }
  }
}