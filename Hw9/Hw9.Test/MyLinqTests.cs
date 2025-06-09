// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw9.Test;

using Hw9;

/// <summary>
/// Tests MyLinq class.
/// </summary>
[TestClass]
public class MyLinqTests
{
    private int[] primes = Array.Empty<int>();

    /// <summary>
    /// Initializes the expected primes array for use in tests.
    /// </summary>
    [TestInitialize]
    public void Setup()
    {
        this.primes = new int[12] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
    }

    /// <summary>
    /// Checks that skipping 2 elements matches expected tail of primes.
    /// </summary>
    [TestMethod]
    public void Skip2_ShouldMatchPrimesFromIndex2()
    {
        var expected = this.primes[2..];
        var actual = MyLinq.GetPrimes().Take(12).Skip(2);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    /// <summary>
    /// Checks that skipping 0 elements returns the full list.
    /// </summary>
    [TestMethod]
    public void Skip0_ShouldMatchAllPrimes()
    {
        var expected = this.primes;
        var actual = MyLinq.GetPrimes().Take(12).Skip(0);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    /// <summary>
    /// Checks that skipping 0 then taking 12 matches the full list.
    /// </summary>
    [TestMethod]
    public void Take12Skip0_ShouldMatchAllPrimes()
    {
        var expected = this.primes;
        var actual = MyLinq.GetPrimes().Skip(0).Take(12);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    /// <summary>
    /// Checks that skipping 2 and taking 10 returns elements from index 2.
    /// </summary>
    [TestMethod]
    public void Skip2Take10_ShouldMatchPrimesFromIndex2()
    {
        var expected = this.primes[2..12];
        var actual = MyLinq.GetPrimes().Skip(2).Take(10);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    /// <summary>
    /// Checks that two consecutive skips and a take behave like single skip.
    /// </summary>
    [TestMethod]
    public void Skip1Skip1Take10_ShouldMatchPrimesFromIndex2()
    {
        var expected = this.primes[2..12];
        var actual = MyLinq.GetPrimes().Skip(1).Skip(1).Take(10);
        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    /// <summary>
    /// Checks that taking 0 elements then skipping 0 results in empty sequence.
    /// </summary>
    [TestMethod]
    public void Take0Skip0_ShouldBeEmpty()
    {
        Assert.IsFalse(MyLinq.GetPrimes().Take(0).Skip(0).Any());
    }

    /// <summary>
    /// Checks that taking 0 then skipping a large number yields no results.
    /// </summary>
    [TestMethod]
    public void Take0Skip1968_ShouldBeEmpty()
    {
        Assert.IsFalse(MyLinq.GetPrimes().Take(0).Skip(1968).Any());
    }
}
