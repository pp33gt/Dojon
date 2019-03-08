using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojon.Creatures;

namespace Dojon.Items
{
    public class Potion : Item, IUsable
    {
        public Potion(string symbol, ConsoleColor consoleColor, string name, int damage) : base(symbol, consoleColor, name, damage)
        {
        }

        public void Use(Creature creature)
        {
            creature.Health += 30;
        }

        internal static Potion HealthPotion()
        {
            return new Potion("p", ConsoleColor.Red, "Health Potion", 0);
        }
    }
}
