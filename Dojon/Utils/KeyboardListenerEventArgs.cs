using System;

namespace Dojon.Utils
{
    internal class KeyboardListenerEventArgs : EventArgs
    {
        public ConsoleKeyInfo ConsoleKey { get; internal set; }
        public KeyboardListenerEventArgs(ConsoleKeyInfo ConsoleKey)
        {
            this.ConsoleKey = ConsoleKey;
        }
    }
}
