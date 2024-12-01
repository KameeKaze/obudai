using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace The_Console_Slayer
{
    internal class Game
    {
        Random random = new();

        public Player Player { get; } = new(0, 0);
        public bool Exited { get; set; }
        public List<GameItem> Items { get; private set; } = [];
        public List<Demon> Demon { get; set; } = [];
        private ConsoleRenderer ConsoleRenderer;
        private GameLogic GameLogic;

        Stopwatch S1 = new();
        Stopwatch S2 = new();




        public Game()
        {
            ConsoleRenderer = new ConsoleRenderer(this);
            GameLogic = new GameLogic(this);
        }


        private void UserAction()
        {
            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    case ConsoleKey.Escape:
                        Exited = true;
                        break;

                    case ConsoleKey.UpArrow:
                        if (0 < Player.Position.Y) 
                        {
                            Player.Position = GameLogic.Move(Player, Position.Add(Player.Position, new Position(0, -1)));
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.WindowHeight-2 > Player.Position.Y)
                        {
                            Player.Position = GameLogic.Move(Player, Position.Add(Player.Position, new Position(0, 1)));
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (0 < Player.Position.X)
                        {
                            Player.Position = GameLogic.Move(Player, Position.Add(Player.Position, new Position(-1, 0)));
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Console.WindowWidth-1 > Player.Position.X)
                        {
                            Player.Position = GameLogic.Move(Player, Position.Add(Player.Position, new Position(1, 0)));
                        }
                        break;
                    case ConsoleKey.D:
                        for (int i = 0; i < Items.Count; i++)
                        {
                            Items[i].Interact();
                        }
                        break;
                    case ConsoleKey.A:
                        GameLogic.PlayerAttackLogic();
                        break;
                }

            }

        }

        public void Run()


        {
            S1.Start();
            S2.Start();

            while (Exited == false)
            {

                if (S1.ElapsedMilliseconds > 500)
                {
                    GameLogic.UpdateGameState();
                    S1.Restart();
                }
                if (S2.ElapsedMilliseconds > 25)
                {
                    ConsoleRenderer.RenderGame();
                    S2.Restart();
                }
                
                UserAction();
                Thread.Sleep(25);
                if (!Player.Alive)
                {
                    Exited = true;
                }
            }
        }
    }
}
