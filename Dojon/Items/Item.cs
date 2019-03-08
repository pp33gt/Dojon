using Dojon.GameMap;
using System;

namespace Dojon.Items
{
    public class Item: Entity, IDrawable
    {
        public int Damage { get; }

        public Item(string symbol, ConsoleColor consoleColor, string name, int damage) : base(symbol, consoleColor, name)
        {
            Damage = damage;
        }

        public static Item Sock()
        {
            return new Item("s", ConsoleColor.Yellow, "Dirty sock", 0);
        }

        public static Item Coin()
        {
            return new Item("c", ConsoleColor.Yellow, "Coin", 0);
        }

        public static Item Gem()
        {
            return new Item("g", ConsoleColor.Yellow, "Gem", 0);
        }

        public static Potion PotionOfHealing()
        {
            return new Potion("p", ConsoleColor.Yellow, "PotionOfHealing", 0);
        }
    }
}