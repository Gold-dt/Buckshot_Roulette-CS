namespace GameLib
{
    public class Player
    {
        public string CharacterName { get; set; }
        public int XPLevel { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int>();

        //Gold_dt;21;1;1;Kö:2
        public Player(string sor)
        {
            string[] data = sor.Split(';');
            CharacterName = data[0];
            XPLevel = int.Parse(data[1]);
            PlayerX = int.Parse(data[2]);
            PlayerY = int.Parse(data[3]);

            string[] items = data[4].Split(',');
            foreach (var item in items)
            {
                string[] itemData = item.Split(':');
                Inventory.Add(itemData[0], int.Parse(itemData[1]));
            }
        }
    }
}
