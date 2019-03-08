using System;
using System.Collections.Generic;
using Dojon;
using Dojon.Utils;

namespace Dojon.Console.Tests
{
    public class ConsoleMock : IConsoleInteraction
    {
        public List<string> ConsoleOutputRows { get; set; } = new List<string>();

        public List<ConsoleKeyInfo> ConsoleInputRows { get; set; } = new List<ConsoleKeyInfo>();

        void IConsoleInteraction.Clear()
        {
            ConsoleOutputRows.Clear();
            ConsoleOutputRows.Add(string.Empty);
        }

        public ConsoleKeyInfo ReadKey()
        {
            if (ConsoleInputRows.Count > 0)
            {
                var userinput = ConsoleInputRows[0];
                ConsoleInputRows.RemoveAt(0);
                return userinput;
            }
            return new ConsoleKeyInfo();
        }

        void IConsoleInteraction.ForegroundColor(ConsoleColor color)
        {
        }

        void IConsoleInteraction.Write(char character)
        {
            ConsoleOutputRows[ConsoleOutputRows.Count - 1] += character;
        }

        void IConsoleInteraction.WriteLine(string text)
        {
            ConsoleOutputRows.Add(text);
        }

        void IConsoleInteraction.WriteLines(IEnumerable<string> rows)
        {
            foreach(var row in rows)
            {
                ConsoleOutputRows.Add(row);
            }
        }
    }
}