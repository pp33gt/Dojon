using Dojon.Items;
using GameLib;
using System;
using System.Collections.Generic;

namespace Dojon.GameMap
{
    public abstract class Entity: IDrawable
    {
        public string Symbol { get; private set; }
        public virtual ConsoleColor Color { get; }
        public string Name { get; }

        public LimitedList<Item> BackPack { get; } = new LimitedList<Item>(2);

        public Entity(string symbol, ConsoleColor consoleColor, string name)
        { 
            Symbol = symbol;
            Color = consoleColor;
            Name = name;
        }

    }
}
