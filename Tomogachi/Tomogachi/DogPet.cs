using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tomogachi
{
    class DogPet : StandardPet
    {

        public enum AgingStage { Infant, Teen, Adult, Eldery }
        public AgingStage PetAgingState;
        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer bTimer;

        public DogPet(string name)
        {
            Name = name;
            Health = 100;
            MaxHealth = 100;
            MaxHunger = 100;
            MaxHappiness = 100;
            FallAsleepLevel = 100;
            PetAgingState = AgingStage.Infant;
        }
        public override void StartLife()
        {
            SetTimer1();
            SetTimer2();
            while (Health > 0)
            {
                ShowStats();
                Console.WriteLine("Write an action [eat] [sleep] [play]");
                string action = Console.ReadLine();
                switch (action)
                {
                    case "eat":
                        Fed();
                        break;
                    case "sleep":
                        PutToBed();
                        break;
                    case "play":
                        Play();
                        break;
                    default:
                        Console.WriteLine("Action does not exist try again");
                        break;
                }

                Console.WriteLine("press enter to continue....");
                Console.ReadLine();
            }
            Console.WriteLine("Your Pet have died.. Try again");
            Console.ReadLine();
            bTimer.Stop();
            bTimer.Dispose();
            aTimer.Stop();
            aTimer.Dispose();
        }
        protected override void ShowStats()
        {
            Console.Clear();

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Happiness: {CurrentHappiness}/{MaxHappiness}");
            Console.WriteLine($"Hunger: {CurrentHunger}/{MaxHunger}");
            Console.WriteLine($"Sleep: {CurrentSleepLevel}/{FallAsleepLevel}");
            Console.WriteLine($"Age: {PetAgingState}");

        }
        protected override void Aging()
        {
            if (PetAgingState != AgingStage.Eldery)
            {
                PetAgingState++;

                MaxHealth -= 25;
                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }
                Console.WriteLine("I'm getting older");
            }
            else
            {
                Health = 0;
                Console.WriteLine(Name + " has growing too old.. he/she died");

            }

        }

        protected override void SelfSleeping()
        {
            if (CurrentSleepLevel >= FallAsleepLevel)
            {
                Console.WriteLine($"{Name} is to tired and fell asleep ..");

                PutToBed();
            }
        }
        private void SetTimer1()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += BasicNeeds;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void SetTimer2()
        {
            // Create a timer with a two second interval.
            bTimer = new System.Timers.Timer(60000);
            // Hook up the Elapsed event for the timer. 
            bTimer.Elapsed += AgeTimer;
            bTimer.AutoReset = true;
            bTimer.Enabled = true;
        }
        private void BasicNeeds(Object source, ElapsedEventArgs e)
        {
            CurrentHunger = CurrentHunger + 3 > MaxHunger ? MaxHunger : CurrentHunger + 3;
            CurrentSleepLevel = +1;

            CurrentHappiness = (CurrentHappiness + 5) > MaxHappiness ? MaxHappiness : CurrentHappiness + 5;

            ShowStats();
            SelfSleeping();
            Console.WriteLine("press enter to continue....");


        }
        private void AgeTimer(Object source, ElapsedEventArgs e)
        {
            Aging();
        }
    }
}
