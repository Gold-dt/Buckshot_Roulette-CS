using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface ICharacterStats
    {
        int Health { get; set; }
        public List<string> Items { get; set; }
    }

}
