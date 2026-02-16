using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Game
    {
        public Player Player { get; }
        public Maze Maze { get; }

        public int PlayerRow { get; private set; } = 1;
        public int PlayerCol { get; private set; } = 1;

        public bool IsGameOver { get; private set; }
        public bool IsVictory { get; private set; }

        public Game(int size = 10)
        {
            Player = new Player("Hero");
            Maze = new Maze(size);
        }

        public string Move(int dRow, int dCol)
        {
            int newRow = PlayerRow + dRow;
            int newCol = PlayerCol + dCol;

            if (!Maze.IsInBounds(newRow, newCol))
                return "You cannot move outside the maze.";

            Tile tile = Maze.GetTile(newRow, newCol);

            if (tile.Type == TileType.Wall)
                return "You hit a wall.";

            PlayerRow = newRow;
            PlayerCol = newCol;

            string result = "";

            // Item
            if (tile.Item != null)
            {
                if (tile.Item is Weapon w)
                {
                    Player.AddWeapon(w);
                    result += $"Picked up {w.Name} (+{w.Modifier}). ";
                }
                else if (tile.Item is Potion p)
                {
                    Player.Heal(20);
                    result += "Drank potion (+20 HP). ";
                }

                tile.Item = null;
            }

            // Monster
            if (tile.Monster != null && tile.Monster.IsAlive)
            {
                result += RunBattle(tile.Monster);
                tile.Monster = null;
            }

            // Exit
            if (tile.Type == TileType.Exit)
            {
                IsGameOver = true;
                IsVictory = true;
                result += "You reached the exit!";
            }

            if (!Player.IsAlive)
            {
                IsGameOver = true;
                result += " You died.";
            }

            return result;
        }

        private string RunBattle(Monster monster)
        {
            string log = "Battle started! ";

            while (Player.IsAlive && monster.IsAlive)
            {
                Player.Attack(monster);
                log += $"You hit for {Player.LastDamage}. ";

                if (monster.IsAlive)
                {
                    monster.Attack(Player);
                    log += $"Monster hit for 10. ";
                }
            }

            if (Player.IsAlive)
                log += "Monster defeated! ";

            return log;
        }
    }
}
