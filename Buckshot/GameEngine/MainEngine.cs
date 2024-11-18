using System.Numerics;

namespace GameEngine
{
    public class MainEngine
    {
        public List<string> Shells = new List<string>();

        public int StarterEnergy { get; init; }
        public int Rounds => 3;
        public int Round => 1;

        public string Last_P_Shot;
        public string Last_D_Shot;

        Player player;
        Dealer dealer;
        private int _lowest;

        public MainEngine(string name,int starterEnergy)
        {
            StarterEnergy = starterEnergy;
            player = new(starterEnergy,name);
            dealer = new(starterEnergy);
            _lowest = starterEnergy;
        }

        public void NextRound()
        {
            player = new(StarterEnergy);
            dealer = new(StarterEnergy);
            
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
        public void DealerRound(string actor,out string ChosedAction)
        {
            Random r = new Random();
            
            bool logic = r.Next(0,100) < 60;

            if(logic == true)
            {
                if(Shells.Contains("Live") == false && Shells.Count > 2)
                {
                    MeShoot(actor);
                    ChosedAction = "MeShoot";
                }
                else if(Shells.Count == 1)
                {
                    if(Shells.First() == "Live")
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

        public void Shoot(string actor)
        {
            ICharacter character = actor == "player" ? dealer : player; // Reversed (if actor = player => dealer)


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
            ICharacter character = actor == "player" ? player : dealer; // Reversed (if actor = player => dealer)

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
    }
}
