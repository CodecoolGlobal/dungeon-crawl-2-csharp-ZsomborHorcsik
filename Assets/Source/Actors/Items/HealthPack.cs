using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public class HealthPack : Item
    {
        public override bool OnCollision(Character anotherActor) 
        {
            if(anotherActor is Player)
            {
                PickUp(anotherActor, this);
            }
            return true;
        }
        public override void PickUp(Character player, Item healthPack)
        {
            player.Inventory.Add(healthPack);
            healthPack.Position = (99, 99);
        }
        public override int DefaultSpriteId => 570;
        public override string DefaultName => "HP";
    }
}