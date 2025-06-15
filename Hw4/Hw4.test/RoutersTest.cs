// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw4.Test;

using Hw4;

/// <summary>
/// testing class for Routers Optimise function.
/// </summary>
[TestClass]
[DoNotParallelize]
public sealed class RoutersTest
{
    /// <summary>
    /// testing how does Optimise method works with empty data.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void OptimumEmptyTest() => Routers.Optimize("../../../TestData/testEmpty.txt", "../../../TestData/testOutEmpty.txt");

    /// <summary>
    /// testing how does Optimise method works with disconnected graphs.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void OptimumDisconnectedTest() => Routers.Optimize("../../../TestData/testDisconnected.txt", "../../../TestData/testOutDisconnected.txt");

    /// <summary>
    /// testing how does Optimise method works with regular graphs.
    /// </summary>
    [TestMethod]
    public void OptimumTest()
    {
        Routers.Optimize("../../../TestData/test1.txt", "../../../TestData/testOut1.txt");
        var sr = new StreamReader("../../../TestData/testOut1.txt");
        Assert.AreEqual(sr.ReadLine(), "1: 2 (100), 5 (100)");
        Assert.AreEqual(sr.ReadLine(), "2: 3 (100)");
        Assert.AreEqual(sr.ReadLine(), "3: 4 (100)");
    }
}