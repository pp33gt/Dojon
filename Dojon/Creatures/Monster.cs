using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojon.Creatures
{
    public class Monster : Creature
    {
        public Monster(string symbol, ConsoleColor color, string name, int health, int damage) : base(symbol, color, name, health, damage)
        {
        }
    }
}
