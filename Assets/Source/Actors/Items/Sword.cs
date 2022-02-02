using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Character anotherActor)
        {
            if (anotherActor is Player)
            {
                PickUp(anotherActor, this);
            }
            return true;
        }
        public override void PickUp(Character player, Item sword)
        {
            player.Inventory.Add(sword);
            sword.Position = (99, 99);
        }
        public override int DefaultSpriteId => 128;
        public override string DefaultName => "Sword";
    }
}