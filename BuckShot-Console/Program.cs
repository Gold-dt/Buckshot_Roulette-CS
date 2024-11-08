using GameEngine;
using System;
using System.Linq; 

namespace BuckShot
{
    class Program
    {
        GameWork game;
        public int MaxReck => 8;//Max töltény amit ki lehet osztani
        public int MaxRound => 3;//Max körök
        public int MinHealth => 2;//Min életerő
        public int MaxHealth => 5;//Max életerő
        public int[] NameLentgh => [2, 6];//Név karakter rendszer
        public int GameType => 0;// 0 : Default | 1 : Duppla vagy semmi
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program program = new Program();
            program.Menu(["Start", "language"], [program.GameStart]);
            
            
            
        }

        void Test()
        {


            Random r = new Random();
            while (true)
            {

                int currentshels = r.Next(2, MaxReck);
                int aktív = r.Next(1, currentshels);
                int blank = currentshels - aktív;
                //Console.WriteLine($"{aktív}/{currentshels}");

                Console.Write($"\nÖsszes: {currentshels}");
                if (aktív == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($" Aktív: {aktív}");
                if (blank == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write($" Üres: {blank}");
                Console.ResetColor();

                Console.ReadLine();
            }
        }

        void GameStart()
        {
            
            
            NameChange(out string Player_Name);
            #region Fancy text
            //TextAnim("Are your ready?");
            //Thread.Sleep(1000);
            //Console.Clear();
            #endregion
            game = new(Player_Name, MaxReck, MaxRound,MaxHealth,MinHealth,GameType);
            game.Round = 1;
            game.NextRound();
            Console.WriteLine(game);
            Console.ReadLine();
            
        }

        void Match()
        {

        }

        void Menu(string[] menupont, Action[] menuoptions)
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


                if(gomb.Key == ConsoleKey.S || gomb.Key == ConsoleKey.DownArrow)
                {
                    if(index != menupont.Length-1)
                    {
                        index++;
                    }
                }
                else if(gomb.Key == ConsoleKey.Enter)
                {
                    menuoptions[index].Invoke();
                    run = false;
                }
                else if(gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
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

        void NameChange(out string PlayerName)
        {
            int[] length = NameLentgh.ToArray();
            bool run = true;
            PlayerName = "";
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
                    
                    PlayerName = Name;
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
