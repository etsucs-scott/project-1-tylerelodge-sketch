using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Potion : Item
    {
        private const int HealAmount = 20;

        public Potion() : base("Potion") { }

        public void Use(Player player)
        {
            player.Heal(HealAmount);
        }
    }
}
