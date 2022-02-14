using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public class Key : Item
    {
        public override bool OnCollision(Character anotherActor) => true;
        public override int DefaultSpriteId => 560;
        public override string DefaultName => "Key";
    }
}
