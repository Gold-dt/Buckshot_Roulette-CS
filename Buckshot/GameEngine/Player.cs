using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player : ICharacter
    {
        public int Energy { get;  set; }
        public string Name { get; init; }
        public int SelfRounds { get; set; } = 1;
        public List<string> Items { get; private set; } = new List<string>();

        public Player(int StarterEnergy,string name)
        {
            Energy = StarterEnergy;
            Name = name;
        }
        public Player(int StarterEnergy)
        {
            Energy = StarterEnergy;
            
        }
        public void AddItem(string item)
        {
            if (Items.Count() < 8)
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(string item)
        {
            if (item.Contains(item))
            {
                Items.Remove(item);
            }
        }
        public void DMG(int dmg)
        {
            if(Energy-dmg < 0)
            {
                Energy = 0;
            }
            else
            {
                Energy -= dmg;
            }
        }
    }
}
