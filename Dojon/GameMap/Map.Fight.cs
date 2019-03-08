using Dojon.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojon.GameMap
{
    partial class Map
    {
        private void Fight(Cell opponentCell)
        {
            Creature Opponent = opponentCell.Creature;

            var random = new Random();
            var heroHit = random.Next(6) + Hero.CurrentDamage;
            var opponentHit = random.Next(6) + Opponent.CurrentDamage;

            GameIoC.MessagesHandler.AddMessage($"Opponent: {opponentCell.Creature.Name} HP:{opponentCell.Creature.Health} Damage:({opponentCell.Creature.CurrentDamage})");

            if (heroHit > opponentHit)
            {
                GameIoC.MessagesHandler.AddMessage($"{Hero.Name} attacks {opponentCell.Creature.Name} for {heroHit} damage");

                Opponent.Health -= heroHit;
            }
            else
            {
                GameIoC.MessagesHandler.AddMessage($"{opponentCell.Creature.Name} attacks {Hero.Name} for {opponentHit} damage");
                GameIoC.Speech.Say("Ouch!");

                Hero.Health -= opponentHit;
            }
        }
    }
}
