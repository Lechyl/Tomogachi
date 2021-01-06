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
        public int CurrentHunger { get; set; }
        public int MaxHunger { get; set; }
        public virtual void StartLife() { }
        protected virtual void Poop() { }
        protected virtual void Fed() { }
        protected virtual void PutToBed() { }
        protected virtual void SelfSleeping() { }
    }
}
