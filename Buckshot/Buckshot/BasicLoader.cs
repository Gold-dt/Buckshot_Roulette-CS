using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckshot
{
    internal class BasicLoader
    {
        public List<string> Valasz = new List<string>();


        public void Kerdes(string Question, string[] Answers, ConsoleColor KerdesSzin = ConsoleColor.White, ConsoleColor KerdesHatter = ConsoleColor.Black, ConsoleColor ValaszHatter = ConsoleColor.Black, ConsoleColor ValaszSzin = ConsoleColor.White)
        {
            int Answer = 0;
            bool Exit = false;

            Console.CursorVisible = false;

            while (!Exit)
            {
                Console.ForegroundColor = KerdesSzin;
                Console.BackgroundColor = KerdesHatter;
                // Fő kérdés
                Console.Write(Question);
                Console.ResetColor();
                for (int i = 0; i < Answers.Length; i++)
                {
                    if (i == Answer)
                    {
                        Console.Write("\x1b[4m");
                        // Ha kivan választva a válasz
                        Console.Write($"{Answers[i]}");
                    }
                    else
                    {
                        Console.Write("\x1b[24m");
                        // Egyébb válasz
                        Console.Write($"{Answers[i]}");
                    }
                    Console.Write("\x1b[24m");
                    if (i < Answers.Length - 1)
                    {
                        // Elválasztás
                        Console.Write(" \\ ");
                    }
                }
                Console.ResetColor();
                Select();
                Console.SetCursorPosition(0, Console.CursorTop);

                // Kiírunk annyi szóközt, amennyi a konzol szélessége
                Console.Write(new string(' ', Console.WindowWidth));

                // Visszaállítjuk a kurzort a sor elejére
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            void SorCsere()//Ez törli vissza és írja ki a végén 
            {
                Console.SetCursorPosition(0, Console.CursorTop);

                // Kiírunk annyi szóközt, amennyi a konzol szélessége
                Console.Write(new string(' ', Console.WindowWidth));

                // Visszaállítjuk a kurzort a sor elejére
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.ForegroundColor = KerdesSzin;
                Console.BackgroundColor = KerdesHatter;
                Console.Write($"{Question}");
                Console.BackgroundColor = ValaszHatter;
                Console.ForegroundColor = ValaszSzin;
                Valasz.Add(Answers[Answer]);
                Console.Write($" {Answers[Answer]} ");
                Console.ResetColor();
                Console.WriteLine();
            }

            void Select()
            {
                ConsoleKeyInfo gomb = Console.ReadKey();
                if (gomb.Key == ConsoleKey.Enter)
                {
                    Exit = true;
                    SorCsere();
                }
                else if (gomb.Key == ConsoleKey.A || gomb.Key == ConsoleKey.LeftArrow)
                {
                    if (Answer - 1 >= 0)
                    {
                        Answer--;
                    }
                }
                else if (gomb.Key == ConsoleKey.D || gomb.Key == ConsoleKey.RightArrow)
                {
                    if (Answer + 1 <= Answers.Length - 1)
                    {
                        Answer++;
                    }
                }
            }
        }

    }
}
