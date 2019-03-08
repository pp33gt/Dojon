using System;

namespace Dojon.Utils
{
    internal class KeyboardListener
    {
        public event EventHandler<KeyboardListenerEventArgs> KeyboardListenerEvent;

        private bool IsListeningForKeyEvents { get; set; } = true;

        private IConsoleInteraction Console { get; }

        public KeyboardListener(IConsoleInteraction console)
        {
            Console = console;
        }

        private void OnKeyPressed(KeyboardListenerEventArgs e)
        {
            KeyboardListenerEvent?.Invoke(this, e);
        }

        public void Start()
        {
            while (IsListeningForKeyEvents)
            {
                var key = Console.ReadKey();
                OnKeyPressed(new KeyboardListenerEventArgs(key));
            }
        }

        public void Stop()
        {
            IsListeningForKeyEvents = false;
        }
    }
}
