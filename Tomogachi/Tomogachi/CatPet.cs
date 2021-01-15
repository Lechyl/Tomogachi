using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Tomogachi
{
    class CatPet : StandardPet
    {

        private enum AgingStage { Infant,Teen,Adult,Eldery}
        private AgingStage PetAge { get; set; }
        private static Timer timerBasicNeeds;
        private static Timer timerAging;

        public CatPet(string name)
        {
            
            Name = name;
            Health = 100;
            MaxHealth = 100;
            MaxHunger = 100;
            MaxHappiness = 100;
            FallAsleepLevel = 100;
            PetAge = AgingStage.Infant;
        }

        public override void StartLife()
        {
            SetTimerBasicNeeds();
            SetTimerAging();
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
            Console.WriteLine("Your Cat Pet have died.. Try again");
            Console.ReadLine();
            timerBasicNeeds.Stop();
            timerBasicNeeds.Dispose();
            timerAging.Stop();
            timerAging.Dispose();

            Console.ReadLine();
        }
        protected override void ShowStats()
        {
            Console.Clear();

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Happiness: {CurrentHappiness}/{MaxHappiness}");
            Console.WriteLine($"Hunger: {CurrentHunger}/{MaxHunger}");
            Console.WriteLine($"Sleep: {CurrentSleepLevel}/{FallAsleepLevel}");
            Console.WriteLine($"Age: {PetAge}");
        }

        protected override void Aging()
        {
            //according to myth a cat has 9 lives. My cat is immortal.
            int nextPetAge = ((int)PetAge + 1) % 4;
            PetAge = (AgingStage)nextPetAge;
            if(PetAge == AgingStage.Infant)
            {
                Console.WriteLine($"{Name} has been reborn with the magical symtom of 9 lives");
            }
        }

        private void SetTimerBasicNeeds()
        {
            // Create a timer with a two second interval.
            timerBasicNeeds = new Timer(10000);
            // Hook up the Elapsed event for the timer. 
            timerBasicNeeds.Elapsed += BasicNeeds;
            timerBasicNeeds.AutoReset = true;
            timerBasicNeeds.Enabled = true;
        }
        private void SetTimerAging()
        {
            // Create a timer with a two second interval.
            timerAging = new Timer(60000);
            // Hook up the Elapsed event for the timer. 
            timerAging.Elapsed += Age;
            timerAging.AutoReset = true;
            timerAging.Enabled = true;
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
        private void Age(Object source, ElapsedEventArgs e)
        {
            Aging();
        }
    }
}
