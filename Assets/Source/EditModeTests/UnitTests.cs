using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void Player_PlayerTakesDamage()
    {
        Player player = new Player();
        player.ApplyDamage(20);
        Assert.AreEqual(80, player.Health);
    }

    public void Player_PlayerCanDealDamage()
    {
        Player player = new Player();
        Skeleton skeleton = new Skeleton();
        skeleton.ApplyDamage(player.Damage);
        Assert.IsTrue(skeleton.Health == 10);
    }

    public void Skeleton_SkeletonTakesDamage()
    {
        Skeleton skeleton = new Skeleton();
        skeleton.ApplyDamage(20);
        Assert.AreEqual(80, skeleton.Health);
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
