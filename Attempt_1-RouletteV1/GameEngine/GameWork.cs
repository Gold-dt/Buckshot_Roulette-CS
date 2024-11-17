using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace GameEngine
{
    public class GameWork
    {

        public int StarterHealth { get; private set; }//Kör kezdő életerő
        public int ActiveTolteny { get; private set; }//Live Round
        public int UresTolteny { get; private set; }//Blank Round
        public int GameType { get; private set; }// 0 : Default | 1 : Duppla vagy semmi

        public int Max_Round {  get; init; }//Max körök száma
        public int Round { get; set; }//Éppen futó kör
        public int MaxReck {  get; init; } //Össz töltény amit ki lehet 

        public int MaxHealth { get; init; }//Max élet amit lehet generálni
        public int MinHealth { get; init; }//Minimum élet amit kell generálni

        public int Shells { get; set; }//All round (live+blank rounds)
        internal Random random = new Random();//Internal Global random

        Player player;
        Dealer dealer;
        public GameWork(string Name,int maxReck,int maxRound,int maxHealth,int minHealth,int gameType)
        {
            MaxReck = maxReck;
            Max_Round = maxRound;
            MaxHealth = maxHealth;
            MinHealth = minHealth;
            GameType = gameType;
            StarterHealth = random.Next(minHealth, maxHealth+1);
            player = new(Name, StarterHealth);
            dealer = new(StarterHealth);
        }
        public int LowestHealth => player.Health > dealer.Health ? player.Health : dealer.Health;


        public void NextMatch()
        {
            

            int currentshels = random.Next(2, MaxReck);
            ActiveTolteny = random.Next(1, currentshels);
            UresTolteny = currentshels-ActiveTolteny;
            StarterHealth = random.Next(MinHealth, MaxHealth+1);
            player = new(StarterHealth);
            dealer = new(StarterHealth);
            Shells = currentshels;
        }

        public void NextRound()
        {
            int currentshels = random.Next(2, MaxReck);
            Shells = currentshels;
            ActiveTolteny = random.Next(1, currentshels);
            UresTolteny = currentshels - ActiveTolteny;
            
        }




        public void Shoot(string whoOn,out int type)
        {
            type = 0;
            ICharacterStats character = whoOn == "player" ? player : dealer;
            int crsShell = random.Next(1, 3);
            if (crsShell == 1)//live
            {
                
                if(ActiveTolteny-1 != 0)
                {
                    ActiveTolteny--;
                    character.Health--;
                    type = 1;
                    Shells--;
                }
            }
            else
            {
                UresTolteny--;
                Shells--;
            }

        }



        public void MeShoot(string whoOn, out int type)
        {
            ICharacterStats character = whoOn == "player" ? dealer : player;
            int crsShell = random.Next(1, 3);
            
            type = 0;

            if (crsShell == 1)//live
            {

                if (ActiveTolteny - 1 != 0)
                {
                    ActiveTolteny--;
                    character.Health--;
                    type = 1;
                    Shells--;
                }
            }
            else
            {
                UresTolteny--;
                Shells--;
            }

        }



        public void Got_LiveRound(string who, out int Health)
        {
            ICharacterStats character = who.Trim().ToLower() == "player"? player:dealer;
            character.Health -= 1;
            Health = character.Health;
            if(Health != 0 && ActiveTolteny >0)
            {
                ActiveTolteny--;
                Shells--;
            }
            
            
        }
        public void Got_BlankRound(string who)
        {
            ICharacterStats character = who.Trim().ToLower() == "player" ? player : dealer;


            if (character.Health != 0 && UresTolteny > 0)
            {
                UresTolteny--;
                Shells--;
            }
            
            
        }

        public override string ToString()
        {
            return $"Game Stats\n\tShells: {Shells}\n\tActiv round: {ActiveTolteny}\n\tBlank Round: {UresTolteny}\n\tStarter Health: {StarterHealth}\n\tMinHealth: {MinHealth}\n\tMaxHealth: {MaxHealth}\n\tRound: {Round}\n\tGame Type: {GameType}\nPlayer\n\tName: {player.Name}\n\tHealth: {player.Health}\n\tItems: {string.Join(',',player.Items)}\nDealer\n\tHealth: {dealer.Health}\n\tItems: {string.Join(',',dealer.Items)}";
        }

    }
}
