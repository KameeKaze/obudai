using System;


namespace The_Console_Slayer
{
    internal class ConsoleRenderer(Game game)
    {

        Game Game { get; set; } = game;

        public void RenderGame()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            Console.Clear();
            for (int i = 0; i < Game.Items.Count; i++)
            {
                RenderSingleSprite(Game.Items[i].Position, Game.Items[i].Sprite);
            }
            for (int i = 0; i < Game.Demon.Count; i++)
            {
                RenderSingleSprite(Game.Demon[i].Position, Game.Demon[i].Sprite);
            }
            RenderSingleSprite(Game.Player.Position, Game.Player.Sprite);
        }
        private static void RenderSingleSprite(Position position, ConsoleSprite sprite)
        {
            if (Console.WindowWidth > position.X && Console.WindowHeight > position.Y && 0 < position.X + 1 && 0 < position.Y + 1)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.BackgroundColor = sprite.Background;
                Console.ForegroundColor = sprite.Foreground;
                Console.WriteLine(sprite.Glyph);
            }

        }


    }
}
