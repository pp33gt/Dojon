using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojon.Utils
{
    class MessageHandler
    {
        private List<string> Messages { get; } = new List<string>();

        public List<string> GetMessages()
        {
            return Messages;
        }

        public void ClearMessages()
        {
            Messages.Clear();
        }

        public Action<string> AddMessage = s => { };

        public MessageHandler()
        {
            AddMessage = Messages.Add;
        }
    }
}
