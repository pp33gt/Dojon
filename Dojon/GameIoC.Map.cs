using Dojon.GameMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojon
{
    internal partial class GameIoC
    {
        internal static Map map = null;

        public static Map Map
        {
            get
            {
                if (map == null)
                {
                    map = new Map(10, 20);
                }
                return map;
            }

        }
    }
}
