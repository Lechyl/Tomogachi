using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomogachi
{
     class DogPet : VirtualPet
    {

        public enum AgingStage { Infant,Teen,Adult,Eldery}
        public DogPet(string name)
        {
            Name = name;
            MaxHunger = 100;
            CurrentHunger = 100;
        }
        public override void StartLife()
        {
            base.StartLife();
        }
        protected override void Poop()
        {
            base.Poop();
        }
        protected override void Fed()
        {
            base.Fed();
        }

        protected override void PutToBed()
        {
            base.PutToBed();
        }

        protected override void SelfSleeping()
        {
            base.SelfSleeping();
        }
    }
}
