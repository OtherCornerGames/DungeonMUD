using System;
using System.Collections.Generic;

namespace CastleGrimtol.Game
{
  public class Game : IGame
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

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