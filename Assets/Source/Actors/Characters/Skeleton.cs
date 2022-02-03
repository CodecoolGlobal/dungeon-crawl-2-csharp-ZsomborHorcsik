using UnityEngine;
using DungeonCrawl.Core;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        private States ActiveState = States.patrol;
        private int timer = 0;
        private int movingTimer { get; set; } = 200;
        private enum States
        {
            patrol,
            attack,
        }

        private double distanceToPlayer;

        static Array values = Enum.GetValues(typeof(Direction));
        static System.Random random = new System.Random();
        Direction direction = (Direction)values.GetValue(random.Next(values.Length));

        protected override void OnUpdate(float deltaTime)
        {
            timer++;
            Actor player = ActorManager.Singleton.GetPlayerInstance();
            distanceToPlayer = Math.Sqrt((Position.x - player.Position.x) ^ 2 + (Position.y - player.Position.y) ^ 2);

            if (distanceToPlayer <= 20)
            {
                ActiveState = States.attack;
            }
            else
            {
                ActiveState = States.patrol;
            }

            if (timer == movingTimer)
            {
                timer = 0;
                (int x, int y) targetPosition = (Position.x, Position.y);

                switch (ActiveState)
                {
                    case States.patrol:
                        var vector = direction.ToVector();
                        targetPosition = (Position.x + vector.x, Position.y + vector.y);
                        break;

                    case States.attack:
                        int horOffset = Math.Sign(player.Position.x - Position.x);
                        int verOffset = Math.Sign(player.Position.y - Position.y);
                        targetPosition = (Position.x + horOffset, Position.y + verOffset);
                        break;
                }
                
                var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

                if (actorAtTargetPosition == null || actorAtTargetPosition.OnCollision(this))
                {
                    Position = targetPosition;
                }
                else
                {
                    switch (direction)
                    {
                        case Direction.Right:
                            direction = Direction.Left;
                            break;

                        case Direction.Up:
                            direction = Direction.Down;
                            break;

                        case Direction.Left:
                            direction = Direction.Right;
                            break;

                        case Direction.Down:
                            direction = Direction.Up;
                            break;

                    }
                }
            }
        }

        public Skeleton()
        {
            Health = 40;
            Damage = 20;
        }

        public override bool OnCollision(Character anotherActor)
        {
            if (anotherActor is Player)
            {
                ApplyDamage(anotherActor.Damage);
                if (Health > 0)
                {
                    anotherActor.ApplyDamage(Damage);
                }  
            }
            return false;
        }

        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText("Player killed SKELETON", UserInterface.TextPosition.TopRight);
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
