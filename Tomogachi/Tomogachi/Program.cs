using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomogachi
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void StartGame()
        {
            Console.WriteLine("Chose name");
            var petName = Console.ReadLine();
            DogPet dogPet = new DogPet(petName);
            dogPet.StartLife();
            
        }
    }
}
