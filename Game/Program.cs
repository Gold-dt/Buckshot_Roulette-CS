using System;
using GameLib;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> test = new List<string>()
            {
                "Gold_dt;21;1;1;Kö:2","Enigma;1;2;2;Fö:102,Fa:32"
            };

            Engine engine = new(test);
            Functions functions = new();
            engine.ProfileName = "Gold_dt";


            Console.OutputEncoding = System.Text.Encoding.UTF8;


            functions.DisplayIntro(engine.Tittle, "\t\t");
            
            




        }
    }
}