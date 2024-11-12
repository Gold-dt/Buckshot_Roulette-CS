using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Player : ICharacterStats
    {
        public string Name { get; init; }
        public int Health { get; set; }
        public List<string> Items { get; set; } = new List<string>();

        public Player(string name,int health)
        {
            Name = name;
            Health = health;
        }
        public Player(int health)
        {
            Health = health;
        }

    }
}
