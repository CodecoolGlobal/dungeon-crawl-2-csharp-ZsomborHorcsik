using System.Collections;
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
        int expected = 80;
        int result = player.Health;
        Assert.AreEqual(expected, result);
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
        int expected = 20;
        int result = skeleton.Health;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void Inventory_InventoryCanTakeItems()
    {
        Inventory inventory = new Inventory();
        Sword sword = new GameObject().AddComponent<Sword>();
        inventory.AddItem(sword);
        int expected = 1;
        int result = inventory.itemList.Count;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void Inventory_InventoryCanRemoveItem()
    {
        Inventory inventory = new Inventory();
        Sword sword = new GameObject().AddComponent<Sword>();
        Key key = new Key();
        inventory.AddItem(sword);
        inventory.AddItem(key);
        inventory.RemoveItem(key);
        int expected = 1;
        int result = inventory.itemList.Count;
        Assert.AreEqual(result, expected);
    }
    [Test]
    public void PickUp_PlayerCanPickUpItems()
    {
        Player player = new GameObject().AddComponent<Player>();
        Sword item = new GameObject().AddComponent<Sword>();
        player.PickUp(item);
        int expected = 1;
        int result = player.inventory.itemList.Count;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void PickUp_PlayerPickUpMedsIncreaseAmount()
    {
        Player player = new GameObject().AddComponent<Player>();
        HealthPack med = new GameObject().AddComponent<HealthPack>();
        player.PickUp(med);
        int expected = 1;
        int result = player.MedsCount;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void PickUp_PlayerPickUpSwordIncreaseAmount()
    {
        Player player = new GameObject().AddComponent<Player>();
        Sword item = new GameObject().AddComponent<Sword>();
        player.PickUp(item);
        int expected = 1;
        int result = player.SwordsCount;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void PickUp_PlayerPickUpKeyIncreaseAmount()
    {
        Player player = new GameObject().AddComponent<Player>();
        Key item = new GameObject().AddComponent<Key>();
        player.PickUp(item);
        int expected = 1;
        int result = player.KeyCount;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void UseMeds_PlayerUseMedsIncreasePlayerHitpoint()
    {
        Player player = new GameObject().AddComponent<Player>();
        HealthPack med = new GameObject().AddComponent<HealthPack>();
        player.PickUp(med);
        player.UseMeds();
        int expected = 120;
        int result = player.Health;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void UseMeds_PlayerUseMedsDecreaseMedsAmount()
    {
        Player player = new GameObject().AddComponent<Player>();
        HealthPack med = new GameObject().AddComponent<HealthPack>();
        player.PickUp(med);
        player.UseMeds();
        int expected = 0;
        int result = player.MedsCount;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void UseMeds_PlayerUseMedsRemoveItemFromInventory()
    {
        Player player = new GameObject().AddComponent<Player>();
        HealthPack med = new GameObject().AddComponent<HealthPack>();
        Sword sword = new GameObject().AddComponent<Sword>();
        player.PickUp(med);
        player.PickUp(sword);
        player.UseMeds();
        int expected = 1;
        int result = player.inventory.itemList.Count;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void UseSword_PlayerDamageIncreaseOnSwordUsage()
    {
        Player player = new GameObject().AddComponent<Player>();
        Sword sword = new GameObject().AddComponent<Sword>();
        player.PickUp(sword);
        player.UseSwords();
        int expected = 40;
        int result = player.Damage;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void UseSword_SwordAmountDecreaseOnUsage()
    {
        Player player = new GameObject().AddComponent<Player>();
        Sword sword = new GameObject().AddComponent<Sword>();
        Sword sword2 = new GameObject().AddComponent<Sword>();
        player.PickUp(sword);
        player.PickUp(sword2);
        player.UseSwords();
        int expected = 1;
        int result = player.SwordsCount;
        Assert.AreEqual(expected, result);
    }
    [Test]
    public void UseSword_SwordUsageRemoveItemFromInventory()
    {
        Player player = new GameObject().AddComponent<Player>();
        HealthPack med = new GameObject().AddComponent<HealthPack>();
        Sword sword = new GameObject().AddComponent<Sword>();
        player.PickUp(med);
        player.PickUp(sword);
        player.UseSwords();
        int expected = 1;
        int result = player.inventory.itemList.Count;
        Assert.AreEqual(expected, result);
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
