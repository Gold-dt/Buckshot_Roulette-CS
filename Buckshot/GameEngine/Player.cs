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
        public List<string> Items { get; private set; }

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
            if(Items.Count()<8)
            {
                Items.Append(item);
            }
        }
        public void RemoveItem(string item)
        {


            for(int i = 0; i < Items.Count(); i++)
            {
                if(item == Items[i])
                {

                }
            }
        }
    }
}
