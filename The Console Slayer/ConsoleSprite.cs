using System;

namespace The_Console_Slayer
{
    internal class ConsoleSprite(ConsoleColor bg, ConsoleColor fg, char glyph)
    {
        public ConsoleColor Background { get; } = bg;
        public ConsoleColor Foreground { get; } = fg;
        public char Glyph { get; } = glyph;
    }
}
