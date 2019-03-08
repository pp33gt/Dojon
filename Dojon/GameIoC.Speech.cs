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
        private static AsyncSpeech speech = null;

        public static AsyncSpeech Speech
        {
            get
            {
                if (speech == null)
                {
                    speech = new AsyncSpeech();
                }
                return speech;
            }

        }
    }
}
