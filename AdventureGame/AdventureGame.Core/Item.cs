using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public abstract class Item
    {
        public string Name { get; }

        protected Item(string name)
        {
            Name = name;
        }
    }
}

