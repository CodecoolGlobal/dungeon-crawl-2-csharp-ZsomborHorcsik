using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        public override int DefaultSpriteId => 128;
        public override string DefaultName => "Sword";
    }
}