using System;

namespace GameEngine
{
    public class GameWork
    {

        public int StarterHealth { get; set; }
        public int ActiveTolteny { get; set; }
        public int UresTolteny { get; set; }

        Player player;
        Dealer dealer;
        public GameWork(string Name)
        {
            Random r = new Random();

            StarterHealth = r.Next(0, 100);

            player = new(Name, StarterHealth);
            dealer = new(StarterHealth);
        }


        public void NextRound()
        {
            Random rackNMB = new Random();

            
        }


        public override string ToString()
        {
            return $"Player\n\tName: {player.Name}\n\tHealth: {player.Health}\n\tItems: {string.Join(',',player.Items)}\nDealer\n\tHealth: {dealer.Health}\n\tItems: {string.Join(',',dealer.items)}";
        }

    }
}
