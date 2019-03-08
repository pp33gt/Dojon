using Dojon.GameMap;
using Dojon.Items;
using GameLib;
using System;

namespace Dojon.Creatures
{
    public class Hero : Creature
    {
        public Hero(int health, int damage, ConsoleColor color) : base("@", color, "Hero", health, damage)
        {
        }
    }
}
