using System;
using Dojon.Utils;

namespace Dojon.GameControl
{
    internal class GameKeyboardHandler
    {
        public event EventHandler<GameKeyboardHandlerEventArgs> GameKeyCommandEvent;

        private KeyboardListener KeyboardListener { get; set; }

        private IConsoleInteraction Console { get; }

        private ConsoleKey[] ValidKeyCommands { get; set; } = new ConsoleKey[] {
            ConsoleKey.UpArrow, 
            ConsoleKey.DownArrow, 
            ConsoleKey.LeftArrow, 
            ConsoleKey.RightArrow,

            ConsoleKey.P,
            ConsoleKey.D,
            ConsoleKey.Q,
            ConsoleKey.U,
            ConsoleKey.X
        };

        public GameKeyboardHandler(IConsoleInteraction console)
        {
            Console = console;
            KeyboardListener = new KeyboardListener(Console);
        }

        protected virtual void OnValidGameKeyCommand(GameKeyboardHandlerEventArgs e)
        {
            GameKeyCommandEvent?.Invoke(this, e);
        }

        private void OnKeyPressed(object o, KeyboardListenerEventArgs e)
        {
            foreach (var validCommand in ValidKeyCommands)
            {
                if (validCommand == e.ConsoleKey.Key)
                {
                    OnValidGameKeyCommand(new GameKeyboardHandlerEventArgs(e.ConsoleKey));
                    return;
                }
            }
        }

        public void Start()
        {
            KeyboardListener.KeyboardListenerEvent += OnKeyPressed;
            KeyboardListener.Start();
        }

        public void Stop()
        {
            KeyboardListener.KeyboardListenerEvent -= OnKeyPressed;
            KeyboardListener.Stop();
        }
    }
}
