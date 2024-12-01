namespace The_Console_Slayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new();
            game.Items.Add(new GameItem(2,3,ItemType.Door));
            game.Items.Add(new GameItem(3, 4, ItemType.Medikit));
            game.Items.Add(new GameItem(5, 5, ItemType.ToxicWaste));
            game.Demon.Add(new Demon(2,8,DemonType.Zombiemen));
            game.Demon.Add(new Demon(3, 8, DemonType.Imp));
            game.Demon.Add(new Demon(5, 8, DemonType.Mancubus));




            game.Run();


        }
    }
}
