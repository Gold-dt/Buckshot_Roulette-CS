using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface ICharacter
    {
        public int Energy { get;  set; }
        public List<string> Items { get; }

        public void AddItem(string item);
        public void RemoveItem(string item);
    }
}
