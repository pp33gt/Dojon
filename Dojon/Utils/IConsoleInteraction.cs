using System;
using System.Collections.Generic;

namespace Dojon.Utils
{
    interface IConsoleInteraction
    {
        void ForegroundColor(ConsoleColor color);

        void Write(char character);

        void WriteLine(string text);

        void WriteLines(IEnumerable<string> rows);

        void Clear();

        ConsoleKeyInfo ReadKey();
    }
}
