using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Items
    {
        public List<string> Usables = new List<string>() 
        {
         "Beer","Cuffs","SpyGlass","Changer"
        };

        public void UseBeer(List<string> Shells,ICharacter character,out string Current)
        {
            character.RemoveItem("Beer");
            Current = Shells[0];
            Shells.RemoveAt(0);
        }

        public override string ToString()
        {
            return $"Types: {string.Join(',',Usables)}";
        }
    }
}
