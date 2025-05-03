// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw4.Test;

using Hw4;

/// <summary>
/// testing class for Routers.Optimise function.
/// </summary>
[TestClass]
[DoNotParallelize]
public sealed class Test1
{
    /// <summary>
    /// testing method with testing how function works with empty input data.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void OptimumEmptyTest()
    {
        Routers.Optimum("../../../TestData/testEmpty.txt", "../../../TestData/testOutEmpty.txt");
    }

    /// <summary>
    /// testing method with testing how function works with disconnected input graphs.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void OptimumDisconnectedTest()
    {
        Routers.Optimum("../../../TestData/testDisconnected.txt", "../../../TestData/testOutDisconnected.txt");
    }

    /// <summary>
    /// testing method with testing how function works with regular graphs.
    /// </summary>
    [TestMethod]
    public void OptimumTest()
    {
        Routers.Optimum("../../../TestData/test1.txt", "../../../TestData/testOut1.txt");
        var sr = new StreamReader("../../../TestData/testOut1.txt");
        Assert.AreEqual(sr.ReadLine(), "1: 2 (100), 5 (100)");
        Assert.AreEqual(sr.ReadLine(), "2: 3 (100)");
        Assert.AreEqual(sr.ReadLine(), "3: 4 (100)");
    }
}