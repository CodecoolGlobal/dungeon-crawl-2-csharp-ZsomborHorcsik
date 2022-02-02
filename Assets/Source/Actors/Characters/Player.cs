using UnityEngine;
using DungeonCrawl.Actors.Items;
using DungeonCrawl.Core;
using System.Collections.Generic;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public Inventory inventory;
        public Player()
        {
            inventory = new Inventory();
            Health = 100;
            Damage = 30;
        }
        protected override void OnUpdate(float deltaTime)
        {
            UserInterface.Singleton.SetText($"Health: {this.Health}\nDamage: {this.Damage}", UserInterface.TextPosition.TopLeft);
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

            }
        }

        public override bool OnCollision(Character anotherActor) => false;

        protected override void OnDeath()
        {
            Debug.Log("DAAAAAAAAAAAAAAYUM, I'm dead!");
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
                    UserInterface.Singleton.SetText("+20 HP", UserInterface.TextPosition.MiddleLeft);
                    break;
                }
                else
                {
                    UserInterface.Singleton.SetText("No Meds available!", UserInterface.TextPosition.MiddleLeft);
                }
            }
        }
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
