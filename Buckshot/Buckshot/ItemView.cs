using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Buckshot
{
    public class ItemView
    {
        string tab = "\t\t\t\t";
        public string Shotgun = " ,______________________________________       \r\n|_________________,----------._ [____]  \"\"-,__  __....-----=====\r\n               (_(||||||||||||)___________/   \"\"                |\r\n                  `----------'        [ ))\"-,                   |\r\n                                       \"\"    `,  _,--....___    |\r\n                                               `/           \"\"\"\" ";
        public string ShawedOFF = " ,________________________________       \r\n|__________,----------._ [____]  \"\"-,__  __...-----===\"\r\n        (_(||||||||||||)___________/   \"\"             |\r\n           `----------'        [ ))\"-,                |\r\n                                \"\"    `,  _,--...___  |\r\n                                        `/          \"\"\"";
        public string Knife = "___________________________________ ______________________\r\n \\                                  | (_)     (_)    (_)   \\\r\n  `.                                |  __________________   }\r\n    `-..........................____|_(                  )_/";
        public string Glass = "    \t   ______  \r\n        .-'      `-.           \r\n       .'            `.         \r\n      /                \\        \r\n     ;                 ;`       \r\n     |                 |;       \r\n     ;                 ;|\r\n     '\\               / ;       \r\n      \\`.           .' /        \r\n       `.`-._____.-' .'         \r\n         / /`_____.-'           \r\n        / / /                   \r\n       / / /\r\n      / / /\r\n     / / /\r\n    / / /\r\n   / / /\r\n  / / /\r\n / / /\r\n/ / /\r\n\\/_/";
        public string ActiveGlass = "            ______              \r\n         .-'      `-.           \r\n       .'            `.         \r\n      /      \x1b[91m __\x1b[39m       \\        \r\n     ;       \x1b[91m|##|\x1b[39m      ;`       \r\n     |       \x1b[91m|##|\x1b[39m      |;       \r\n     ;       \x1b[91m|##|\x1b[39m      ;|\r\n     '\\      \x1b[91m****\x1b[39m     / ;       \r\n      \\`.           .' /        \r\n       `.`-._____.-' .'         \r\n         / /`_____.-'           \r\n        / / /                   \r\n       / / /\r\n      / / /\r\n     / / /\r\n    / / /\r\n   / / /\r\n  / / /\r\n / / /\r\n/ / /\r\n\\/_/";
        public string BlankGlass = "            ______              \r\n         .-'      `-.           \r\n       .'            `.         \r\n      /       \x1b[94m__\x1b[39m       \\        \r\n     ;       \x1b[94m|  |\x1b[39m      ;`       \r\n     |       \x1b[94m|  |\x1b[39m      |;       \r\n     ;       \x1b[94m|  |\x1b[39m      ;|\r\n     '\\      \x1b[94m****\x1b[39m     / ;       \r\n      \\`.           .' /        \r\n       `.`-._____.-' .'         \r\n         / /`_____.-'           \r\n        / / /                   \r\n       / / /\r\n      / / /\r\n     / / /\r\n    / / /\r\n   / / /\r\n  / / /\r\n / / /\r\n/ / /\r\n\\/_/";

        public string Cigarette_1 = "    a,  8a\r\n     `8, `8)                            ,adPPRg,\r\n      8)  ]8                        ,ad888888888b\r\n     ,8' ,8'                    ,gPPR888888888888\r\n    ,8' ,8'                 ,ad8\"\"   `Y888888888P\r\n    8)  8)              ,ad8\"\"        (8888888\"\"\r\n    8,  8,          ,ad8\"\"            d888\"\"\r\n    `8, `8,     ,ad8\"\"            ,ad8\"\"\r\n     `8, `\" ,ad8\"\"            ,ad8\"\"\r\n        ,gPPR8b           ,ad8\"\"\r\n       dP:::::Yb      ,ad8\"\"\r\n       8):::::(8  ,ad8\"\"\r\n       Yb:;;;:d888\"\"  \r\n        \"8ggg8P\"     ";
        public string Cigarette_2 = "    a,  8a\r\n     `8, `8)                            ,adPPRg,\r\n      8)  ]8                        ,ad888888888b\r\n     ,8' ,8'                    ,gPPR888888888888\r\n    ,8' ,8'                 ,ad8\"\"   `Y888888888P\r\n    8)  8)              ,ad8\"\"        (8888888\"\"\r\n    8,  8,          ,ad8\"\"            d888\"\"\r\n    `8, `8,     ,ad8\"\"            ,ad8\"\"\r\n     `8, `\" ,ad8\"\"            ,ad8\"\"\r\n        1,gPPR8b2           ,ad8\"\"\r\n       1dP:::::Yb2      ,ad8\"\"\r\n       18):::::(82  ,ad8\"\"\r\n       1Yb:;;;:d8288\"\"  \r\n        1\"8ggg8P\"2";
        public string Cigarette_3 = "    a,  8a\r\n     `8, `8)                            ,adPPRg,\r\n      8)  ]8                        ,ad888888888b\r\n     ,8' ,8'                    ,gPPR888888888888\r\n    ,8' ,8'                 ,ad8\"\"   `Y888888888P\r\n    8)  8)              ,ad8\"\"        (8888888\"\"\r\n    8,  8,          ,ad8\"\"            d888\"\"\r\n    `8, `8,     ,ad8\"\"            ,ad8\"\"\r\n     `8, `\" ,ad8\"\"            ,ad8\"\"\r\n        3,gPPR8b2           ,ad8\"\"\r\n       3dP:::::Yb2      ,ad8\"\"\r\n       38):::::(82  ,ad8\"\"\r\n       3Yb:;;;:d8288\"\"  \r\n        3\"8ggg8P\"2";

        public string Cuff = "      .::::::::::.                          .::::::::::.\r\n    .::::''''''::::.                      .::::''''''::::.\r\n  .:::'          `::::....          ....::::'          `:::.\r\n .::'             `:::::::|        |:::::::'             `::.\r\n.::|               |::::::|_ ___ __|::::::|               |::.\r\n`--'               |::::::|_()__()_|::::::|               `--'\r\n :::               |::-o::|        |::o-::|               :::\r\n `::.             .|::::::|        |::::::|.             .::'\r\n  `:::.          .::\\-----'        `-----/::.          .:::'\r\n    `::::......::::'                      `::::......::::'\r\n      `::::::::::'                          `::::::::::'";
        public string Live = " __ \r\n|##|\r\n|##|\r\n|##|\r\n****";
        public string Blank = " __ \r\n|  |\r\n|  |\r\n|  |\r\n****";

        public void Show(string item,string CurrentShell)
        {
            switch (item)
            {
                case "Beer":
                    
                    break;
                case "Cuffs":
                    UseCuff();
                    break;
                case "SpyGlass":
                    UseGlass(CurrentShell);
                    break;
                case "Changer":
                    UseChanger(CurrentShell);
                    break;
                case "Knife":
                    
                    break;
                case "Cigaretta":
                    UseCigarette();
                    break;
            }
        }

        void Shower(string item,string tabb,bool colorneed)
        {
            Console.Write(tabb);
            for (int i = 0; i < item.Length; i++)
            {
                if (colorneed)
                {


                    if (item[i] == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        continue;
                    }
                    else if (item[i] == '3')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        continue;
                    }
                    else if (item[i] == '2')
                    {
                        Console.ResetColor();
                        continue;
                    }
                }
                if (item[i] == '\n')
                {
                    Console.Write($"\n{tabb}");
                }
                else
                {
                    Console.Write(item[i]);
                }
            }
        }
        
        public void UseCuff()
        {
            string tabb = "";

            for (int i = 0; i < 5; i++)
            {
                tabb += "\t";
                Console.Clear();
                if (i < 3) Shower(Cuff, tabb, false);
                else Shower(Cuff, tabb, false);
                Thread.Sleep(400);
            }
        }
        public void UseGlass(string Shell)
        {
            string glass = Shell == "Live" ? ActiveGlass : BlankGlass;
            string tabb = "";
            
            for (int i = 0;i < 5;i++)
            {
                tabb += "\t";
                Console.Clear();
                if(i < 3) Shower(Glass, tabb,false);
                else Shower(glass,tabb,false);
                Thread.Sleep(400);
            }

        }
        public void UseCigarette()
        {
            string tab = "\t\t\t\t";
            Console.Clear();
            Shower(Cigarette_1,tab,true);
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Clear();
                Shower(Cigarette_2,tab,true);
                Thread.Sleep(500);
                Console.Clear();
                Shower(Cigarette_3, tab,true);
            }
        }

        public void UseChanger(string Shell)
        {
            string Current = Shell == "Live" ? Live : Blank;
            string CHD = Shell == "Live" ? Blank : Live;

            string tabb = "";

            for (int i = 0; i < 6; i++)
            {
                tabb += "\t";
                Console.Clear();
                if (i < 3)
                {
                    Shower(Current, tabb, false);
                }
                else if(i == 3)
                {
                    Shower(Current, tabb, false);
                    Thread.Sleep(1500);
                    Console.Clear();
                    Shower(Current, tabb, false);
                    Thread.Sleep(1500);
                    Console.Clear();
                    Shower(CHD, tabb, false);
                }
                else
                {
                    Shower(CHD, tabb, false);
                }
                Thread.Sleep(400);
            }
        }

    }
}
