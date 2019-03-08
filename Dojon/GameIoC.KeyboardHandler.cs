using Dojon.GameControl;
using Dojon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojon
{
    internal partial class GameIoC
    {
        internal static GameKeyboardHandler GameKeyboardHandler { get; private set; }

        private static StopWatch stopWatch { get; set; } = null;
        public static StopWatch StopWatch
        {
            get
            {
                if (stopWatch == null)
                {
                    stopWatch = new StopWatch();
                }
                return stopWatch;
            }
        }

        private static Panel panel { get; set; } = null;
        public static Panel Panel
        {
            get
            {
                if (panel == null)
                {
                    panel = new Panel();
                }
                return panel;
            }
        }

    }
}
