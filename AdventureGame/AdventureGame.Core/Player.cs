using System;
using System.Collections.Generic;
using System.Linq;


namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        private const int BaseDamage = 10;
        private const int MaxHealth = 150;

        public string Name { get; }
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        private List<Weapon> inventory = new List<Weapon>();

        public Player(string name)
        {
            Name = name;
            Health = 100;
        }

        public void AddWeapon(Weapon weapon)
        {
            inventory.Add(weapon);
            Console.WriteLine($"Picked up {weapon.Name} (+{weapon.Modifier})");
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;

            Console.WriteLine($"Healed to {Health} HP.");
        }

        public void Attack(ICharacter target)
        {
            int bestModifier = inventory.Any() ? inventory.Max(w => w.Modifier) : 0;
            int damage = BaseDamage + bestModifier;

            Console.WriteLine($"You attack for {damage} damage!");
            target.TakeDamage(damage);
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
            Console.WriteLine($"You now have {Health} HP.");
        }
    }
}
