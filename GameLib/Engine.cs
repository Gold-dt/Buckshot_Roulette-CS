using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Engine
    {
        
        public string ProfileName { get; set; }

        public string Author = "Gold_dt";

        public List<Player> players = new List<Player>();  

        public Engine(IEnumerable<string> GameSaveFile)
        {
            foreach (var item in GameSaveFile)
            {
                players.Add(new Player(item));  
            }
        }

        public override string ToString()
        {
            
            StringBuilder result = new StringBuilder();
            foreach (var player in players)
            {
                result.AppendLine($"Profile Name: {ProfileName} | Character Name: {player.CharacterName} | XP: {player.XPLevel} | X:{player.PlayerX} | Y:{player.PlayerY} | Inv: {string.Join(',',player.Inventory)}");
            }
            return result.ToString();
        }
    }
}
