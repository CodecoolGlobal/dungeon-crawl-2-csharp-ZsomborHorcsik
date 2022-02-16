using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Items
{
    public class Door : Actor
    {
        public override bool OnCollision(Character anotherActor) 
        {
            if(anotherActor is Player)
            {
                var player = (Player)anotherActor;
                foreach (var item in player.inventory.itemList)
                {
                    if(item is Key)
                    {
                        ActorManager.Singleton.DestroyActor(this);
                        ActorManager.Singleton.DestroyActor(item);
                        player.inventory.RemoveItem(item);
                        player.KeyCount -= 1;
                        UserInterface.Singleton.SetText("Key used! Keep fighting!", UserInterface.TextPosition.BottomRight);
                        return true;
                    }
                }
                UserInterface.Singleton.SetText("You dont have the key!", UserInterface.TextPosition.BottomRight);
            }
            return false;
        }
        public override int DefaultSpriteId => 821;
        public override string DefaultName => "Door";
    }
}
