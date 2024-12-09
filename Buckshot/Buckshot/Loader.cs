using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckshot
{
    public class Loader
    {
        public void LoadingAnimation(int duration, bool useSpinner = true)
        {
            if (useSpinner)
            {
                // Forgó kerék animáció
                char[] spinner = { '|', '/', '-', '\\' };
                DateTime end = DateTime.Now.AddSeconds(duration);

                int counter = 0;
                while (DateTime.Now < end)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Finalizing... " + spinner[counter % spinner.Length]);
                    counter++;
                    Thread.Sleep(100); // Frissítés 100 ms-onként
                }

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Finalizing... Done!    "); // Töröljük a forgó kerék nyomát
                Console.ResetColor();
            }
            else
            {
                // Progress bar animáció
                int total = 50; // A progress bar szélessége
                DateTime end = DateTime.Now.AddSeconds(duration);

                while (DateTime.Now < end)
                {
                    double elapsed = (DateTime.Now - (end - TimeSpan.FromSeconds(duration))).TotalSeconds;
                    int progress = (int)(total * (elapsed / duration));

                    Console.SetCursorPosition(0, 0);
                    Console.Write("[");
                    Console.Write(new string('#', progress));
                    Console.Write(new string('-', total - progress));
                    Console.Write($"] {progress * 2}%"); // A százalékérték
                    Thread.Sleep(100);
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("[##################################################] 100%"); // Teljes progress bar
            }
        }
        public void FullLoader(int progressDuration, int spinnerDuration)
        {
            string tab = "\t\t\t\t";
            Console.Clear();
            // Progress bar animáció
            int total = 50; // A progress bar szélessége
            DateTime progressEnd = DateTime.Now.AddSeconds(progressDuration);

            while (DateTime.Now < progressEnd)
            {
                double elapsed = (DateTime.Now - (progressEnd - TimeSpan.FromSeconds(progressDuration))).TotalSeconds;
                int progress = (int)(total * (elapsed / progressDuration));

                Console.SetCursorPosition(0, 0);
                Console.Write($"{tab}[");
                if(progress < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if(progress<20)
                {
                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                }
                else if (progress < 40)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                }
                Console.Write(new string('#', progress));
                Console.Write(new string('-', total - progress));
                Console.Write($"] {progress * 2}%"); // A százalékérték
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{tab}[##################################################] 100%");
            Console.ResetColor();

            // Spinner animáció
            char[] spinner = { '|', '/', '-', '\\' };
            DateTime spinnerEnd = DateTime.Now.AddSeconds(spinnerDuration);

            int counter = 0;
            while (DateTime.Now < spinnerEnd)
            {
                Console.SetCursorPosition(0, 1); // A spinner a progress bar alatt jelenik meg
                Console.Write($"{tab}Finalizing... " + spinner[counter % spinner.Length]);
                counter++;
                Thread.Sleep(100);
            }

            Console.SetCursorPosition(70, 1);
            Console.WriteLine("Finalizing... Done!      "); // Tisztítás
        }

    }
}
