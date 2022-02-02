using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Character anotherActor)
        {
            return true;
        }
        public override bool Detectable => true;
        public override int DefaultSpriteId => 128;
        public override string DefaultName => "Sword";
    }
}