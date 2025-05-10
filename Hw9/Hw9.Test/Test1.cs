// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw9.Test;

using Hw9;

/// <summary>
/// Tests MyLinq class.
/// </summary>
[TestClass]
public sealed class Test1
{
    /// <summary>
    /// Tests both Skip and Take extension methods of MyLinq class.
    /// </summary>
    [TestMethod]
    public void TestSkipAndTake()
    {
        int[] primes = new int[12] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
        int index = 2;
        foreach (var prime in MyLinq.GetPrimes().Take(12).Skip(2))
        {
            Assert.AreEqual(primes[index], prime);
            index++;
        }

        index = 0;

        foreach (var prime in MyLinq.GetPrimes().Take(12).Skip(0))
        {
            Assert.AreEqual(primes[index], prime);
            index++;
        }

        index = 0;

        foreach (var prime in MyLinq.GetPrimes().Skip(0).Take(12))
        {
            Assert.AreEqual(primes[index], prime);
            index++;
        }

        index = 2;
        foreach (var prime in MyLinq.GetPrimes().Skip(2).Take(10))
        {
            Assert.AreEqual(primes[index], prime);
            index++;
        }

        index = 2;
        foreach (var prime in MyLinq.GetPrimes().Skip(1).Skip(1).Take(10))
        {
            Assert.AreEqual(primes[index], prime);
            index++;
        }

        index = 0;
        foreach (var prime in MyLinq.GetPrimes().Take(0).Skip(0))
        {
            Assert.AreEqual(true, false); // it wont be checked because sequence will be empty
            index++;
        }

        index = 0;
        foreach (var prime in MyLinq.GetPrimes().Take(0).Skip(1968))
        {
            Assert.AreEqual(true, false); // it wont be checked because sequence will be empty
            index++;
        }
    }
}
