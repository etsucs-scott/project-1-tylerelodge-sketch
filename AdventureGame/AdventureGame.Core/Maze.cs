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
            // Makes sure there's always a path from start to exit,
            // then randomly adds extra empty spaces, monsters, and items
        {
            // Fill entire maze with walls
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    grid[r, c] = new Tile(TileType.Wall);
                }
            }

            // Carve guaranteed path from (1,1) to exit
            int row = 1;
            int col = 1;
            grid[row, col].Type = TileType.Empty;

            while (row < Size - 2 || col < Size - 2)
            {
                if (row < Size - 2 && col < Size - 2)
                {
                    if (rand.Next(2) == 0)
                        row++;
                    else
                        col++;
                }
                else if (row < Size - 2)
                {
                    row++;
                }
                else
                {
                    col++;
                }

                grid[row, col].Type = TileType.Empty;
            }

            // Place exit
            grid[Size - 2, Size - 2].Type = TileType.Exit;

            // Randomly carve extra empty spaces
            for (int r = 1; r < Size - 1; r++)
            {
                for (int c = 1; c < Size - 1; c++)
                {
                    if (grid[r, c].Type == TileType.Wall && rand.NextDouble() < 0.35)
                    {
                        grid[r, c].Type = TileType.Empty;
                    }
                }
            }

            // Place monsters & items only on empty tiles
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

        public bool IsInBounds(int r, int c)
        {
            return r >= 0 && r < Size && c >= 0 && c < Size;
        }
    }
}
