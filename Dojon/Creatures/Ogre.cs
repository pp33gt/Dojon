using Dojon.GameMap;
using System;

namespace Dojon.Creatures
{
    public class Ogre : Monster
    {
        public Ogre(string symbol, ConsoleColor color, int health, int damage) : base(symbol, color, "Ogre",  health, damage)
        {
        }
    }
}
