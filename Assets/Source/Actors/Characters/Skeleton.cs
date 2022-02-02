using UnityEngine;

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
            Debug.Log("Well, I was already dead anyway...");
        }

        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";
    }
}
