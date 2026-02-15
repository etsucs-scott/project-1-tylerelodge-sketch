using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Weapon : Item
    {
        public int Modifier { get; }

        public Weapon(string name, int modifier) : base(name)
        {
            Modifier = modifier;
        }
    }
}
