using GameEngine;
using System;


namespace Buckshot
{
    class Program
    {                       //1234567
        public string Name = "Gold_dt";

        public bool Devkit;
        public bool Emoji;
        public int StarterItemsCount = 3;

        public int MinShells = 3;
        public int MaxShells = 9;
        public int MaxRound = 3;

        public int StarterHealth = 5;

        ItemView itemView = new ItemView();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            Program program = new Program();
            ItemView itemView = new ItemView();
            BasicLoader Setup = new BasicLoader();
            Loader loader = new Loader();
            Menu menu = new Menu();

            if(args.Count() == 0)
            {
                Setup.Kerdes("Fejlesztői nézetet kérsz? ", ["Igen", "Nem"], ConsoleColor.Cyan);
                Setup.Kerdes("Konzolod megtudja jeleníteni az emoji-kat: ", ["Igen", "Nem"], ConsoleColor.Cyan);
                program.Devkit = Setup.Valasz[0] == "Igen" ? true : false;
                program.Emoji = Setup.Valasz[1] == "Igen" ? true : false;


                loader.FullLoader(Random.Shared.Next(2, 8), Random.Shared.Next(2, 4));
                menu.MainMenu(out int[] ConfigData, out bool starter);
                if (starter == true)
                {


                    menu.SetName(out string name);
                    program.Name = name;
                    program.MaxRound = ConfigData[3];
                    MainEngine game = new(program.Name, ConfigData[4], ConfigData[0], ConfigData[1], ConfigData[2], ConfigData[3]);


                    program.MainGame(game);
                }
            }
            else
            {
                menu.MainMenu(out int[] ConfigData, out bool starter);
                if (starter == true)
                {


                    menu.SetName(out string name);
                    program.Name = name;
                    program.MaxRound = ConfigData[3];
                    MainEngine game = new(program.Name, ConfigData[4], ConfigData[0], ConfigData[1], ConfigData[2], ConfigData[3]);


                    program.MainGame(game);
                }
            }
            


        }
        public void Winner()
        {

            string logo = " █████ █████                        █████   ███   █████                    \r\n░░███ ░░███                        ░░███   ░███  ░░███                     \r\n ░░███ ███    ██████  █████ ████    ░███   ░███   ░███   ██████  ████████  \r\n  ░░█████    ███░░███░░███ ░███     ░███   ░███   ░███  ███░░███░░███░░███ \r\n   ░░███    ░███ ░███ ░███ ░███     ░░███  █████  ███  ░███ ░███ ░███ ░███ \r\n    ░███    ░███ ░███ ░███ ░███      ░░░█████░█████░   ░███ ░███ ░███ ░███ \r\n    █████   ░░██████  ░░████████       ░░███ ░░███     ░░██████  ████ █████\r\n   ░░░░░     ░░░░░░    ░░░░░░░░         ░░░   ░░░       ░░░░░░  ░░░░ ░░░░░ ";

            string tabb = "\t\t\t";
            for (int i = 0; i < 5; i++)
            {

                Console.Clear();
                switch (i)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                }


                Console.Write(tabb);
                foreach (var item in logo)
                {
                    if (item == '\n')
                    {
                        Console.Write($"\n{tabb}");
                    }
                    else
                    {
                        Console.Write(item);
                    }
                }
                Console.ResetColor();
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n\x1b[3mPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }

        public void Losed()
        {
            string logo =
                "▓██   ██▓  ▒█████    █    ██   ██▀███     ▓█████▄  ▓█████  ▄▄▄       ▓█████▄ \r\n" +
                " ▒██  ██▒ ▒██▒  ██▒  ██  ▓██▒ ▓██ ▒ ██▒   ▒██▀ ██▌ ▓█   ▀ ▒████▄     ▒██▀ ██▌\r\n" +
                "  ▒██ ██░ ▒██░  ██▒ ▓██  ▒██░ ▓██ ░▄█ ▒   ░██   █▌ ▒███   ▒██  ▀█▄   ░██   █▌\r\n" +
                "  ░ ▐██▓░ ▒██   ██░ ▓▓█  ░██░ ▒██▀▀█▄     ░▓█▄   ▌ ▒▓█  ▄ ░██▄▄▄▄██  ░▓█▄   ▌\r\n" +
                "  ░ ██▒▓░ ░ ████▓▒░ ▒▒█████▓  ░██▓ ▒██▒   ░▒████▓  ░▒████ ▒▓█   ▓██▒ ░▒████▓ \r\n" +
                "   ██▒▒▒  ░ ▒░▒░▒░  ░▒▓▒ ▒ ▒  ░ ▒▓ ░▒▓░    ▒▒▓  ▒  ░░ ▒░  ░▒▒   ▓▒█░  ▒▒▓  ▒ \r\n" +
                " ▓██ ░▒░    ░ ▒ ▒░  ░░▒░ ░ ░    ░▒ ░ ▒░    ░ ▒  ▒   ░ ░   ░ ▒   ▒▒ ░  ░ ▒  ▒ \r\n" +
                " ▒ ▒ ░░   ░ ░ ░ ▒    ░░░ ░ ░    ░░   ░     ░ ░  ░     ░     ░   ▒     ░ ░  ░ \r\n" +
                " ░ ░          ░ ░      ░         ░           ░        ░   ░     ░  ░    ░    \r\n" +
                " ░ ░                                       ░                          ░      ";


            string tabb = "\t\t\t";
            for (int i = 0; i < 5; i++)
            {
               
                Console.Clear();
                switch (i){
                    case 0:
                        Console.ForegroundColor= ConsoleColor.DarkRed;
                        break;
                    case 1:
                        Console.ForegroundColor= ConsoleColor.Red;
                        break;
                    case 2:
                        Console.ForegroundColor= ConsoleColor.DarkRed;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                }

                
                Console.Write(tabb);
                foreach (var item in logo)
                {
                    if (item == '\n')
                    {
                        Console.Write($"\n{tabb}");
                    }
                    else
                    {
                        Console.Write(item);
                    }
                }
                Console.ResetColor();
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n\x1b[3mPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
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
                //Console.Write($"{Name}\t\t\t{Name}: ");
                Console.Write($"{Name.PadRight(29-Name.Length-2,' ')}{Name}: ");

                EnergyValid("player");
                Console.Write($"{game.Energys("player")}");
                Console.ResetColor();
                Console.Write(" │\n");
                Console.Write($"{tab}│  ");
                Console.Write($"Dealer\t\tDealer: ");
                EnergyValid("dealer");
                Console.Write($"{game.Energys("dealer")}");
                Console.ResetColor();
                Console.Write(" │");
                
                Console.WriteLine($"\n{tab}╰─────────────────────────────────╯");
                Console.WriteLine();
                
                if (game.GetActorUsedItems("player").Count() > 0)
                {
                    Console.WriteLine($"{tab}│ Used Items: \x1b[3m" + string.Join(',', game.GetActorUsedItems("player")) + "\x1b[39m │");
                }
                Console.ResetColor();
                if (Devkit == true)//For Development
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
                    Console.WriteLine($"{tab}Round: {game.Round}\tP_Round: {game.GetActorRounds("player")}\tD_Round: {game.GetActorRounds("dealer")}");
                    Console.WriteLine($"{tab}Player: {game.ShowItems("player", out int PL_ItemsC)}({PL_ItemsC})");
                    Console.WriteLine($"{tab}Dealer: {game.ShowItems("dealer",out int DL_ItemsC)}({DL_ItemsC})");
                    Console.WriteLine($"\tDUsedItems: {string.Join(',',game.GetActorUsedItems("dealer"))}");
                    
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
                            Console.Write($"{item}");
                        }
                    }
                    Thread.Sleep( 500 );
                }
                Thread.Sleep ( 700 );
            }


            void ItemUseShow(string actor,List<string> Items, string tab,bool pressed)
            {
                bool run = true;
                int indexer = 0;

                // Kiindulási sor mentése
                int startRow = Console.CursorTop;
                if (pressed)
                {
                    Console.SetCursorPosition(0, Console.CursorTop - Items.Count+2);
                }


                while (run)
                {
                    // Visszaállás a menü tetejére
                    Console.SetCursorPosition(0, startRow);

                    // Menü újrarajzolása
                    Console.WriteLine($"{tab}╭──── ITEMS ─────╮");
                    for (int i = 0; i < Items.Count; i++)
                    {
                        Console.Write($"{tab}│");

                        if (i == indexer)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta; // Kiemelés
                        }

                        Console.Write($"    {Items[i]}".PadRight(16)); // Kitöltés a megjelenítéshez
                        Console.ResetColor();
                        Console.WriteLine("│");
                    }
                    Console.WriteLine($"{tab}╰────────────────╯");

                    // Billentyűzet input kezelése
                    ConsoleKeyInfo gomb = Console.ReadKey(true);

                    if (gomb.Key == ConsoleKey.DownArrow || gomb.Key == ConsoleKey.S)
                    {
                        if (indexer < Items.Count - 1)
                        {
                            indexer++;
                        }
                    }
                    else if (gomb.Key == ConsoleKey.UpArrow || gomb.Key == ConsoleKey.W)
                    {
                        if (indexer > 0)
                        {
                            indexer--;
                        }
                    }
                    else if (gomb.Key == ConsoleKey.Enter)
                    {
                        run = false; // Kilépés
                        Console.SetCursorPosition(0, startRow + Items.Count + 2);
                        //Console.WriteLine($"Selected: {Items[indexer]}");
                        if (game.ActorItems(actor).Count > 0)
                        {
                            
                            itemView.Show(Items[indexer], game.Shells[0]);
                            game.ItemUse(actor, Items[indexer], out string CurrentShell);
                        }
                        Displyer(tab);
                    }
                    else if (gomb.Key == ConsoleKey.Escape || gomb.Key == ConsoleKey.RightArrow || gomb.Key == ConsoleKey.D)
                    {
                        run = false;
                        Console.SetCursorPosition(0, Console.CursorTop - Items.Count+4);
                        pressed = false;
                        Displyer(tab);
                    }
                }
            }

            bool Current = true;
            bool PlayerIsAlive = true;
            int LastRound = 1;
            bool HudPressed = false;
            

            while (game.Round < MaxRound+1 && PlayerIsAlive == true)
            {
                Console.Clear();
                //game = new("Gold", 5);
                //game.NextRound();
                if(game.Round != 1)
                {
                    game.ItemGen();
                }
                LastRound = game.Round;
                while (game.LowestEnergy() != 0)
                {
                    if (game.Shells.Count == 0)
                    {
                        game.NewShells();
                        NewShellShow();
                        
                        game.ItemGive();
                    }
                    bool run = true;
                    Displyer("\t\t\t");
                    string actor = Current == true ? "player" : "dealer";
                    
                    int indexer = 0;

                    game.NextDamage = 1;
                    

                    while (run && game.Shells.Count != 0)
                    {
                        
                        if (actor == "player")
                        {
                            string[] choose = { "Dealer", "Self","Items" };
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
                            Console.SetCursorPosition(0, Console.CursorTop - 6);
                            

                            // Navigációs logika
                            if (gomb.Key == ConsoleKey.DownArrow || gomb.Key == ConsoleKey.S)
                            {
                                if (indexer + 1 != choose.Length)
                                {
                                    indexer++;
                                }
                            }
                            else if (gomb.Key == ConsoleKey.UpArrow || gomb.Key == ConsoleKey.W)
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
                                    if(game.GetActorRounds(actor) == 1)
                                    {
                                        Current = !Current;
                                        game.UsedItemReset();
                                    }
                                    else
                                    {
                                        
                                        game.RemoveRound(actor);
                                    }
                                    run = false;
                                }
                                else if (choose[indexer] == "Self")
                                {
                                    game.MeShoot(actor);
                                    
                                    if (game.Last_P_Shot == "Live")
                                    {

                                        if (game.GetActorRounds(actor) == 1)
                                        {
                                            Current = !Current;
                                            game.UsedItemReset();
                                        }
                                        else
                                        {

                                            game.RemoveRound(actor);
                                        }
                                    }
                                    run = false;
                                }
                                //--------------------------------------------------
                                else if(choose[indexer] == "Items")
                                {
                                    ItemUseShow(actor,game.ActorItems(actor), "\t\t\t\t",HudPressed);
                                    HudPressed = true;
                                }
                            }
                        }
                        //Dealer Stuffs
                        else if (actor == "dealer")
                        {
                            string ChosedAction = "";
                            game.DealerRound("dealer", out string chosedAction, out string chosenItem);
                            if (chosenItem != "0" && (chosenItem == "Knife" || chosenItem == "Cigaretta" || chosenItem == "Cuffs" || chosenItem == "Beer"))
                            {
                                if(game.Shells.Count() > 0)
                                {
                                    itemView.Show(chosenItem, game.Shells[0]);
                                }
                                Displyer("\t\t\t");
                            }
                            ChosedAction = chosedAction;
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
                    Losed();
                    //break;
                    PlayerIsAlive = false;
                    Console.Clear();
                    Program.Main(["Reload"]);
                }
                else if(Lose() == "dealer" && game.Round == MaxRound)
                {
                    Winner();
                    //game.NextRound();
                    Console.Clear();
                    Program.Main(["Reload"]);
                }
                else
                {
                    game.NextRound();
                    int margin = 10 - 5 - game.Round.ToString().Length - MaxRound.ToString().Length;
                    string tab = "\t\t\t\t\t";

                    // Első kijelzés
                    Console.WriteLine($"{tab}╭{"─".PadLeft(10, '─')}╮\n{tab}│   {LastRound}/{MaxRound}{"".PadLeft(margin, ' ')} │\n{tab}╰{"─".PadLeft(10, '─')}╯");
                    Thread.Sleep(1500);
                    Console.Clear();

                    // Második kijelzés villogással
                    for (int i = 0; i < 4; i++) // 4 ciklus = 2 teljes villogás
                    {
                        // Sima szín
                        Console.Clear();
                        Console.Write($"{tab}╭{"─".PadLeft(10, '─')}╮\n{tab}│   ");
                        Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkYellow : ConsoleColor.Yellow; // Szín váltása
                        Console.Write($"{game.Round}/{MaxRound}");
                        Console.ResetColor();
                        Console.Write($"{"".PadLeft(margin, ' ')} │\n{tab}╰{"─".PadLeft(10, '─')}╯");
                        Thread.Sleep(700); // Fél másodperc várakozás
                    }

                    NewShellShow();
                }
                
            }
        }
    }
}