using System.Collections.Generic;
using System.Linq;
using Dojon.Creatures;
using Dojon.Items;

namespace Dojon.GameMap
{

    public partial class Map
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Hero Hero { get; private set; }

        public Cell[,] Cells { get; internal set; }

        private Dictionary<Creature, Position> Positions = new Dictionary<Creature, Position>();

        public List<Monster> Monsters => Cells
            .OfType<Cell>()
            .Select(c => c.Creature)
            .OfType<Monster>()
            .Where(a => a.IsDead)
            .ToList();


        internal Map(int width, int height)
        {
            Init(width, height);
        }

        private void Init(int width, int height)
        {
            Width = width;
            Height = height;
            CreateMap();

            var heroPos = new Position(1, 1);
            Hero = new Hero(50, 1, System.ConsoleColor.Cyan);
            SetCreaturePosition(Hero, null, new Position(1, 1));

            var ogre = new Ogre("o", System.ConsoleColor.Red, 10, 2);
            AddCreature(ogre, new Position(5, 5));

            var dragon = new Dragon("D", 100, 4, System.ConsoleColor.Red);
            AddCreature(dragon, new Position(7, 19));

            SetItemPosition(new Knife(5), 2, 5);
            SetItemPosition(Item.Sock(), 2, 5);

            SetItemPosition(new DoubleAxe(20), 5, 5);

            SetItemPosition(Item.PotionOfHealing(), 6, 6);
        }

        private void AddCreature(Creature creature, Position position)
        {
            SetCreaturePosition(creature, null, position);
        }

        public Cell Cell(int x, int y)
        {
            return Cells[x, y];
        }

        public Cell[,] ToArray()
        {
            return Cells;
        }

        private void SetCreaturePosition(Creature creature, Position oldPosition, Position newPosition)
        {
            if (oldPosition != null)
            {
                SetCreaturePosition(null, oldPosition);
            }

            SetCreaturePosition(creature, newPosition);
            if (Positions.ContainsKey(creature))
            {
                Positions[creature] = newPosition;
            }
            else
            {
                Positions.Add(creature, newPosition);
            }
        }

        private void SetCreaturePosition(Creature creature, Position newPosition)
        {
            Cell(newPosition.X, newPosition.Y).Creature = creature;
        }

        private void SetItemPosition(Item entity, int x, int y)
        {
            Cell(x, y).Items.Push(entity);
        }

        private void CreateMap()
        {
            Cells = new Cell[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var cell = new Cell();
                    Cells[x, y] = cell;
                }
            }
        }

        public void RemoveDeadMonsters()
        {
            foreach (var creature in Monsters)
            {
                if(creature.IsDead)
                {
                    if(Positions.ContainsKey(creature))
                    {
                        var position = Positions[creature];
                        var cell = Cell(position.X, position.Y);
                        cell.Creature = null;
                    }
                }
            }
        }

        public void UseItem()
        {
            var hero = GameIoC.Map.Hero;
            var posistion = Positions[hero];
            var cell = Cell(posistion.X, posistion.Y);

            var item = cell.Items.Peek();

            if (item is IUsable usable)
            {
                usable.Use(hero);
                cell.Items.Pop();
            }
        }

        /* master
        private Action<string> addMessage = s => { };
        internal void SetMessageHandler(Action<string> addMessage)
        {
            this.addMessage = addMessage;
        }
        */

    }
}

