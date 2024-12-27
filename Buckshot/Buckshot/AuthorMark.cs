using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Buckshot
{
    public class AuthorMark
    {
        public void ProjectINFO()
        {
            string text = "Welcome to the\x1b[91m \x1b[4mBuckShot\x1b[24m \x1b[39mProject made by \x1b[93mGold_dt\x1b[39m!\r\nBuilt with \x1b[95mC#\x1b[39m, \x1b[95m.NET 8.0\x1b[39m, it leverages \x1b[96mmodern\x1b[39m features and tools.\r\nThe main focus is on \x1b[92mefficiency\x1b[39m, \x1b[94mcreativity\x1b[39m and training.\r\nFeel free to explore and make it your own in the conditions that being marked\r\nin github MIT licanse and in other files!\n\nCopyright: \x1b[91m© \x1b[3m2024 \x1b[4mGold_dt\x1b[24m. All rights reserved.\x1b[0m";

            string art =
                "⠀\t ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣤⣤⣤⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n\t⠀⠀⠀⠀⠀⠀⠀⣠⡴⠞⠛⠉⠉⠉⠀⠈⠉⠉⠙⠛⠷⢦⣀⠀⠀⠀⠀⠀⠀⠀\r\n\t⠀⠀⠀⠀⢀⣴⠟⢁⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣄⡉⠳⣄⠀⠀⠀⠀⠀\r\n\t⠀⠀⠀⣠⠟⢁⣴⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⣿⣿⣦⠈⢳⡄⠀⠀⠀\r\n\t⠀⠀⣰⠏⢠⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣷⡀⢻⡄⠀⠀\r\n\t⠀⢰⡟⠀⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣷⠈⣿⡀⠀\r\n\t⠀⣾⡇⢸⣿⣿⣿⣿⣿⣿⣿⣿⠟⣀⣤⣄⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⡄⢸⡇⠀\r\n\t⠀⣿⠀⠘⠛⠛⠛⠛⠛⠛⠛⠃⢸⣿⣿⣿⣷⠀⠛⠛⠛⠛⠛⠛⠛⠛⠃⢸⡇⠀\r\n\t⠀⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⠿⠿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⡇⠀\r\n\t⠀⠸⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣶⣶⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠁⠀\r\n\t⠀⠀⠹⣇⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⣼⠃⠀⠀\r\n\t⠀⠀⠀⠘⢧⡀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠀⠀⠀⣠⡾⠁⠀⠀⠀\r\n\t⠀⠀⠀⠀⠈⠻⢦⣀⠀⠸⢿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠀⠀⣠⡾⠋⠀⠀⠀⠀⠀\r\n\t⠀⠀⠀⠀⠀⠀⠀⠉⠛⠶⣦⣤⣀⣉⣉⣉⣁⣠⣤⣴⠶⠛⠁⠀⠀⠀⠀⠀⠀⠀\r\n\t⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀";
            string author = 
                " ██████╗  ██████╗ ██╗     ██████╗     ██████╗ ████████╗\r\n██╔════╝ ██╔═══██╗██║     ██╔══██╗    ██╔══██╗╚══██╔══╝\r\n██║  ███╗██║   ██║██║     ██║  ██║    ██║  ██║   ██║   \r\n██║   ██║██║   ██║██║     ██║  ██║    ██║  ██║   ██║   \r\n╚██████╔╝╚██████╔╝███████╗██████╔╝    ██████╔╝   ██║   \r\n ╚═════╝  ╚═════╝ ╚══════╝╚═════╝     ╚═════╝    ╚═╝   ";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            Console.WriteLine(art);

            Console.ResetColor();
            int autI = 2;
            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.SetCursorPosition(40, autI);
            for (int i = 0; i < author.Length; i++)
            {
                if (author[i] == '\n')
                {
                    autI++; // Következő sor
                    Console.SetCursorPosition(40, autI); // Ugyanazon oszlopban a következő sor
                }
                else
                {
                    Console.Write(author[i]);
                }
                //Thread.Sleep(50);
            }
            Console.ResetColor();
            int indexer = 9;
            Console.SetCursorPosition(40, indexer);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '\n')
                {
                    indexer++; // Következő sor
                    Console.SetCursorPosition(40, indexer); // Ugyanazon oszlopban a következő sor
                }
                else
                {
                    Console.Write(text[i]);
                }
                Thread.Sleep(50);
            }
            Console.SetCursorPosition(40, 17);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\x1b[3mPress Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }


    }
}
