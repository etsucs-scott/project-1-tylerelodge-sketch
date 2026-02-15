using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public string PickupMessage { get; protected set; }

        protected Item(string name, string message)
        {
            Name = name;
            PickupMessage = message;
        }
    }
}
