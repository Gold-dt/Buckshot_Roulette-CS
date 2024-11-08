using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Dealer
    {
        public int Health { get; set; }
        public string[] items { get; set; } = { };

        public Dealer(int health)
        {
            Health = health;
        }

    }
}
