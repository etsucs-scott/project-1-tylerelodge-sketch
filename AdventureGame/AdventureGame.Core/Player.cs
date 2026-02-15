using System;
using System.Collections.Generic;
using System.Linq;


namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        private const int MaxHealth = 150;
        private const int BaseDamage = 10;

        public string Name { get; }
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        // Aggregation relationship
        private List<Item> inventory = new List<Item>();

        public Player(string name)
        {
            Name = name;
            Health = 100; // Required baseline
        }

        public void AddItem(Item item)
        {
            Console.WriteLine(item.PickupMessage);

            if (item is Potion potion)
            {
                potion.Use(this);
            }
            else
            {
                inventory.Add(item);
            }
        }

        public void Attack(ICharacter target)
        {
            int bestModifier = inventory
                .OfType<Weapon>()
                .Select(w => w.AttackModifier)
                .DefaultIfEmpty(0)
                .Max();

            int totalDamage = BaseDamage + bestModifier;

            Console.WriteLine($"{Name} attacks {target.Name} for {totalDamage} damage!");
            target.TakeDamage(totalDamage);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;

            Console.WriteLine($"{Name} now has {Health} HP.");
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;

            Console.WriteLine($"{Name} heals to {Health} HP.");
        }
    }
}
