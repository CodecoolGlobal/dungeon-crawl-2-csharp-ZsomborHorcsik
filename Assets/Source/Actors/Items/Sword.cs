using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Character anotherActor) => true;
        public override bool Detectable => true;
        public override int DefaultSpriteId => 416;
        public override string DefaultName => "Sword";
    }
}