using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Maze
    {
        private Tile[,] grid;
        private Random rand = new Random();

        public int Size { get; }

        public Maze(int size = 10)
        {
            Size = size;
            grid = new Tile[size, size];
            Generate();
        }

        private void Generate()
        {
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (r == 0 || c == 0 || r == Size - 1 || c == Size - 1)
                        grid[r, c] = new Tile(TileType.Wall);
                    else
                        grid[r, c] = new Tile(rand.NextDouble() < 0.2 ? TileType.Wall : TileType.Empty);
                }
            }

            // Ensure starting path clear
            grid[1, 1].Type = TileType.Empty;

            // Exit placement
            grid[Size - 2, Size - 2].Type = TileType.Exit;

            // Place monsters & items
            for (int i = 0; i < Size; i++)
            {
                int r = rand.Next(1, Size - 1);
                int c = rand.Next(1, Size - 1);

                if (grid[r, c].Type == TileType.Empty)
                {
                    double roll = rand.NextDouble();

                    if (roll < 0.3)
                        grid[r, c].Monster = new Monster();
                    else if (roll < 0.5)
                        grid[r, c].Item = new Weapon("Sword", rand.Next(1, 6));
                    else if (roll < 0.7)
                        grid[r, c].Item = new Potion();
                }
            }
        }

        public Tile GetTile(int r, int c)
        {
            return grid[r, c];
        }

        public void Draw(int playerRow, int playerCol)
        {
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (r == playerRow && c == playerCol)
                        Console.Write("@");
                    else if (grid[r, c].Type == TileType.Wall)
                        Console.Write("#");
                    else if (grid[r, c].Monster != null && grid[r, c].Monster.IsAlive)
                        Console.Write("M");
                    else if (grid[r, c].Item is Weapon)
                        Console.Write("W");
                    else if (grid[r, c].Item is Potion)
                        Console.Write("P");
                    else if (grid[r, c].Type == TileType.Exit)
                        Console.Write("E");
                    else
                        Console.Write(".");
                }
                Console.WriteLine();
            }
        }
    }
}
