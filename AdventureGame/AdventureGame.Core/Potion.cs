using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Potion : Item
    {
        private const int HealAmount = 20;

        public Potion(string name)
            : base(name, $"You drink the {name} and restore 20 HP!")
        {
        }

        public void Use(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}
