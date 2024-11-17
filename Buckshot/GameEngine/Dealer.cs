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
        public List<string> Items { get; private set; }

        public Dealer(int StarterEnergy)
        {
            Energy = StarterEnergy;
        }
        public void AddItem(string item)
        {
            if (Items.Count() < 8)
            {
                Items.Append(item);
            }
        }
        public void RemoveItem(string item)
        {


            for (int i = 0; i < Items.Count(); i++)
            {
                if (item == Items[i])
                {

                }
            }
        }
    }
}
