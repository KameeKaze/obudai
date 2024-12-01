using System;
public enum DemonType { Zombiemen, Imp, Mancubus }
public enum DemonStateType { Idle, Move, Attack }


namespace The_Console_Slayer
{
    internal class Demon
    {

        public Position Position { get; set; }
        public ConsoleSprite Sprite { get; private set; }
        public DemonType Type { get; private set; }
        public DemonStateType State { get; set; } = DemonStateType.Idle;


        public double FillingRatio { get; private set; }
        public int Health { get; private set; }
        public bool Alive { get; private set; } = true;
        public int SightRange  { get; private set; }
        public int AttackRange { get; private set; }

        public Demon(int x, int y, DemonType type)
        {
            Position = new(x,y);
            Type = type;

            SetInitialProperties();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Alive = false;
            }
        }

        public void UpdateState(Player player)
        {
            double distance = Position.Distance(player.Position, Position);

            if (distance < AttackRange)
            {
                State = DemonStateType.Attack;
            }else if (distance < SightRange)
            {
                State = DemonStateType.Move;
            }
            else
            {
                State = DemonStateType.Idle;
            }
        }

        private void SetInitialProperties()
        {
            switch (Type)
            {
                case DemonType.Zombiemen:
                    FillingRatio = 0.5;
                    Health = 20;
                    //Damage
                    //Speed
                    SightRange = 3;
                    AttackRange = 1;
                    Sprite = new(ConsoleColor.Black,ConsoleColor.White,'o');
                    break;

                case DemonType.Imp:
                    FillingRatio = 0.5;
                    Health = 60;
                    //Damage
                    //Speed
                    SightRange = 6;
                    AttackRange = 3;
                    Sprite = new(ConsoleColor.Black, ConsoleColor.Red, 'o');
                    break;
                case DemonType.Mancubus:
                    FillingRatio = 1;
                    Health = 600;
                    //Damage
                    //Speed
                    SightRange = 9;
                    AttackRange = 6;
                    Sprite = new(ConsoleColor.Black, ConsoleColor.Magenta, 'O');
                    break;
            }
        }

    }
}
