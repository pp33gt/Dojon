using Dojon.GameMap;
using Dojon.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Dojon
{
    internal class Panel
    {
        internal Panel()
        {
        }

        public void DrawStats()
        {
            var hero = GameIoC.Map.Hero;

            string inventory = string.Empty;
            
            var separator = "";
            hero.BackPack.ToList().ForEach(item =>
            {
                inventory += separator + item.Name;
                separator = ",";
            });


            //foreach (var item in hero.BackPack)
            //{
            //    inventory += separator + item.Name;
            //    separator = ",";
            //}

            GameIoC.Console.WriteLine($"{hero.Name}: HP({hero.Health}) Damage:({hero.CurrentDamage}) Inventory: {inventory}");

            GameIoC.Console.WriteLine($"Monsters: {GameIoC.Map.Monsters.Count}");

            var messages = GameIoC.MessagesHandler.GetMessages();
            messages.ForEach(a => GameIoC.Console.WriteLine(a));
            GameIoC.MessagesHandler.ClearMessages();
        }

        public void GameOver()
        {
            GameIoC.Console.WriteLine("Game Over");
            GameIoC.Console.WriteLine("Hit any key to Exit ...");
            GameIoC.Console.ReadKey();
        }

    }
}
