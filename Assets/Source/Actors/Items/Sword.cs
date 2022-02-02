using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    public class Sword : Item
    {
        public override bool OnCollision(Character anotherActor)
        {
            PickUp((Player)anotherActor, this);
            return true;
        }
        public override void PickUp(Player player, Item sword)
        {
            player.inventory.AddItem(gameObject.AddComponent<Sword>());
            ActorManager.Singleton.DestroyActor(sword);
        }
        public override int DefaultSpriteId => 128;
        public override string DefaultName => "Sword";
    }
}