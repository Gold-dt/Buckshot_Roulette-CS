using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Functions
    {
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
    }
}
