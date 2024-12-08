using System;
using System.Diagnostics.Metrics;
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

        public int NextDamage = 1;
        public string PName { get; init; }

        public string Last_P_Shot = "";
        public string Last_D_Shot = "";

        public int StarterItemsAmmount => 3;

        public int GetActorRounds(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;
            return character.SelfRounds;
        }

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

        public void Next(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;
            NextDamage = 1;
            character.SelfRounds = 1;
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


        //----------------------------------------------
        
        public List<string> GetActorUsedItems(string actor) => actor == "player"? player.UsedItems : dealer.UsedItems;
        public string ShowItems(string actor,out int counted)
        {
            ICharacter character = actor == "player" ? player : dealer;
            counted = character.Items.Count;
            return string.Join(',', character.Items);
        }

        public List<string> ActorItems(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;
            return character.Items;
        }
        
        
        public void ItemGen()
        {
            player.Items.Clear();
            dealer.Items.Clear();

            


            int shellCount = Shells.Count; // Jelenlegi Shell-ek száma (max 8)
            int maxItems = Math.Min(shellCount, 8); // Itemek száma nem lehet több, mint 8

            for (int i = 0; i < maxItems; i++)
            {
                // Véletlenszerű item hozzáadása a játékoshoz
                player.AddItem(ItemTypes.Usables[Random.Shared.Next(0, ItemTypes.Usables.Count)]);

                // Véletlenszerű item hozzáadása az ellenfélhez
                dealer.AddItem(ItemTypes.Usables[Random.Shared.Next(0, ItemTypes.Usables.Count)]);
            }
        }

        public void UsedItemReset()
        {
            player.UsedItems.Clear();
            dealer.UsedItems.Clear();
        }

        public void ItemGive()
        {
            int shellCount = Shells.Count; // Jelenlegi Shell-ek száma (max 8)
            int maxItems = Math.Min(shellCount, 8); // Itemek száma nem lehet több, mint 8
            for (int i = 0; i < maxItems; i++)
            {
                // Véletlenszerű item hozzáadása a játékoshoz
                player.AddItem(ItemTypes.Usables[Random.Shared.Next(0, ItemTypes.Usables.Count)]);

                // Véletlenszerű item hozzáadása az ellenfélhez
                dealer.AddItem(ItemTypes.Usables[Random.Shared.Next(0, ItemTypes.Usables.Count)]);
            }
        }

        public void ItemUse(string actor,string item,out string CurrentShell)
        {
            CurrentShell = "";
            ICharacter character = actor == "player" ? player : dealer;
            switch (item)
            {
                case "Beer":
                    ItemTypes.Beer(Shells,out string ShellEjected);
                    CurrentShell = ShellEjected;
                    break;
                case "Cuffs":
                    ItemTypes.Cuffs(character);
                    //Console.WriteLine("Work");
                    break;
                case "SpyGlass":
                    ItemTypes.SpyGlass(Shells,out string CRS);
                    CurrentShell = CRS;
                    break;
                case "Changer":
                    ItemTypes.Changer(Shells,out CRS);
                    CurrentShell = CRS;
                    break;
                case "Knife":
                    ItemTypes.Knife(out int cdmg);
                    NextDamage = cdmg;
                    break;
                case "Cigaretta":
                    ItemTypes.Cigaretta(character,StarterEnergy);
                    break;
            }
            character.RemoveItem(item);
            character.AddUsed(item);
        }
        public void SelfRoundReset(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;

            character.SelfRounds = 1;
        }
        public void AddRound(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;
            if(GetActorRounds(actor)+1 != 2)
            {
                character.SelfRounds++;
            }
        }
        public void RemoveRound(string actor)
        {
            ICharacter character = actor == "player" ? player : dealer;
            if (GetActorRounds(actor) - 1 < 1)
            {
                character.SelfRounds = 1;
            }
            else
            {
                character.SelfRounds--;
            }
        }
        //--------------------------------------------------


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
                //if (character.Energy - 1 >= 0)
                //{
                //    character.Energy--;
                //}
                character.DMG(NextDamage);
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


        
        
        public void DealerRound(string actor, out string ChosedAction,out string chosenItem)
        {
            Random r = new Random();
            ChosedAction = string.Empty;
            chosenItem = "0";

            ICharacter character = actor == "player" ? player : dealer;

            bool logic = r.Next(0, 100) < 60;

            if (logic)
            {
                // Ha van tárgy és logikusan használható
                if (character.Items.Count > 0)
                {
                    int itemIndex = r.Next(0, character.Items.Count);
                    chosenItem = character.Items[itemIndex];
                    ItemUse(actor, chosenItem, out string CurrentShell);
                    
                    ChosedAction = $"Used {chosenItem}";
                }
                else if (!Shells.Contains("Live") && Shells.Count > 2)
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
