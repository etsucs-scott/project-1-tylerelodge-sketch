using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Maze
    {
        private Tile[,] grid;

        public int Rows { get; }
        public int Columns { get; }

        public Maze(int rows, int cols)
        {
            Rows = rows;
            Columns = cols;
            grid = new Tile[rows, cols];

            Initialize();
        }

        private void Initialize()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    grid[r, c] = new Tile(TileType.Empty);
                }
            }

            // Example placements
            grid[1, 1] = new Tile(TileType.Wall);

            grid[2, 2] = new Tile(TileType.Item)
            {
                Item = new Weapon("Sword", 5)
            };

            grid[3, 3] = new Tile(TileType.Item)
            {
                Item = new Potion("Health Potion")
            };

            grid[4, 4] = new Tile(TileType.Monster)
            {
                Monster = new Monster("Goblin")
            };

            grid[5, 5] = new Tile(TileType.Exit);
        }

        public Tile GetTile(int r, int c)
        {
            return grid[r, c];
        }
    }
}
