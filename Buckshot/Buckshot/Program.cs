using GameEngine;
using System;

namespace Buckshot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainEngine game = new("Gold", 5);
            string actor = "player";
            //while (true)
            //{
            //    game.NewShells();
            //    if (game.Shells.Count == 9)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }
            //    Console.WriteLine(game);
            //    Console.ResetColor();
            //    Console.ReadLine();
            //}
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
                    while (run)
                    {
                        Console.Write($"Q Dealer | E  Self | Shells({game.Shells.Count}): {string.Join(',', game.Shells)} ");
                        ConsoleKeyInfo gomb = Console.ReadKey();
                        if (gomb.Key == ConsoleKey.Q)
                        {
                            game.Shoot(actor);
                            run = false;
                        }
                        else if (gomb.Key == ConsoleKey.E)
                        {
                            game.MeShoot(actor);
                            run = false;
                        }

                    }
                    Console.WriteLine($"\nPlayer: {game.Energys(actor)} Dealer: {game.Energys("dealer")} Lowest: {game.LowestEnergy()} ");
                    Console.ReadLine();
                }

            }
        }
    }
}