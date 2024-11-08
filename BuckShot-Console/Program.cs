using GameEngine;
using System;
using System.Linq; 

namespace BuckShot
{
    class Program
    {
        GameWork game;
        public string Name { get; set; }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program program = new Program();
            
            program.Menu(["Start", "language", "ChangeName"]);
            
            
        }

        void Menu(string[] menupont)
        {
            int index = 0;
            
            
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine($"Game Menu {index} / {menupont.Length}");
                for (int i = 0; i < menupont.Length; i++)
                {
                    if(index == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine($"{i + 1} - {menupont[i]}");
                    Console.ResetColor();
                }
                ConsoleKeyInfo gomb = Console.ReadKey();


                if(gomb.Key == ConsoleKey.S)
                {
                    if(index != menupont.Length-1)
                    {
                        index++;
                    }
                }
                else if(gomb.Key == ConsoleKey.W)
                {
                    if(index != 0)
                    {
                        index--;
                    }
                }
            }

            //NameChange(out string name, [2,6]);
            //TextAnim($"Are you ready?");
        }

        void NameChange(out string name,int[] length)
        {
            name = "";
            bool run = true;

            string valid;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("Select your Name");
                Console.Write("Name: ");
                string Name = Console.ReadLine()!.Trim().Replace(" ","-");
                if (Name.Length >= length[0] && Name.Length <= length[1] && !Name.Any(char.IsAsciiDigit))
                {
                    run = false;
                    name = Name;
                    this.Name = name;
                }
                valid = !run ? "🟢" : "🔴";
                Console.WriteLine($"Status: {valid}");
                Console.WriteLine($"  ");

                for (int i = 0; i < 3; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.ForegroundColor = run ? ConsoleColor.Red : ConsoleColor.Green;
                            break;
                        case 1:
                            Console.ResetColor();
                            break;
                        case 2:
                            Console.ForegroundColor = run ? ConsoleColor.Red : ConsoleColor.Green;
                            break;
                    }
                    Console.WriteLine("         ");
        
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    
                    Console.Write(new string(' ', Console.WindowWidth));
                    
                    
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    if (run == true)
                    {
                        if (Name.Length < length[0] || Name.Length > length[1])
                        {
                            Console.WriteLine($"{length[0]} és {length[1]} karakter között kell lenni");
                        }
                        else if (Name.Any(char.IsAsciiDigit))
                        {
                            Console.WriteLine("nem lehet benne szám");
                        }
                    }
                    else { Console.WriteLine("Correct"); }
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
        }
        void TextAnim(string text)
        {
            Console.WriteLine();
            foreach (var item in text)
            {
                Console.Write(item);
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }
    }
}
