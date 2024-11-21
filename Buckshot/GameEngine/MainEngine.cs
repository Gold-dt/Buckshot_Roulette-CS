using System.Numerics;
using System.Xml.Linq;

namespace GameEngine
{
    public class MainEngine
    {
        public List<string> Shells = new List<string>();

        public int StarterEnergy { get; init; }
        public int Rounds => 3;
        public int Round { get; set; } = 1;

        public string PName { get; init; }

        public string Last_P_Shot;
        public string Last_D_Shot;

        public int StarterItemsAmmount => 3;
        

        Player player;
        Dealer dealer;
        Items ItemTypes = new();
        private int _lowest;

        public MainEngine(string name,int starterEnergy)
        {
            StarterEnergy = starterEnergy;
            player = new(starterEnergy,name);
            dealer = new(starterEnergy);
            _lowest = starterEnergy;
            PName = name;
        }

        public void NextRound()
        {
            player = new(StarterEnergy, PName);
            dealer = new(StarterEnergy);
            _lowest = StarterEnergy;
            NewShells();
            Round++;
        }


        public string[] FakeShells()
        {
            Random rand = new Random();

            
            var shuffled = Shells.ToArray();

            
            for (int i = shuffled.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
            }

            
            for (int k = 0; k < shuffled.Length * 2; k++)
            {
                int a = rand.Next(shuffled.Length);
                int b = rand.Next(shuffled.Length);
                (shuffled[a], shuffled[b]) = (shuffled[b], shuffled[a]);
            }

            
            for (int l = 0; l < shuffled.Length / 2; l++)
            {
                int m = rand.Next(shuffled.Length);
                int n = (m + 1) % shuffled.Length; 
                (shuffled[m], shuffled[n]) = (shuffled[n], shuffled[m]);
            }

            return shuffled;
        }



        public void NewShells()
        {
            Shells.Clear();
            string[] shelltypes = ["Blank","Live"];
            Random random = new Random();
            for (int i = 0; i < random.Next(3,9); i++)
            {
                string shell = shelltypes[random.Next(shelltypes.Length)];
                Shells.Add(shell);
            }
            
        }
        
        public void NewItems(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;

            
        }

        public void ShowItems()
        {
            Console.WriteLine(string.Join(',',ItemTypes.Usables));
        }

        public void Shoot(string actor)
        {
            ICharacter character = actor == "player" ? dealer : player; 


            validate(character, out string current);
            
            if (actor == "player")
            {
                Last_P_Shot = current;
            }
            else
            {
                Last_D_Shot = current;
            }
            UpdateLowestEnergy();
        }

        public void MeShoot(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer; 

            validate(character,out string current);
            
            if(actor == "player")
            {
                Last_P_Shot = current;
            }
            else
            {
                Last_D_Shot= current;
            }
            UpdateLowestEnergy();
        }

        public void validate(ICharacter character,out string current)
        {
            current = Shells.First();
            if (current == "Live")
            {
                if (character.Energy - 1 >= 0)
                {
                    character.Energy--;
                }
            }
            else if(current == "Blank")
            {
                //no content
            }
            Shells.RemoveAt(0);            
        }

        
        

        public int LowestEnergy() => _lowest;

        

        private void UpdateLowestEnergy()
        {
            _lowest = dealer.Energy > player.Energy ? player.Energy : dealer.Energy;
            
        }


        public int Energys(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;
            
            return character.Energy;
        }

        public override string ToString()
        {
            return $"GameData\n\tRounds: {Rounds}\n\tShells({Shells.Count}): {string.Join(',', Shells)}\n\tStarterEnergy: {StarterEnergy}\nPlayer\n\tPName: {player.Name}\n\tEnergy: {player.Energy}\nDealer:\n\tEnergy: {dealer.Energy}";
        }


        //----------------------------------------------------------


        public void DealerRoundHard(string actor, out string ChosedAction)
        {
            Random r = new Random();

            // Játékállapot
            int dealerEnergy = Energys("dealer");
            int playerEnergy = Energys("player");
            int liveShells = Shells.Count(s => s == "Live");
            int blankShells = Shells.Count(s => s == "Blank");
            int totalShells = Shells.Count;

            // Kulcsfontosságú logikai feltételek
            bool playerVulnerable = playerEnergy <= 1; // Az ellenfél könnyen legyőzhető
            bool dealerVulnerable = dealerEnergy <= 1; // A dealer kockázatban van
            bool canEliminatePlayer = liveShells >= 1 && playerVulnerable; // Lehetséges nyerés
            bool saveDealer = liveShells > blankShells && dealerVulnerable; // Dealer megmentése fontos

            // Első helyzetek: 1 shell maradt
            if (totalShells == 1)
            {
                if (Shells.First() == "Live")
                {
                    Shoot(actor); // Ha élő shell az utolsó, lőjön a játékosra
                    ChosedAction = "Shoot";
                }
                else
                {
                    MeShoot(actor); // Ha üres shell az utolsó, célozza magát
                    ChosedAction = "MeShoot";
                }
            }
            else if (liveShells == 0) // Nincs több élő shell, csak védekezés
            {
                MeShoot(actor);
                ChosedAction = "MeShoot";
            }
            else
            {
                // Haladó logika döntéshozás
                if (canEliminatePlayer && r.Next(0, 100) < 95) // Ha megölheti a játékost, tegye meg
                {
                    Shoot(actor);
                    ChosedAction = "Shoot";
                }
                else if (saveDealer && r.Next(0, 100) < 85) // Ha saját energiája alacsony, célozza magát
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
                else if (dealerEnergy > playerEnergy && r.Next(0, 100) < 80) // Ha dealer előnyben van, támadjon
                {
                    Shoot(actor);
                    ChosedAction = "Shoot";
                }
                else if (dealerVulnerable && r.Next(0, 100) < 70) // Ha dealer veszélyben van, védekezzen
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
                else // Véletlen ritka hibázás
                {
                    if (r.Next(0, 2) == 0)
                    {
                        Shoot(actor);
                        ChosedAction = "Shoot";
                    }
                    else
                    {
                        MeShoot(actor);
                        ChosedAction = "MeShoot";
                    }
                }
            }
        }


        public void DealerRoundMedium(string actor, out string ChosedAction)
        {
            Random r = new Random();

            // Különböző döntési súlyozások
            int dealerEnergy = Energys("dealer");
            int playerEnergy = Energys("player");

            // Logika súlyozása a körülmények alapján
            bool preferSelf = Shells.Contains("Live") && dealerEnergy > 2 && Shells.Count > 1;
            bool preferShoot = dealerEnergy > playerEnergy || Shells.Count == 1;

            // Alapvető döntési logika: súlyozott preferencia
            if (r.Next(0, 100) < 80) // 70%-ban stratégiai döntést hoz
            {
                if (Shells.Count == 1) // Ha csak egy shell maradt
                {
                    if (Shells.First() == "Live")
                    {
                        Shoot(actor);
                        ChosedAction = "Shoot";
                    }
                    else
                    {
                        MeShoot(actor);
                        ChosedAction = "MeShoot";
                    }
                }
                else if (preferSelf) // Amikor inkább saját magát célozza
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
                else if (preferShoot) // Amikor inkább az ellenfelet támadja
                {
                    Shoot(actor);
                    ChosedAction = "Shoot";
                }
                else // Alapértelmezett eset, véletlenszerű döntés
                {
                    int actions = r.Next(0, 2);
                    if (actions == 0)
                    {
                        Shoot(actor);
                        ChosedAction = "Shoot";
                    }
                    else
                    {
                        MeShoot(actor);
                        ChosedAction = "MeShoot";
                    }
                }
            }
            else // 30%-ban véletlenszerű döntés, hogy ne legyen kiszámítható
            {
                int actions = r.Next(0, 2);
                if (actions == 0)
                {
                    Shoot(actor);
                    ChosedAction = "Shoot";
                }
                else
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
            }
        }

        public void DealerRound(string actor, out string ChosedAction)
        {
            Random r = new Random();

            bool logic = r.Next(0, 100) < 60;

            if (logic == true)
            {
                if (Shells.Contains("Live") == false && Shells.Count > 2)
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
                else if (Shells.Count == 1)
                {
                    if (Shells.First() == "Live")
                    {
                        Shoot(actor);
                        ChosedAction = "Shoot";
                    }
                    else
                    {
                        MeShoot(actor);
                        ChosedAction = "MeShoot";
                    }
                }
                else
                {
                    int actions = r.Next(0, 2);
                    if (actions == 0)
                    {
                        Shoot(actor);
                        ChosedAction = "Shoot";
                    }
                    else
                    {
                        MeShoot(actor);
                        ChosedAction = "MeShoot";
                    }
                }
            }
            else
            {
                int actions = r.Next(0, 2);
                if (actions == 0)
                {
                    Shoot(actor);
                    ChosedAction = "Shoot";
                }
                else
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
            }



        }
    }
}
