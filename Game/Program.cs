using System;
using GameLib;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<string> test = new List<string>()
            {
                "Gold_dt;21;1;1;Kö:2","Enigma;1;2;2;Fö:102,Fa:32"
            };

            Engine engine = new(test);
            MainMenu menu;
            engine.ProfileName = "Gold_dt";

            string[] MainMenu = { "Name Change","Load Game","New Game" };

            menu = new(MainMenu);
            //menu.Menu();








        }
    }
}