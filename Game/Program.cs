using GameLib;


List<string> test = new List<string>()
{
    "Gold_dt;21;1;1;Kö:2","Enigma;1;2;2;Fö:102,Fa:32"
};

Engine engine = new(test);
engine.ProfileName = "Gold_dt";


Console.WriteLine(engine);