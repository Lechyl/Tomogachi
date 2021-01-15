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
            StartGame();
        }

        static void StartGame()
        {
            Console.WriteLine("Chose pet [cat] [dog]");
            string chosenPet = Console.ReadLine();
            Console.WriteLine("Chose name");
            var petName = Console.ReadLine();
            switch (chosenPet)
            {
                case "cat":
                    CatPet catPet = new CatPet(petName);
                    catPet.StartLife();
                    break;
                case "dog":
                    DogPet dogPet = new DogPet(petName);
                    dogPet.StartLife();
                    break;
                default:
                    break;
            }


            
        }
    }
}
