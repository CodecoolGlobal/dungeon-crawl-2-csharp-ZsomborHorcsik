using UnityEngine;
using DungeonCrawl.Actors.Items;
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
                //UseMeds();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                //pickup item
            }
        }

        public override bool OnCollision(Character anotherActor) => false;

        protected override void OnDeath()
        {
            Debug.Log("DAAAAAAAAAAAAAAYUM, I'm dead!");
        }
        private void UseMeds(List<Item> playerInventory)
        {
            foreach(var item in playerInventory)
            {
                if(item is HealthPack)
                {
                    Health += 20;
                    Destroy(item);
                    break;
                }
            }
        }
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
