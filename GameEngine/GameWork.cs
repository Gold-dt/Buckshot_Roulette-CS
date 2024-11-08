using System;

namespace GameEngine
{
    public class GameWork
    {

        public int StarterHealth { get; set; }
        public int ActiveTolteny { get; set; }
        public int UresTolteny { get; set; }

        public int MaxReck {  get; init; }

        Player player;
        Dealer dealer;
        public GameWork(string Name,int maxReck)
        {
            Random r = new Random();

            StarterHealth = r.Next(0, 100);
            MaxReck = maxReck;

            player = new(Name, StarterHealth);
            dealer = new(StarterHealth);
        }


        public void NextRound()
        {
            Random random = new Random();

            int currentshels = random.Next(2, MaxReck);
            ActiveTolteny = random.Next(1, currentshels);
            UresTolteny = currentshels-ActiveTolteny;

        }

        public void Match()
        {

        }

        public override string ToString()
        {
            return $"Player\n\tName: {player.Name}\n\tHealth: {player.Health}\n\tItems: {string.Join(',',player.Items)}\nDealer\n\tHealth: {dealer.Health}\n\tItems: {string.Join(',',dealer.items)}";
        }

    }
}
