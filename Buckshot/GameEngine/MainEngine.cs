using System.Numerics;

namespace GameEngine
{
    public class MainEngine
    {
        public List<string> Shells = new List<string>();

        public int StarterEnergy { get; init; }
        public int Rounds => 3;
        public int Round => 1;

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
            string[] shelltypes = ["blank","live"];
            Random random = new Random();
            for (int i = 0; i < random.Next(3,9); i++)
            {
                string shell = shelltypes[random.Next(shelltypes.Length)];
                Shells.Add(shell);
            }
        }


        public void Shoot(string actor)
        {
            ICharacter character = actor == "player" ? dealer : player; // Reversed (if actor = player => dealer)


            validate(character, out string current);
            Console.WriteLine("\t" + current);

            UpdateLowestEnergy();
        }

        public void MeShoot(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer; // Reversed (if actor = player => dealer)

            validate(character,out string current);
            Console.WriteLine("\t"+current);
            
            UpdateLowestEnergy();
        }

        public void validate(ICharacter character,out string current)
        {
            current = Shells.First();
            if (current == "live")
            {
                if (character.Energy - 1 >= 0)
                {
                    character.Energy--;
                }
            }
            else if(current == "blank")
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
