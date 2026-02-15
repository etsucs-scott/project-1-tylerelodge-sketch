using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        private static Random random = new Random();
        private const int BaseDamage = 10;

        public string Name { get; }
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public Monster(string name)
        {
            Name = name;
            Health = random.Next(30, 51); // 30–50 HP
        }

        public void Attack(ICharacter target)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {BaseDamage} damage!");
            target.TakeDamage(BaseDamage);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;

            Console.WriteLine($"{Name} now has {Health} HP.");
        }
    }
}
