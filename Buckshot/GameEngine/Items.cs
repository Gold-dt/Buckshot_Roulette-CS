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

        public void UseBeer()
        {

        }

        public override string ToString()
        {
            return $"Types: {string.Join(',',Usables)}";
        }
    }
}
