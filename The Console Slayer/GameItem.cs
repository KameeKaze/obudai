using System;
using System.Dynamic;
using System.Numerics;

public enum ItemType { Ammo, BFGCell, Door, LevelExit, Medikit, ToxicWaste, Wall }

namespace The_Console_Slayer
{
    internal class GameItem
    {

        public Position Position { get; }
        public ConsoleSprite Sprite { get; private set; }

        public ItemType Type { get; }

        public double FillingRatio { get; private set; }

        public bool Available { get; private set; } = true;



        public GameItem(int x, int y, ItemType type)
        {
            Position = new(x, y);
            Type = type;
            SetInitialProperties();
        }

        private void SetInitialProperties()
        {
            switch (Type)
            {
                case ItemType.Ammo:
                    Sprite = new(ConsoleColor.Red, ConsoleColor.Yellow,'A');
                    FillingRatio = 0;
                    break;
                case ItemType.BFGCell:
                    Sprite = new(ConsoleColor.Green, ConsoleColor.White, 'B');
                    FillingRatio = 0;
                    break;

                case ItemType.Door:
                    Sprite = new(ConsoleColor.DarkGray, ConsoleColor.Yellow, '/');
                    FillingRatio = 1;
                    break;
                case ItemType.LevelExit:
                    Sprite = new(ConsoleColor.Blue, ConsoleColor.Black, 'E');
                    FillingRatio = 1;
                    break;
                case ItemType.Medikit:
                    Sprite = new(ConsoleColor.Gray, ConsoleColor.Red, '+');
                    FillingRatio = 0;
                    break;
                case ItemType.ToxicWaste:
                    Sprite = new(ConsoleColor.DarkGreen, ConsoleColor.Green, ':');
                    FillingRatio = 0;
                    break;
                case ItemType.Wall:
                    Sprite = new(ConsoleColor.Gray, ConsoleColor.Gray, ' ');
                    FillingRatio = 1;
                    break;
            }

        }

        public void Interact()
        {
            switch (Type)
            {
                case ItemType.Ammo:
                case ItemType.BFGCell:
                case ItemType.Medikit:
                    Available = false;
                    break;
                case ItemType.Door:
                    if (FillingRatio == 0) {
                        FillingRatio = 1;
                        Sprite = new(ConsoleColor.DarkGray, ConsoleColor.DarkYellow, '/');
                    }
                    else
                    {
                        FillingRatio = 0;
                        Sprite = new(ConsoleColor.DarkGray, ConsoleColor.Yellow, '/');
                    }
                    break;
            }
        } 

    }
}

