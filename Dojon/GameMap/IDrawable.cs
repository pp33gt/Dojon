using System;

namespace Dojon.GameMap
{
    internal interface IDrawable
    {
        string Symbol { get; }
        ConsoleColor Color { get; }
    }
}