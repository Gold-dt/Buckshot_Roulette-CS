using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buckshot
{
    internal class Menu
    {
        void display(
            string[] NameChar)
        {
            string text =  "\n--------------------------------" +
                           "\n| GENERAL RELEASE OF LIABILITY |" +
                           "\n|                              |" +
                           "\n| &%$ @#$!@ !@$ $*#^@%@! $*@$! |" +
                           "\n| * %^#$ &#^$ !%^ &&^ %$@^$#$^ |" +
                           "\n| @#$ %&^ %$# @!@# $%^& &^% *^ |" +
                           "\n| !#! $@% #@* %&# %$@! %$^&%&* |" +
                           "\n| % $%$ $%^%$ #*& @!@# $%^& &^ |" +
                          $"\n| sign here {string.Join(' ',NameChar)}             |" +
                           "\n|                              |" +
                           "\n--------------------------------" +
                           "";
            Console.WriteLine(text);
        }
        public void SetName(out string name)
        {
            name = "Gold";


            string[] NameChar = new string[5];

            int index = 0;
            bool run = true;

            while (run)
            {
                display(NameChar);
                ConsoleKeyInfo gomb = Console.ReadKey();
                if(char.IsLetter(gomb.KeyChar))
                {
                    if (NameChar.Count() + 1 != 6)
                    {


                        NameChar[index] = gomb.Key.ToString();
                        index++;
                        Console.WriteLine(string.Join(' ',NameChar));
                    }
                }
            }




            //Console.WriteLine("\n--------------------------------" +
            //                  "\n| GENERAL RELEASE OF LIABILITY |" +
            //                  "\n|                              |" +
            //                  "\n| &%$ @#$!@ !@$ $*#^@%@! $*@$! |" +
            //                  "\n| * %^#$ &#^$ !%^ &&^ %$@^$#$^ |" +
            //                  "\n| @#$ %&^ %$# @!@# $%^& &^% *^ |" +
            //                  "\n| !#! $@% #@* %&# %$@! %$^&%&* |" +
            //                  "\n| % $%$ $%^%$ #*& @!@# $%^& &^ |" +
            //                  "\n| sign here ______             |" +
            //                  "\n|                              |" +
            //                  "\n--------------------------------" +
            //                  "");


        }
    }
}
