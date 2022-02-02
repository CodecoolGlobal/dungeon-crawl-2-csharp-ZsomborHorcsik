using DungeonCrawl.Core;
using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public class HealthPack : Item
    {
        public override bool OnCollision(Character anotherActor) => true;

        public override int DefaultSpriteId => 570;
        public override string DefaultName => "HP";
    }
}