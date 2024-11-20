using GameEngine;
using System;


namespace Buckshot
{
    class Program
    {
        public string Name = "Gold";

        public bool Devkit = true;
        public bool Emoji = true;
        public string Difficulty => "Hard";//Easy,Medium,Hard


        public int MaxRound => 3;


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            Program program = new Program();
            
            MainEngine game = new("Gold", 5);
            //program.MainGame(game);
            program.Winner();
            
        }
        public void Winner()
        {

            string logo = " █████ █████                        █████   ███   █████                    \r\n░░███ ░░███                        ░░███   ░███  ░░███                     \r\n ░░███ ███    ██████  █████ ████    ░███   ░███   ░███   ██████  ████████  \r\n  ░░█████    ███░░███░░███ ░███     ░███   ░███   ░███  ███░░███░░███░░███ \r\n   ░░███    ░███ ░███ ░███ ░███     ░░███  █████  ███  ░███ ░███ ░███ ░███ \r\n    ░███    ░███ ░███ ░███ ░███      ░░░█████░█████░   ░███ ░███ ░███ ░███ \r\n    █████   ░░██████  ░░████████       ░░███ ░░███     ░░██████  ████ █████\r\n   ░░░░░     ░░░░░░    ░░░░░░░░         ░░░   ░░░       ░░░░░░  ░░░░ ░░░░░ ";
           
            int test = 0;
            foreach(var item in logo)
            {
                if(test == 0)
                {

                }
            }


            // █████ █████                        █████   ███   █████                    
            //░░███ ░░███                        ░░███   ░███  ░░███                     
            // ░░███ ███    ██████  █████ ████    ░███   ░███   ░███   ██████  ████████  
            //  ░░█████    ███░░███░░███ ░███     ░███   ░███   ░███  ███░░███░░███░░███ 
            //   ░░███    ░███ ░███ ░███ ░███     ░░███  █████  ███  ░███ ░███ ░███ ░███ 
            //    ░███    ░███ ░███ ░███ ░███      ░░░█████░█████░   ░███ ░███ ░███ ░███ 
            //    █████   ░░██████  ░░████████       ░░███ ░░███     ░░██████  ████ █████
            //   ░░░░░     ░░░░░░    ░░░░░░░░         ░░░   ░░░       ░░░░░░  ░░░░ ░░░░░ 







        }

        public void Losed()
        {

        }
        

        public void DealerActionED(string highlight)
        {
            string tabs = "\t\t\t\t\t\t   "; // 5 tabulátor

            string getted = highlight == "Shoot" ? "Player" : "Self";
            Console.WriteLine();
            Console.WriteLine($"{tabs}Player");
            Console.WriteLine($"{tabs}Self");

            for (int i = 0; i < 10; i++) // 10 iteráció
            {
                // Visszalép két sorral
                Console.SetCursorPosition(0, Console.CursorTop - 2);

                if (i % 2 == 0) // Páros iteráció: Player kiemelve
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{tabs}Player");
                    Console.ResetColor();
                    Console.WriteLine($"{tabs}Self"); // Az értékek nem változnak, csak a szín
                }
                else // Páratlan iteráció: Self kiemelve
                {
                    Console.WriteLine($"{tabs}Player");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{tabs}Self"); // Az értékek nem változnak, csak a szín
                    Console.ResetColor();
                }

                Thread.Sleep(200); // Késleltetés
            }

            // Végső szöveg kiemelése
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            if (getted == "Player")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{tabs}Player");
                Console.ResetColor();
                Console.WriteLine($"{tabs}Self");
            }
            else
            {
                Console.WriteLine($"{tabs}Player");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{tabs}Self");
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
                Console.Clear();
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
                    
                    
                    //Console.WriteLine($"\t\t\t\t\tFake: {string.Join(',', game.FakeShells())}");
                }
                
            }
            

            void NewShellShow()
            {
                
                Console.Clear();
                
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\n\t\t\t\tShells: ");
                string[] Fake = game.FakeShells();
                for (int i = 0; i < Fake.Length; i++)
                {
                    string item = Fake[i];
                    if (item == "Live")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    // Utolsó elem után nincs vessző
                    if (i < Fake.Length - 1)
                    {
                        if (Emoji == true)
                        {
                            if (item == "Live")
                            {
                                Console.Write("🔴 ");
                            }
                            else
                            {
                                Console.Write("🔵 ");
                            }
                        }
                        else
                        {
                            Console.Write($"{item},");
                        }
                    }
                    else
                    {
                        if (item == "Live")
                        {
                            Console.Write("🔴 ");
                        }
                        else
                        {
                            Console.Write("🔵 ");
                        }
                    }
                    Thread.Sleep( 500 );
                }
                Thread.Sleep ( 700 );
            }


            bool Current = true;
            while (game.Rounds < MaxRound+1)
            {
                Console.Clear();
                game = new("Gold", 5);
                
                while (game.LowestEnergy() != 0)
                {
                    if (game.Shells.Count == 0)
                    {
                        game.NewShells();
                        NewShellShow();
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
                            Console.WriteLine("\n\t\t\t\t\t\t   " + "╭" + new string('─', maxWidth - 2) + "╮");

                            // Lista elemei szegéllyel
                            for (int i = 0; i < choose.Length; i++)
                            {
                                string line = $"\t\t\t\t\t\t   │ {choose[i].PadRight(maxWidth - 4)} │";
                                if (i == indexer) // Ha ez a kiemelt elem
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                }
                                Console.WriteLine(line);
                                Console.ResetColor();
                            }

                            // Alsó szegély
                            Console.WriteLine("\t\t\t\t\t\t   " + "╰" + new string('─', maxWidth - 2) + "╯");

                            // Billentyű olvasása
                            ConsoleKeyInfo gomb = Console.ReadKey(true);

                            // Kimenet törlése
                            Console.SetCursorPosition(0, Console.CursorTop - 5);
                            

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
                            string ChosedAction = "";
                            if (Difficulty == "Easy")
                            {
                                game.DealerRound("dealer", out string chosedAction);
                                ChosedAction = chosedAction;
                            }
                            else if(Difficulty == "Medium")
                            {
                                game.DealerRoundMedium("dealer",out string chosedAction);
                                ChosedAction = chosedAction;
                            }
                            else
                            {
                                game.DealerRoundHard("dealer", out string chosedAction);
                                ChosedAction = chosedAction;
                            }
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
                Console.Clear();
                string Lose()
                {
                    if (game.Energys("player") == 0) return "player";
                    else return "dealer";
                    
                }
                if(Lose() == "player")
                {
                    Console.WriteLine("▓██   ██▓ ▒█████   █    ██  ██▀███     ▓█████▄ ▓█████ ▄▄▄      ▓█████▄ \r\n ▒██  ██▒▒██▒  ██▒ ██  ▓██▒▓██ ▒ ██▒   ▒██▀ ██▌▓█   ▀▒████▄    ▒██▀ ██▌\r\n  ▒██ ██░▒██░  ██▒▓██  ▒██░▓██ ░▄█ ▒   ░██   █▌▒███  ▒██  ▀█▄  ░██   █▌\r\n  ░ ▐██▓░▒██   ██░▓▓█  ░██░▒██▀▀█▄     ░▓█▄   ▌▒▓█  ▄░██▄▄▄▄██ ░▓█▄   ▌\r\n  ░ ██▒▓░░ ████▓▒░▒▒█████▓ ░██▓ ▒██▒   ░▒████▓ ░▒████▒▓█   ▓██▒░▒████▓ \r\n   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒ ░ ▒▓ ░▒▓░    ▒▒▓  ▒ ░░ ▒░ ░▒▒   ▓▒█░ ▒▒▓  ▒ \r\n ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░   ░▒ ░ ▒░    ░ ▒  ▒  ░ ░  ░ ▒   ▒▒ ░ ░ ▒  ▒ \r\n ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░   ░░   ░     ░ ░  ░    ░    ░   ▒    ░ ░  ░ \r\n ░ ░         ░ ░     ░        ░           ░       ░  ░     ░  ░   ░    \r\n ░ ░                                    ░                       ░      ");
                }
                else
                {
                    Console.WriteLine(" █████ █████                        █████   ███   █████                    \r\n░░███ ░░███                        ░░███   ░███  ░░███                     \r\n ░░███ ███    ██████  █████ ████    ░███   ░███   ░███   ██████  ████████  \r\n  ░░█████    ███░░███░░███ ░███     ░███   ░███   ░███  ███░░███░░███░░███ \r\n   ░░███    ░███ ░███ ░███ ░███     ░░███  █████  ███  ░███ ░███ ░███ ░███ \r\n    ░███    ░███ ░███ ░███ ░███      ░░░█████░█████░   ░███ ░███ ░███ ░███ \r\n    █████   ░░██████  ░░████████       ░░███ ░░███     ░░██████  ████ █████\r\n   ░░░░░     ░░░░░░    ░░░░░░░░         ░░░   ░░░       ░░░░░░  ░░░░ ░░░░░ ");
                }
                Console.ReadLine();
            }
        }
    }
}