using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Items
    {
        MainEngine game;
        public List<string> Usables = new List<string>() 
        {
         "Beer","Cuffs","SpyGlass","Changer","Knife"
        };

        public void Beer(List<string> Shells,out string Current)
        {
            
            Current = Shells[0];
            Shells.RemoveAt(0);
            
            
            
        }
        public void SpyGlass(List<string> Shells,out string Current)
        {
            Current = Shells[0];
        }
        public void Changer(List<string> Shells, out string Current)
        {

            Current = Shells[0];
            switch (Current)
            {
                case "Live":
                    Shells[0] = "Blank";
                    break;
                case "Blank":
                    Shells[0] = "Live";
                    break;
            }
            Current = Shells[0];
                
        }
        public void Cuffs(ICharacter character)
        {
            character.SelfRounds = 2;
        }
        public void Knife(out int currentdmg)
        {
            currentdmg = 2;
        }

        public override string ToString()
        {
            return $"Types: {string.Join(',',Usables)}";
        }
    }
}
