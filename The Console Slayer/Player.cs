using System;

namespace The_Console_Slayer
{
    internal class Player(int x, int y)
    {

        public Position Position { get; set; } = new Position(x, y);
        public ConsoleSprite Sprite { get; set; } = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, '0');
        private int health = 100;
        public int Health
        {
            get => health;
            set
            {
                if (value <= MaxHealth)
                {
                    health = value;
                }
                else
                {
                    health = MaxHealth;
                }
            }
        }

        private int ammo = 10;
        public int Ammo
        {
            get => ammo;
            set
            {
                if (value <= MaxAmmo)
                {
                    ammo = value;
                }
                else
                {
                    ammo = MaxAmmo;
                }
            }
        }

        private int MaxHealth
        {
            get { return 100 + CombatPoints / 10; }
        }

        private int MaxAmmo
        {
            get { return 10 + CombatPoints / 50; }
        }
        public bool Alive { get; private set; } = true;

        public int CombatPoints { get; private set; }

        public int SightRange { get; } = 8;

        public double FillingRatio { get; } = 0.5;

        public void Shoot()
        {
            ammo -= 1;
        }

        public void AddCombatPoints(int xp)
        {
            CombatPoints += xp;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Alive = false;  
            }
        }
    }
}
