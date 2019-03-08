using Dojon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojon.GameControl;

namespace Dojon
{
    internal partial class GameIoC
    {
        private static GameIoC Instance { get; set; }

        private static IConsoleInteraction ConsoleInstance { get; set; } = null;

        internal GameIoC()
        {
        }

        internal static IConsoleInteraction Console
        {
            get
            {
                if(ConsoleInstance == null)
                {
                    throw new Exception("Error: Call GameRepo Init() before usage.");
                }
                return ConsoleInstance;
            }
        }

        public static void Init(IConsoleInteraction console)
        {
            ConsoleInstance = console;

            GameKeyboardHandler = new GameKeyboardHandler(ConsoleInstance);
        }
    }
}
