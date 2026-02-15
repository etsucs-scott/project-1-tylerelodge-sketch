using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Core
{
    public class Monster : ICharacter
    {
        private static Random rand = new Random();
        private const int BaseDamage = 10;

        public string Name { get; }
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        public Monster()
        {
            Name = "Monster";
            Health = rand.Next(30, 51);
        }

        public void Attack(ICharacter target)
        {
            Console.WriteLine("Monster attacks!");
            target.TakeDamage(BaseDamage);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
            Console.WriteLine($"Monster HP: {Health}");
        }
    }
}
