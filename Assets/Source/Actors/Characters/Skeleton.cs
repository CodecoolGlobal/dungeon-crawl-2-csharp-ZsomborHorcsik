using UnityEngine;
using System.Collections.Generic;
using DungeonCrawl.Actors.Items;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public Skeleton()
        {
            Health = 40;
            Damage = 20;
        }
        public override bool OnCollision(Character anotherActor)
        {
            this.ApplyDamage(anotherActor.Damage);
            if (this.Health > 0)
            {
                anotherActor.ApplyDamage(this.Damage);
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
