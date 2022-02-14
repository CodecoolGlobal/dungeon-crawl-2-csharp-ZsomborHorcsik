using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Algea : Actor
    {
        public override bool OnCollision(Character anotherActor) => false;
        public override int DefaultSpriteId => 5;
        public override string DefaultName => "Algea";
    }
}