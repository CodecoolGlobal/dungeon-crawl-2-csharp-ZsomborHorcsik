using DungeonCrawl.Actors.Characters;

namespace DungeonCrawl.Actors.Items
{
    public abstract class Item : Actor
    {
        public int Damage { get; private set; }

        public virtual void PickUp(Character player, Item item) { }
    }
}
