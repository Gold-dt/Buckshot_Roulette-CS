using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player
    {
        public string Name { get; init; }
        public int Health { get; set; }
        public string[] Items { get; set; } = { };

        public Player(string name,int health)
        {
            Name = name;
            Health = health;
        }

    }
}
