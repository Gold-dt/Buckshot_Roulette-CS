using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Dealer : ICharacterStats
    {
        public int Health { get; set; }
        public List<string> Items { get; set; } = new List<string>();

        public Dealer(int health)
        {
            Health = health;
        }

    }
}
