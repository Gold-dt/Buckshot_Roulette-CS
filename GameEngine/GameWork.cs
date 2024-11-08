using System;

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

        internal int Shells { get; set; }//All round (live+blank rounds)
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
            StarterHealth = random.Next(minHealth, maxHealth);
            player = new(Name, StarterHealth);
            dealer = new(StarterHealth);
        }


        public void NextRound()
        {
            

            int currentshels = random.Next(2, MaxReck);
            ActiveTolteny = random.Next(1, currentshels);
            UresTolteny = currentshels-ActiveTolteny;
            StarterHealth = random.Next(2, 5);
            Shells = currentshels;
        }

        

        public override string ToString()
        {
            return $"Game Stats\n\tShells: {Shells}\n\tActiv round: {ActiveTolteny}\n\tBlank Round: {UresTolteny}\n\tStarter Health: {StarterHealth}\n\tMinHealth: {MinHealth}\n\tMaxHealth: {MaxHealth}\n\tRound: {Round}\n\tGame Type: {GameType}\nPlayer\n\tName: {player.Name}\n\tHealth: {player.Health}\n\tItems: {string.Join(',',player.Items)}\nDealer\n\tHealth: {dealer.Health}\n\tItems: {string.Join(',',dealer.items)}";
        }

    }
}
