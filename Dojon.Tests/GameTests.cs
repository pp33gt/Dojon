using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dojon.Console.Tests
{
    [TestClass]
    public class DojonTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var console = new ConsoleMock();

            console.ConsoleInputRows = new List<ConsoleKeyInfo>() {
                { new ConsoleKeyInfo(' ', ConsoleKey.B, false, false, false) },
                { new ConsoleKeyInfo(' ', ConsoleKey.Q, false, false, false) }
            };

            var game = new Game(console);

            // Act
            game.Run();

            // Assert
            var expected = new List<string>()
            {
                "..........",
                ".@........",
                "..........",
                "..........",
                "..........",
                "..s..o....",
                "......p...",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                ".......D..",
                "",
                "Hero: HP(50) Damage:(1) Inventory: ",
                "Monsters: 0",
                "No action",
                "Game Over",
                "Hit any key to Exit ..."
            };
            CollectionAssert.AreEquivalent(expected, console.ConsoleOutputRows);
        }
    }
}
