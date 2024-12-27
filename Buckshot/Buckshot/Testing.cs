using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckshot
{
    internal class Testing
    {
        public void Test()
        {
            int Round = 1;
            int MaxRound = 5;
            int LastRound = 0;
            int margin = 10 - 5 - Round.ToString().Length - MaxRound.ToString().Length;
            string tab = "\t\t\t\t\t\t      ";

            // Első kijelzés
            Console.WriteLine("\n\n");
            Console.WriteLine($"{tab}╭{"─".PadLeft(10, '─')}╮\n{tab}│   {LastRound}/{MaxRound}{"".PadLeft(margin, ' ')} │\n{tab}╰{"─".PadLeft(10, '─')}╯");
            Thread.Sleep(1500);
            Console.Clear();

            // Második kijelzés villogással
            
            for (int i = 0; i < 4; i++) // 4 ciklus = 2 teljes villogás
            {
                // Sima szín
                Console.Clear();
                Console.Write($"\n\n\n{tab}╭{"─".PadLeft(10, '─')}╮\n{tab}│   ");
                Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.DarkYellow : ConsoleColor.Yellow; // Szín váltása
                Console.Write($"{Round}/{MaxRound}");
                Console.ResetColor();
                Console.Write($"{"".PadLeft(margin, ' ')} │\n{tab}╰{"─".PadLeft(10, '─')}╯");
                Thread.Sleep(700); // Fél másodperc várakozás
            }
        }
    }
}
