using UnityEngine;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Inventory inventory;
        private int MedsCount;
        private int SwordsCount;
        public int KeyCount;
        public Player()
        {
            inventory = new Inventory();
            Health = 100;
            Damage = 30;
            MedsCount = 0;
            SwordsCount = 0;
            KeyCount = 0;
        }
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.SetText($"Health: {this.Health}\nDamage: {this.Damage}\nMeds: {MedsCount}\nSwords: {SwordsCount}\nKeys: {KeyCount}", UserInterface.TextPosition.TopLeft);
            if (Input.GetKeyDown(KeyCode.W))
            {
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                UseMeds();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                var item = ActorManager.Singleton.GetActorAt<Item>(this.Position);
                if (CheckPosition(item))
                {
                    PickUp(item);
                }
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                UseSwords();
            }
        }
        public override bool OnCollision(Character anotherActor) => false;
        protected override void OnDeath()
        {
            UserInterface.Singleton.SetText("Goodbye cruel world...", UserInterface.TextPosition.MiddleCenter);
        }
        private void UseMeds()
        {
            foreach(var item in inventory.itemList)
            {
                if(item is HealthPack)
                {
                    Health += 20;
                    Destroy(item);
                    inventory.itemList.Remove(item);
                    MedsCount -= 1;
                    UserInterface.Singleton.SetText("+20 HP", UserInterface.TextPosition.MiddleLeft);
                    break;
                }
                else
                {
                    UserInterface.Singleton.SetText("No Meds available!", UserInterface.TextPosition.MiddleLeft);
                }
            }
        }
        private void PickUp(Item item)
        {
            if(item is HealthPack)
            {
                MedsCount += 1; 
            }
            else if(item is Sword)
            {
                SwordsCount += 1;
            }
            else if(item is Key)
            {
                KeyCount += 1;
            }
            inventory.AddItem(item);
            item.Position = (99, 99);
            UserInterface.Singleton.SetText("", UserInterface.TextPosition.BottomRight);
        }
        private void UseSwords()
        {
            foreach (var item in inventory.itemList)
            {
                if (item is Sword)
                {
                    Damage += 10;
                    Destroy(item);
                    inventory.itemList.Remove(item);
                    SwordsCount -= 1;
                    UserInterface.Singleton.SetText("+10 Damage", UserInterface.TextPosition.MiddleLeft);
                    break;
                }
                else
                {
                    UserInterface.Singleton.SetText("No more Sword!", UserInterface.TextPosition.MiddleLeft);
                }
            }
        }
        private bool CheckPosition(Item item)
        {
            if(item == null)
            {
                return false;
            }
            return true;
        }
        public override int DefaultSpriteId => 27;
        public override string DefaultName => "Player";
    }
}
