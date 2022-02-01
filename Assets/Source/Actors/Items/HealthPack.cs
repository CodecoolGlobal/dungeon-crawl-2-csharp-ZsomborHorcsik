using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    public class HealthPack : Item
    {
        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

        public override int DefaultSpriteId => 570;
        public override string DefaultName => "HP";
    }
}