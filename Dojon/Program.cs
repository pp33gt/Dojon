using Dojon.Utils;

namespace Dojon
{
    class Program
    {
        static void Main(string[] args)
        {
            var Console = new ConsoleInteraction();
            Game game = new Game(Console);
            game.Run();
        }
    }
}
