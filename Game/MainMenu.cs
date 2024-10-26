using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu
    {
        public MainMenu(string[] opciok)
        {
            Szintek = opciok;
        }

        string[] valtozok = { "", "", "", "", "", "", "" }; // Az egyes menüpontokhoz tartozó értékek
        string[] Szintek { get; init; }

        Action[] funkciok = { };

        string Title = "▄▄▄█████▓  ██░ ██  ▓█████      ██████  ▓█████  ▄▄▄        ██▀███    ▄████▄    ██░ ██ \r\n▓  ██▒ ▓▒ ▓██░ ██▒ ▓█   ▀    ▒██    ▒  ▓█   ▀▒ ████▄     ▓██ ▒ ██▒ ▒██▀ ▀█   ▓██░ ██▒\r\n▒ ▓██░ ▒░ ▒██▀▀██░ ▒███      ░ ▓██▄    ▒███  ▒ ██  ▀█▄   ▓██ ░▄█ ▒ ▒▓█    ▄  ▒██▀▀██░\r\n░ ▓██▓ ░  ░▓█ ░██  ▒▓█  ▄      ▒   ██▒ ▒▓█  ▄░ ██▄▄▄▄██  ▒██▀▀█▄   ▒▓▓▄ ▄██▒ ░▓█ ░██ \r\n ▒██▒ ░  ░▓█▒░██▓ ░▒████▒   ▒██████▒▒ ░▒████▒ ▓█   ▓██▒ ░██▓ ▒██▒ ▒ ▓███▀ ░ ░▓█▒░██▓\r\n" +
        "  ▒ ░░     ▒ ░░▒░▒ ░░ ▒░ ░   ▒ ▒▓▒ ▒ ░ ░░ ▒░ ░ ▒▒   ▓▒█░ ░ ▒▓ ░▒▓░ ░ ░▒ ▒  ░  ▒ ░░▒░▒\r\n    ░      ▒ ░▒░ ░  ░ ░  ░   ░ ░▒  ░ ░  ░ ░  ░  ▒   ▒▒ ░   ░▒ ░ ▒░   ░  ▒     ▒ ░▒░ ░\r\n  ░        ░  ░░ ░    ░      ░  ░  ░      ░     ░   ▒      ░░   ░  ░          ░  ░░ ░\r\n           ░  ░  ░    ░  ░         ░      ░  ░      ░  ░    ░      ░ ░        ░  ░  ░\r\n                                                 ░                                   \r\n";

        bool exit = false;
        int Diff = 0; // Aktuális menüpont indexe

        



        public void Menu()
        {
            bool exit = true;
            int Diff = 0;
            while (exit)
            {

                string spacing = "\t\t\t";


                Console.Clear();
                DisplayIntro(Title, spacing);

                Print(spacing);
                ConsoleKeyInfo gomb = Console.ReadKey();
                if (gomb.Key == ConsoleKey.Escape || gomb.Key == ConsoleKey.Enter)
                {
                    exit = false;
                    try
                    {
                        funkciok[Diff].Invoke();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Hiányos funkció lista: {e.Message}");
                    }
                }
                else if (gomb.Key == ConsoleKey.S || gomb.Key == ConsoleKey.DownArrow)
                {
                    if (Diff + 1 < Szintek.Length)
                    {
                        Diff++;
                    }
                }
                else if (gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
                {
                    if (Diff - 1 >= 0)
                    {
                        Diff--;
                    }
                }

            }

            void Print(string spaceing)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{spaceing}\t\t     \x1b[3mFőmenu indítási opciók\x1b[0m\n");

                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╭".PadRight(30, '─')}╮");

                for (int i = 0; i < Szintek.Length; i++)
                {
                    Console.Write(spaceing + "\t\t  ");
                    if (i == Diff)
                    {

                        Console.Write($"\u001b[91m│\t   \x1b[93m> \x1b[92m{Szintek[i]}\x1b[39m{"".PadRight(19 - Szintek[i].Length, ' ')}\u001b[91m│");
                    }
                    else
                    {
                        Console.Write($"\u001b[91m│\t   \x1b[39m{Szintek[i]}{"".PadRight(21 - Szintek[i].Length, ' ')}\u001b[91m│");
                    }
                    Console.WriteLine();
                    Console.ResetColor();

                }
                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╰".PadRight(30, '─')}╯");
                Console.ResetColor();
            }
        }


        void New_Game()
        {
            

            while (!exit)
            {
                string spacing = "\t\t\t";

                Console.Clear();
                DisplayIntro(Title, spacing);

                Print(spacing); // A menü megjelenítése

                ConsoleKeyInfo gomb = Console.ReadKey();

                if (gomb.Key == ConsoleKey.Enter)
                {
                    bool isValid = valtozok.Where(x => x == "").Count() > 0;
                    if (!isValid)
                    {
                        exit = true;
                        Inditas();
                    }

                }

                else if (gomb.Key == ConsoleKey.Escape)
                {
                    exit = false;
                    try
                    {
                        Menu();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Hiányos funkció lista: {e.Message}");
                    }
                }

                else if (gomb.Key == ConsoleKey.S || gomb.Key == ConsoleKey.DownArrow)
                {
                    if (Diff + 1 < Szintek.Length)
                    {
                        Diff++; // Menüpont lefelé mozgatása
                    }
                }
                else if (gomb.Key == ConsoleKey.W || gomb.Key == ConsoleKey.UpArrow)
                {
                    if (Diff - 1 >= 0)
                    {
                        Diff--; // Menüpont felfelé mozgatása
                    }
                }
                else if (gomb.Key == ConsoleKey.Backspace && valtozok[Diff].Length > 0)
                {
                    // Backspace esetén az aktuális menüpont változójának utolsó karakterének törlése
                    valtozok[Diff] = valtozok[Diff].Substring(0, valtozok[Diff].Length - 1);
                }
                else if (char.IsDigit(gomb.KeyChar))
                {
                    // Ha a felhasználó számot nyom, akkor az aktuális menüpont változójához hozzáfűzzük a számot
                    if (valtozok[Diff].Length < 7) // Ha a szám kisseb mint 7 akkor adja hozzá
                    {
                        valtozok[Diff] += gomb.KeyChar;
                    }
                }
            }

            void Print(string spaceing)
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{spaceing}\t  \x1b[3mItt választhatod ki az alapértékeket\x1b[0m\n");

                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╭".PadRight(43, '─')}╮");

                for (int i = 0; i < Szintek.Length; i++)
                {
                    Console.Write(spaceing + "\t\t  ");
                    if (i == Diff)
                    {
                        // Az aktuális menüpont kiemelése és a hozzá tartozó változó megjelenítése
                        Console.Write($"\u001b[91m│\t   \x1b[93m> \x1b[92m{Szintek[i]}{valtozok[i]}\x1b[39m{"".PadRight(32 - Szintek[i].Length - valtozok[i].Length, ' ')}\u001b[91m│");
                    }
                    else
                    {
                        // Nem aktuális menüpont, csak az érték megjelenítése
                        Console.Write($"\u001b[91m│\t   \x1b[39m{Szintek[i]}{valtozok[i]}{"".PadRight(34 - Szintek[i].Length - valtozok[i].Length, ' ')}\u001b[91m│");
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }

                Console.WriteLine($"\x1b[91m{spaceing + "\t\t  "}{"╰".PadRight(43, '─')}╯");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{spaceing}\t  \u001b[3mNYILAK-kal tudsz mozogni és ENTER-el tudod fixálni/elindítani\x1b[0m\n");
                Console.ResetColor();
            }
        }//Még Nem Tartok itt


        public void DisplayIntro(string intro, string spacing)
        {
            Console.Clear();
            string[] lines = intro.Split('\n');
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (string line in lines)
            {
                Console.WriteLine(spacing + line);
            }
            Console.ResetColor();
        }


        void Inditas()
        {
            Console.Clear();
            Console.WriteLine(1);

        }
    }
}
