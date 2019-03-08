using System.Collections.Generic;
using Dojon.Creatures;
using Dojon.Items;

namespace Dojon.GameMap
{
    public partial class Map
    {
        public bool Move(Creature creature, Direction direction)
        {
            var heroPosition = Positions[creature];
            Position newPosition = null;
            switch (direction)
            {
                case Direction.North:
                    newPosition = new Position(heroPosition.X, heroPosition.Y - 1);
                    break;
                case Direction.South:
                    newPosition = new Position(heroPosition.X, heroPosition.Y + 1);
                    break;
                case Direction.East:
                    newPosition = new Position(heroPosition.X + 1, heroPosition.Y);
                    break;
                case Direction.West:
                    newPosition = new Position(heroPosition.X - 1, heroPosition.Y);
                    break;
            }

            if (newPosition != null)
            {
                return MoveCreature(Hero, newPosition);
            }
            return false;
        }

        private bool MoveCreature(Creature creature, Position newPosition)
        {
            bool moveSuccessful = TryMoveCreature(creature, newPosition, out Cell creatureCell);
            if (!moveSuccessful)
            {
                if (creatureCell != null)
                {
                    Fight(creatureCell);
                }
            }
            return moveSuccessful;
        }

        private bool TryMoveCreature(Creature creature, Position newPos, out Cell opponentCell)
        {
            opponentCell = null;
            var creaturePosition = Positions[creature];
            if (IsTryingToMoveOutSideMapBoundaries(creaturePosition, newPos))
            {
                return false;
            }

            var cellNew = Cell(newPos.X, newPos.Y);
            if (CellHasCreature(cellNew))
            {
                opponentCell = cellNew;
                return false;
            }

            MoveCreature(creaturePosition, newPos);
            return true;
        }

        private void MoveCreature(Position oldPos, Position newPos)
        {
            var cellOldPosition = Cell(oldPos.X, oldPos.Y);
            var cellNewPosition = Cell(newPos.X, newPos.Y);

            cellNewPosition.Creature = cellOldPosition.Creature;
            Positions[cellNewPosition.Creature] = newPos;
            cellOldPosition.Creature = null;
        }

        private bool IsTryingToMoveOutSideMapBoundaries(Position oldPos, Position newPos)
        {
            if (newPos.X < 0 || newPos.X >= Width)
            {
                return true;
            }

            if (newPos.Y < 0 || newPos.Y >= Height)
            {
                return true;
            }
            return false;
        }

        private bool CellHasCreature(Cell cell)
        {
            if (cell.Creature != null)
            {
                return true;
            }
            return false;
        }

        private bool CellHasItems(Cell cellNew)
        {
            if (cellNew.Items.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool DropItem(Creature creature)
        {
            var creaturePosition = Positions[creature];
            var oldCell = Cell(creaturePosition.X, creaturePosition.Y);

            if (Hero.BackPack.Count > 0)
            {
                var item = Hero.BackPack[Hero.BackPack.Count - 1];
                Hero.BackPack.Remove(item);
                oldCell.Items.Push(item);
            }
            return true;
        }

        public bool PickupItem(Creature creature)
        {
            if (creature.BackPack.IsFull)
            {
                GameIoC.MessagesHandler.AddMessage("Backpack is full");
                return false;
            }

            var creaturePosition = Positions[creature];
            var oldCell = Cell(creaturePosition.X, creaturePosition.Y);

            if (CellHasItems(oldCell))
            {
                var item = oldCell.Items.Pop();
                creature.BackPack.Add(item);
            }
            return true;
        }
    }
}
