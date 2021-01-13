using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomogachi
{
    abstract class StandardPet
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHappiness { get; set; } = 0;
        public int MaxHappiness { get; set; }
        public int FallAsleepLevel { get; set; }
        public int CurrentSleepLevel { get; set; } = 0;
        public int CurrentHunger { get; set; } = 0;
        public int MaxHunger { get; set; }
        public virtual void StartLife() { }
        public virtual void Play() 
        {
            Console.WriteLine($"Playing with {Name}");
            Console.WriteLine($"{Name} is now happy");
            CurrentHappiness = (CurrentHappiness - 10) < 0 ? 0 : CurrentHappiness - 10;
            CurrentHunger = CurrentHunger + 10 > MaxHunger ? MaxHunger : CurrentHunger + 3;

        }

        protected virtual void Poop()
        {
            if (Health < MaxHealth)
            {
                Health++;
            }
            Console.WriteLine("Pooping");

        }
        protected virtual void Fed()
        {
            if (CurrentHunger <= 0)
            {
                Console.WriteLine("Too full to eat right now");
                CurrentHunger = 0;

            }
            else
            {
                CurrentHunger = (CurrentHunger - 25) >= 0 ? (CurrentHunger - 25) : 0;
                Console.WriteLine(Name + " is eating pet food..");
                if (CurrentHunger > MaxHunger)
                {
                    Health -= 8;
                    Console.WriteLine("Ouch I feel sick!");
                }
                Poop();
            }
        }
        protected virtual void PutToBed()
        {
            CurrentSleepLevel = 0;
            Health += 5;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            CurrentHunger += 15;

            Console.WriteLine("I think I'll sleep now");
        }
        protected virtual void SelfSleeping() { }
        protected virtual void ShowStats() { }
        protected virtual void Aging() { }



    }
}
