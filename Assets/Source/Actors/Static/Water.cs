using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Static
{
    public class Water : Actor
    {
        public override bool OnCollision(Character anotherActor) => false;
        public override int DefaultSpriteId => 247;
        public override string DefaultName => "Water";
        public override bool Detectable => false;
    }
}