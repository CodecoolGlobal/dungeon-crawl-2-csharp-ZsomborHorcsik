using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Wall : Actor
    {
        public override bool OnCollision(Character anotherActor) => false;
        public override int DefaultSpriteId => 825;
        public override string DefaultName => "Wall";
    }
}
