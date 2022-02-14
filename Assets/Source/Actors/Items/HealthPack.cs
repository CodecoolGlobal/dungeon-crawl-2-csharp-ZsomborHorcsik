using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class HealthPack : Item
    {
        public override bool OnCollision(Character anotherActor) => true;
        public override bool Detectable => true;
        public override int DefaultSpriteId => 656;
        public override string DefaultName => "HP";
    }
}