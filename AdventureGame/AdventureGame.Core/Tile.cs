using AdventureGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public enum TileType
    {
        Empty,
        Wall,
        Monster,
        Item,
        Exit
    }
}

public class Tile
{
    public TileType Type { get; set; }
    public Item Item { get; set; }
    public Monster Monster { get; set; }

    public Tile(TileType type)
    {
        Type = type;
    }
}