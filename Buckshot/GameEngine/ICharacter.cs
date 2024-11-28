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
        public void DMG(int dmg);
        public void AddUsed(string Item);
        public int SelfRounds { get; set; }

        public List<string> UsedItems { get; }
    }
}
