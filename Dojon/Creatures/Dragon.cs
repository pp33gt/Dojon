using Dojon.GameMap;
using System;

namespace Dojon.Creatures
{
    public class Dragon: Monster
    {
        public Dragon(string symbol, int health, int damage, ConsoleColor color) : base(symbol, color, "Dragon", health, damage)
        {
        }
    }
}
