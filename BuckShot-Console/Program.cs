using GameEngine;
using System;
using System.Linq; 

namespace BuckShot
{
    class Program
    {
        GameWork game;

        static void Main()
        {
            Program program = new Program();
            program.Menu();
            
        }

        void Menu()
        {
            Console.WriteLine("Game Menu");
            Console.WriteLine("1 - Start");
            NameChange();
        }

        void NameChange()
        {
            bool run = true;
            
            string valid = !run ? "Megfelelő név" : "hibás név";
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Select your Name");
                Console.Write("Name: ");
                string Name = Console.ReadLine()!.Trim().Replace(" ","-");
                Console.WriteLine($"Valid: {valid}");
                if (Name.Length >= 4 && !Name.Any(char.IsAsciiDigit))
                {
                    run = false;
                }
            }
        }
    }
}
