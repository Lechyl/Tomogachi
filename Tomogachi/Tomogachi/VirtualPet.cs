using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomogachi
{
    abstract class VirtualPet
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int FallAsleepLevel { get; set; }
        public int CurrentSleepLevel { get; set; } = 0;
        public int CurrentHunger { get; set; } = 0;
        public int MaxHunger { get; set; }
        public virtual void StartLife() { }
        protected virtual void Poop() {
            if (Health < MaxHealth)
            {
                Health++;
            }
            Console.WriteLine("Pooping");

        }
        protected virtual void Fed() {
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
        protected virtual void PutToBed() { }
        protected virtual void SelfSleeping() { }
        protected virtual void ShowStats() { }
        protected virtual void Aging() { }



    }
}
