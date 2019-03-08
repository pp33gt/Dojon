using System;
using System.Collections.Generic;

namespace Dojon.Utils
{
    internal class ConsoleInteraction: IConsoleInteraction
    {
        public void Write(char character)
        {
            Console.Write(character);
        }

        public void ForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey(intercept: true);
        }

        public void WriteLines(IEnumerable<string> rows)
        {
            foreach (var row in rows)
            {
                Console.WriteLine(row);
            }
        }
    }
}
