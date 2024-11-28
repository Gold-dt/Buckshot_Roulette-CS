using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Dealer : ICharacter
    {
        public int Energy { get;  set; }
        public int SelfRounds { get; set; } = 1;
        public List<string> Items { get; private set; } = new List<string>();
        public List<string> UsedItems { get; private set; } = new List<string>();

        public Dealer(int StarterEnergy)
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
        public void AddUsed(string Item)
        {
            UsedItems.Add(Item);
        }
        public void RemoveItem(string item)
        {


            for (int i = 0; i < Items.Count(); i++)
            {
                if (item == Items[i])
                {
                    Items.RemoveAt(i);
                }
            }
        }
        public void DMG(int dmg)
        {
            if (Energy - dmg < 0)
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
