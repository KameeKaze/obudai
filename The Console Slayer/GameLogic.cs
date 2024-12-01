using System;


namespace The_Console_Slayer
{
    internal class GameLogic(Game game)
    {
        Random random = new();

        public Game Game { get; private set; } = game;
        private void DemonAttackLogic(Demon demon)
        {
            double distance = Position.Distance(Game.Player.Position, demon.Position);
            int damage = (2 * random.Next(3, 15) / (int)(1 + distance));
            switch (demon.Type)
            {
                case DemonType.Zombiemen:
                    damage = (2 * random.Next(3, 15) / (int)(1 + distance));
                    break;
                case DemonType.Imp:
                    damage = (2 * random.Next(3, 24) / (int)(1 + distance));
                    break;
                case DemonType.Mancubus:
                    damage = (2 * random.Next(8, 64) / (int)(1 + distance));
                    break;

            }

            Game.Player.TakeDamage(damage);
        }

        private Position DemonMoveLogic(Demon demon)
        {
            demon.Position.X += random.Next(-1, 2);
            demon.Position.Y += random.Next(-1, 2);
            return demon.Position;
        }
        public Position Move(Demon demon, Position position)
        {
            if (GetTotalFillingRatio(position) + demon.FillingRatio <= 1)
            {
                demon.Position = position;
            }

            return demon.Position;
        }

        public Position Move(Player player, Position position)
        {
            if (GetTotalFillingRatio(position) + player.FillingRatio <= 1)
            {
                player.Position = position;

            }

            return player.Position;
        }


        private void UpdateDemons()
        {
            for (int i = 0; i < Game.Demon.Count; i++)
            {
                Game.Demon[i].UpdateState(Game.Player);

                if (Game.Demon[i].State == DemonStateType.Move)
                {
                    Game.Demon[i].Position = Move(Game.Demon[i], DemonMoveLogic(Game.Demon[i]));
                    DemonAttackLogic(Game.Demon[i]);
                }
            }
        }

        private double GetTotalFillingRatio(Position position)
        {
            List<GameItem> items = GetGameItemsWithinDistance(position, 0);
            List<Demon> demons = GetDemonsWithinDistance(position, 0);

            double fr = 0;
            for (int i = 0; i < items.Count; i++)
            {
                fr += items[i].FillingRatio;
            }

            for (int i = 0; i < demons.Count; i++)
            {
                fr += demons[i].FillingRatio;
            }
            return fr;

        }


        private List<Demon> GetDemonsWithinDistance(Position position, double distance)
        {
            List<Demon> items = [];
            for (int i = 0; i < Game.Demon.Count; i++)
            {
                if (distance >= Position.Distance(position, Game.Demon[i].Position))
                {
                    items.Add(Game.Demon[i]);
                }
            }
            return items;
        }

        private List<GameItem> GetGameItemsWithinDistance(Position position, double distance)
        {
            List<GameItem> items = [];
            for (int i = 0; i < Game.Items.Count; i++)
            {
                if (distance >= Position.Distance(position, Game.Items[i].Position))
                {
                    items.Add(Game.Items[i]);
                }
            }
            return items;
        }


        private void CleanUpGameItems()
        {
            for (int i = 0; i < Game.Items.Count; i++)
            {
                if (Game.Items[i].Available == false)
                {
                    Game.Items.Remove(Game.Items[i]);
                }
            }
        }

        private void CleanUpDemons()
        {
            for (int i = 0; i < Game.Demon.Count; i++)
            {
                if (Game.Demon[i].Alive == false)
                {
                    Game.Demon.Remove(Game.Demon[i]);
                }
            }
        }

        public void PlayerAttackLogic()
        {
            if (Game.Player.Ammo > 0)
            {
                Game.Player.Shoot();
                List<Demon> demons = GetDemonsWithinDistance(Game.Player.Position, Game.Player.SightRange);
                for (int i = 0; i < demons.Count; i++)
                {
                    int damage = (2 * random.Next(100, 300) / (int)(1 + Position.Distance(Game.Player.Position, demons[i].Position)));
                    demons[i].TakeDamage(damage);
                    if (!demons[i].Alive)
                    {

                        switch (demons[i].Type)
                        {
                            case DemonType.Zombiemen:
                                Game.Player.AddCombatPoints(1);
                                break;
                            case DemonType.Imp:
                                Game.Player.AddCombatPoints(3);
                                break;
                            case DemonType.Mancubus:
                                Game.Player.AddCombatPoints(10);
                                break;

                        }
                    }
                }
            }
        }

        public void UpdateGameState()
        {
            UpdateDemons();
            CleanUpDemons();
            CleanUpGameItems();
        }


    }
}
