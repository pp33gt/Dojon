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
        private static MessageHandler messagesHandler = null;

        public static MessageHandler MessagesHandler
        {
            get
            {
                if (messagesHandler == null)
                {
                    messagesHandler = new MessageHandler();
                }
                return messagesHandler;
            }
        }
    }
}
