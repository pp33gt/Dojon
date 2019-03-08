using System;
using System.Collections.Generic;
using System.Linq;
using Dojon.Creatures;
using Dojon.Items;

namespace Dojon.GameMap
{
    public class Cell: IDrawable
    {
        public Creature Creature { get; set; }
        /*
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        private Creature creature;
        public Creature Creature {
            get => creature;
            set {
                if (value != null)
                {
                    value.X = this.X;
                    value.Y = this.Y;
                }
                creature = value;
            }
        }
         */

        public Stack<Item> Items { get; set; } = new Stack<Item>();  //List<Item>

        public string Symbol => ".";

        public ConsoleColor Color => Creature?.Color ?? Items.FirstOrDefault()?.Color ?? ConsoleColor.White;

        //public ConsoleColor Color => ConsoleColor.DarkGray; <--master
    }
}
