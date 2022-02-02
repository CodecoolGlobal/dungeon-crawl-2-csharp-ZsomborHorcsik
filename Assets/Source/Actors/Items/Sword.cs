using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Character anotherActor) => true;

        public override int DefaultSpriteId => 128;
        public override string DefaultName => "Sword";
    }
}