using UnityEngine;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        private States ActiveState = States.patrol;
        private enum States
        {
            patrol,
            attack,
        }

        protected override void OnUpdate(float deltaTime)
        {
            switch (ActiveState)
            {
                case States.patrol:
                    if (deltaTime % 10 == 0)
                    { 
                        
                    }
                    break;

                case States.attack:
                    break;
            }
        }
        
        public Skeleton()
        {
            Health = 40;
            Damage = 20;
        }
        public override bool OnCollision(Character anotherActor)
        {
            ApplyDamage(anotherActor.Damage);
            if (Health > 0)
            {
                anotherActor.ApplyDamage(Damage);
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
