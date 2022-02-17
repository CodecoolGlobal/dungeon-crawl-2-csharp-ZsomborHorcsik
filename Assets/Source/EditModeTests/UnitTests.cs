using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Items;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Player_PlayerTakesDamage()
    {
        Player player = new GameObject().AddComponent<Player>();
        player.ApplyDamage(20);
        Assert.AreEqual(80, player.Health);
    }
    [Test]
    public void Player_PlayerCanDealDamage()
    {
        Player player = new GameObject().AddComponent<Player>();
        Skeleton skeleton = new GameObject().AddComponent<Skeleton>();
        skeleton.ApplyDamage(player.Damage);
        Assert.IsTrue(skeleton.Health == 10);
    }
    [Test]
    public void Skeleton_SkeletonTakesDamage()
    {
        Skeleton skeleton = new GameObject().AddComponent<Skeleton>();
        skeleton.ApplyDamage(20);
        Assert.AreEqual(20, skeleton.Health);
    }
    [Test]
    public void Inventory_InventoryCanTakeItems()
    {
        Inventory inventory = new Inventory();
        inventory.AddItem(new Sword());
        int expected = 1;
        int result = inventory.itemList.Count;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void Inventory_InventoryCanRemoveItem()
    {
        Inventory inventory = new Inventory();
        Sword sword = new Sword();
        Key key = new Key();
        inventory.AddItem(sword);
        inventory.AddItem(key);
        inventory.RemoveItem(key);
        int expected = 1;
        int result = inventory.itemList.Count;
        Assert.AreEqual(result, expected);
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator UnitTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
