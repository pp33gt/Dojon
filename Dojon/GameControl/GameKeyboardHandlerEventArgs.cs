using System;

namespace Dojon.GameControl
{
    internal class GameKeyboardHandlerEventArgs : EventArgs
    {
        public ConsoleKeyInfo ConsoleKeyInfo {get; }

        public GameKeyboardHandlerEventArgs(ConsoleKeyInfo consoleKeyInfo)
        {
            ConsoleKeyInfo = consoleKeyInfo;
        }
    }
}
