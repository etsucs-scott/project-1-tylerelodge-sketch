using System;
using AdventureGame.Core;
class Program
{
    static void Main()
    {
        Game game = new Game(10);
        string message = "";

        while (!game.IsGameOver)
        {
            Console.Clear();

            if (!string.IsNullOrEmpty(message))
                Console.WriteLine(message + "\n");

            DrawMaze(game);

            Console.WriteLine($"\nHP: {game.Player.Health}");
            Console.WriteLine("Move with WASD or Arrow Keys");

            var key = Console.ReadKey(true).Key;

            message = key switch
            {
                ConsoleKey.W or ConsoleKey.UpArrow => game.Move(-1, 0),
                ConsoleKey.S or ConsoleKey.DownArrow => game.Move(1, 0),
                ConsoleKey.A or ConsoleKey.LeftArrow => game.Move(0, -1),
                ConsoleKey.D or ConsoleKey.RightArrow => game.Move(0, 1),
                _ => "Invalid key."
            };
        }

        Console.Clear();
        DrawMaze(game);

        Console.WriteLine("\n" + (game.IsVictory ? "YOU WIN!" : "GAME OVER"));
        Console.ReadKey();
    }

    static void DrawMaze(Game game)
    {
        for (int r = 0; r < game.Maze.Size; r++)
        {
            for (int c = 0; c < game.Maze.Size; c++)
            {
                if (r == game.PlayerRow && c == game.PlayerCol)
                    Console.Write("@ ");
                else
                    Console.Write(GetSymbol(game.Maze.GetTile(r, c)) + " ");
            }
            Console.WriteLine();
        }
    }

    static char GetSymbol(Tile tile)
    {
        if (tile.Type == TileType.Wall) return '#';
        if (tile.Monster != null && tile.Monster.IsAlive) return 'M';
        if (tile.Item is Weapon) return 'W';
        if (tile.Item is Potion) return 'P';
        if (tile.Type == TileType.Exit) return 'E';
        return '.';
    }
}
