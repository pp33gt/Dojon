using System;
using Dojon.Items;
using System.Collections.Generic;
using Dojon.GameMap;
using System.Linq;

namespace Dojon.Creatures
{
    public abstract class Creature : Entity, IDrawable
    {
        public Creature(string symbol,
            ConsoleColor color,
            string name,
            int health, 
            int damage) : base(symbol, color, name)
        {
            initalDamage = damage;
            Health = health;
        }

        public bool IsDead => Health <= 0;

        /*
        public int X { get; internal set; }
        public int Y { get; internal set; }

        public int Health { get; set; } = 1;
        public int Damage { get; set; }
        */

        public int Health { get; set; }

        protected int initalDamage = 0;
        public virtual int CurrentDamage
        {
            get
            {
                int currentDamage = initalDamage;
                BackPack.ToList().ForEach(item => currentDamage = item.Damage > currentDamage ? item.Damage : currentDamage);
                return currentDamage;
            }
        }

        public override ConsoleColor Color => IsDead ? ConsoleColor.DarkGray : base.Color;

        /*
        private Action<string> addMessage = s => { };
        // Fattigmanshändelsehanterare
        // private List<Action<string>> onMessage = new List<Action<string>>();

        internal void SetMessageHandler(Action<string> addMessage)
        {
            this.addMessage = addMessage;
        }
        */


        /* master        

        public void Fight(Creature target)
        {
            if (target.IsDead) return;

            target.Health -= Damage;
            addMessage($"The {Name} attacks the {target.Name} for {Damage} damage");
            if (target.IsDead) {
                addMessage($"The {target.Name} is dead");
                return;
            }

            Health -= target.Damage;
            addMessage($"The {target.Name} attacks the {Name} for {target.Damage} damage");
            if (IsDead)
            {
                addMessage($"The {Name} is dead");
                return;
            }
        }
         */
    }
}
