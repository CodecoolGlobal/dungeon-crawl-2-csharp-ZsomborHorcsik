using UnityEngine;
using DungeonCrawl.Core;
using System;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        private States _activeState = States.Patrol;
        private int _timer = 0;
        private float MovingTimer { get; set; } = 200;
        private enum States
        {
            Patrol,
            Attack,
        }

        private double _distanceToPlayer;

        private static readonly Array Values = Enum.GetValues(typeof(Direction));
        private static readonly System.Random Random = new System.Random();
        Direction _direction = (Direction)Values.GetValue(Random.Next(Values.Length));

        protected override void OnUpdate(float deltaTime)
        {
            _timer++;
            Actor player = ActorManager.Singleton.GetPlayerInstance();
            if (player != null)
            {
                _distanceToPlayer = Math.Sqrt((Position.x - player.Position.x) ^ 2 + (Position.y - player.Position.y) ^ 2);
            }

            _activeState = _distanceToPlayer <= 3 ? States.Attack : States.Patrol;

            if (_timer >= MovingTimer)
            {
                _timer = 0;
                (int x, int y) targetPosition = (Position.x, Position.y);

                switch (_activeState)
                {
                    case States.Patrol:
                        var vector = _direction.ToVector();
                        targetPosition = (Position.x + vector.x, Position.y + vector.y);
                        break;

                    case States.Attack:
                        if (player != null)
                        {
                            int horOffset = Math.Sign(player.Position.x - Position.x);
                            int verOffset = Math.Sign(player.Position.y - Position.y);
                            targetPosition = (Position.x + horOffset, Position.y + verOffset);
                        }
                        break;
                }
                
                var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

                if (actorAtTargetPosition == null || actorAtTargetPosition.OnCollision(this))
                {
                    Position = targetPosition;
                }
                else
                {
                    switch (_direction)
                    {
                        case Direction.Right:
                            _direction = Direction.Left;
                            break;

                        case Direction.Up:
                            _direction = Direction.Down;
                            break;

                        case Direction.Left:
                            _direction = Direction.Right;
                            break;

                        case Direction.Down:
                            _direction = Direction.Up;
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
