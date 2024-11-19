using GameEngine;
using System;

namespace Buckshot
{
    class Program
    {
        public string Name = "Gold";

        public bool Devkit = true;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Program program = new Program();
            MainEngine game = new("Gold", 5);
            
            program.MainGame(game);
            //program.Test();
        }

        public void DealerActionED(string highlight)
        {
            string getted = highlight == "Shoot" ? "Player" : "Self"; 

            Console.WriteLine("Player");
            Console.WriteLine("Self");

            for (int i = 0; i < 10; i++) // 10 iteráció
            {
                // Visszalép két sorral
                Console.SetCursorPosition(0, Console.CursorTop - 2);

                if (i % 2 == 0) // Páros iteráció: Player kiemelve
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Player");
                    Console.ResetColor();
                    Console.WriteLine("Self"); // Az értékek nem változnak, csak a szín
                }
                else // Páratlan iteráció: Self kiemelve
                {
                    Console.WriteLine("Player");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Self"); // Az értékek nem változnak, csak a szín
                    Console.ResetColor();
                }

                Thread.Sleep(200); // Késleltetés
            }
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            if(getted == "Player")
            {
                Console.ForegroundColor= ConsoleColor.Magenta;
                Console.WriteLine("Player");
                Console.ResetColor();
                Console.WriteLine("Self");
            }
            else
            {
                Console.WriteLine("Player");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Self");
                Console.ResetColor();
            }
        }


        public void MainGame(MainEngine game)
        {
            

            void EnergyValid(string actor)
            {
                int Energy = game.Energys(actor);
                if (Energy > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                }
                else if (Energy == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow; 
                }
                else if (Energy == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                }

            }

            string logo = "██████╗ ██╗   ██╗ ██████╗██╗  ██╗███████╗██╗  ██╗ ██████╗ ████████╗\r\n██╔══██╗██║   ██║██╔════╝██║ ██╔╝██╔════╝██║  ██║██╔═══██╗╚══██╔══╝\r\n██████╔╝██║   ██║██║     █████╔╝ ███████╗███████║██║   ██║   ██║   \r\n██╔══██╗██║   ██║██║     ██╔═██╗ ╚════██║██╔══██║██║   ██║   ██║   \r\n██████╔╝╚██████╔╝╚██████╗██║  ██╗███████║██║  ██║╚██████╔╝   ██║   \r\n╚═════╝  ╚═════╝  ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝    ╚═╝   ";

            void Displyer(string tabb)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(tabb); // Kezdő tabulátor
                for (int i = 0; i < logo.Length; i++)
                {
                    if (logo[i] == '\n') // Új sor karaktert talál
                    {
                        Console.Write($"\n{tabb}"); // Új sorba lép, majd új tabulátorokat ad
                    }
                    else
                    {
                        Console.Write(logo[i]); // A karaktert kiírja, ha nem új sor
                    }
                }
                string tab = "\t\t\t\t\t";
                Console.ResetColor();
                Console.WriteLine("\n");
                Console.WriteLine($"{tab}╭─────────────────────────────────╮");
                Console.Write($"{tab}│  ");
                Console.Write($"{Name}\t\t\t{Name}: ");

                EnergyValid("player");
                Console.Write($"{game.Energys("player")}");
                Console.ResetColor();
                Console.Write("   │\n");
                Console.Write($"{tab}│  ");
                Console.Write($"Dealer\t\tDealer: ");
                EnergyValid("dealer");
                Console.Write($"{game.Energys("dealer")}");
                Console.ResetColor();
                Console.Write(" │");
                Console.WriteLine($"\n{tab}╰─────────────────────────────────╯");
                if (Devkit == true)
                {
                    
                    Console.Write($"\t{tab} Lowest Energy: ");
                    int Energy = game.LowestEnergy();
                    if (Energy > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (Energy == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (Energy == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{game.LowestEnergy()}\n");
                    Console.ResetColor();
                    
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                    Console.Write($"\n{tab}Shells ({game.Shells.Count}): ");
                    for (int i = 0; i < game.Shells.Count; i++)
                    {
                        string item = game.Shells[i];
                        if (item == "Live")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }

                        // Utolsó elem után nincs vessző
                        if (i < game.Shells.Count - 1)
                        {
                            Console.Write($"{item},");
                        }
                        else
                        {
                            Console.Write($"{item}");
                        }
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" │\n");
                    Console.WriteLine("╰─────────────────────────────────╯");
                }
            }




            bool Current = true;
            while (game.Rounds < 4)
            {
                Console.Clear();
                game = new("Gold", 5);
                
                while (game.LowestEnergy() != 0)
                {
                    if (game.Shells.Count == 0)
                    {
                        game.NewShells();
                    }
                    bool run = true;
                    Displyer("\t\t\t");
                    string actor = Current == true ? "player" : "dealer";
                    int indexer = 0;
                    while (run)
                    {
                        if (actor == "player")
                        {
                            string[] choose = { "Dealer", "Self" };
                            int maxWidth = choose.Max(item => item.Length) + 4;

                            // Felső szegély
                            Console.WriteLine("╭" + new string('─', maxWidth - 2) + "╮");

                            // Lista elemei szegéllyel
                            for (int i = 0; i < choose.Length; i++)
                            {
                                string line = $"│ {choose[i].PadRight(maxWidth - 4)} │";
                                if (i == indexer) // Ha ez a kiemelt elem
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                                Console.WriteLine(line);
                                Console.ResetColor();
                            }

                            // Alsó szegély
                            Console.WriteLine("╰" + new string('─', maxWidth - 2) + "╯");

                            // Billentyű olvasása
                            ConsoleKeyInfo gomb = Console.ReadKey(true);

                            // Kimenet törlése
                            Console.SetCursorPosition(0, Console.CursorTop - 4);
                            

                            // Navigációs logika
                            if (gomb.Key == ConsoleKey.DownArrow)
                            {
                                if (indexer + 1 != choose.Length)
                                {
                                    indexer++;
                                }
                            }
                            else if (gomb.Key == ConsoleKey.UpArrow)
                            {
                                if (indexer - 1 != -1)
                                {
                                    indexer--;
                                }
                            }
                            else if (gomb.Key == ConsoleKey.Enter)
                            {
                                if (choose[indexer] == "Dealer")
                                {
                                    game.Shoot(actor);
                                    Current = !Current;
                                    run = false;
                                }
                                else if (choose[indexer] == "Self")
                                {
                                    game.MeShoot(actor);
                                    if (game.Last_P_Shot == "Live")
                                    {
                                        Current = !Current;
                                    }
                                    run = false;
                                }
                            }
                        }
                        else if (actor == "dealer")
                        {
                            game.DealerRound("dealer", out string ChosedAction);
                            if (ChosedAction == "MeShoot")
                            {
                                if (game.Last_D_Shot == "Live")
                                {
                                    Current = !Current;
                                }
                            }
                            else if (ChosedAction == "Shoot")
                            {
                                Current = !Current;
                            }
                            DealerActionED(ChosedAction);
                            run = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid actor. Exiting loop.");
                            run = false;
                        }
                    }




                   
                }

            }
        }
    }
}