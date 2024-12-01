using System;

namespace The_Console_Slayer
{
    internal class Position(int x, int y)
    {

        public int X { get; set; } = x;
        public int Y { get; set; } = y;

        public static Position Add(Position p1, Position p2)
        {

            return new Position(p1.X+p2.X, p1.Y+p2.Y);
        }

        public static double Distance(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }
}
