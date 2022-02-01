using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Actor anotherActor) => true;

        public override int DefaultSpriteId => 128;
        public override string DefaultName => "Sword";
    }
}