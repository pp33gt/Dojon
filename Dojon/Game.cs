using Dojon.Creatures;
using Dojon.GameControl;
using Dojon.GameMap;
using Dojon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dojon
{
    internal class Game
    {
        private Dictionary<ConsoleKey, Action> actions;

        public static bool Acted { get; set; }

        Action Quit = new Action(() => { GameIoC.GameKeyboardHandler.Stop(); });
        Action PickupItem = new Action(() => { GameIoC.Map.PickupItem(GameIoC.Map.Hero); });
        Action UseItem = new Action(() => { GameIoC.Map.UseItem(); });
        Action DropItem = new Action(() => { Acted = GameIoC.Map.DropItem(GameIoC.Map.Hero); });
        Action MoveNorth = new Action(() => { Acted = GameIoC.Map.Move(GameIoC.Map.Hero, Direction.North); });
        Action MoveSouth = new Action(() => { Acted = GameIoC.Map.Move(GameIoC.Map.Hero, Direction.South); });
        Action MoveEast = new Action( () => { Acted = GameIoC.Map.Move(GameIoC.Map.Hero, Direction.East); } );
        Action MoveWest = new Action(() => { Acted = GameIoC.Map.Move(GameIoC.Map.Hero, Direction.West); });

        internal Game(IConsoleInteraction console)
        {
            actions = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.Q, Quit },
                { ConsoleKey.X, Quit },
                { ConsoleKey.UpArrow, MoveNorth },
                { ConsoleKey.DownArrow, MoveSouth },
                { ConsoleKey.LeftArrow, MoveWest },
                { ConsoleKey.RightArrow, MoveEast },
                { ConsoleKey.D, DropItem },
                { ConsoleKey.P, PickupItem },
                { ConsoleKey.U, UseItem }
            };

            GameIoC.Init(console);
        }

        internal void Run()
        {
            //GameIoC.StopWatch.Start();
            DrawMap();
            //GameIoC.StopWatch.Stop();
            //GameIoC.MessagesHandler.AddMessage(GameRepo.StopWatch.ToString());

            GameIoC.GameKeyboardHandler.GameKeyCommandEvent += OnKeyCommandHandler;
            GameIoC.GameKeyboardHandler.Start();
            GameIoC.Panel.GameOver();
        }

        private void OnKeyCommandHandler(object sender, GameKeyboardHandlerEventArgs e)
        {
            Acted = false;
            var key = e.ConsoleKeyInfo.Key;
            if (actions.ContainsKey(key))
            {
                var action = actions[key];
                action();
            }

            if (!Acted) GameIoC.MessagesHandler.AddMessage("No action");

            if (GameIoC.Map.Hero.IsDead)
            {
                GameIoC.GameKeyboardHandler.Stop();
            }

            GameIoC.Map.RemoveDeadMonsters();
            DrawMap();
        }

        private void DrawMap()
        {
            GameIoC.Console.Clear();
            var Cells = GameIoC.Map.ToArray();

            for (int y = 0; y < GameIoC.Map.Height; y++)
            {
                for (int x = 0; x < GameIoC.Map.Width; x++)
                {
                    var cell = Cells[x, y];

                    var drawable = cell.Creature ?? cell.Items.FirstOrDefault() ?? (IDrawable)cell;
                    GameIoC.Console.ForegroundColor(drawable.Color);

                    GameIoC.Console.Write(drawable.Symbol[0]);
                }
                GameIoC.Console.WriteLine(string.Empty);
            }
            GameIoC.Panel.DrawStats();
        }
        
    }
}