using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Items
{
    public class HealthPack : Item
    {
        public override bool OnCollision(Character anotherActor) 
        {
            PickUp((Player)anotherActor, this);
            return true;
        }
        public override void PickUp(Player player, Item healthPack)
        {
            player.inventory.AddItem(gameObject.AddComponent<HealthPack>());
            ActorManager.Singleton.DestroyActor(healthPack);
        }
        public override int DefaultSpriteId => 570;
        public override string DefaultName => "HP";
    }
}