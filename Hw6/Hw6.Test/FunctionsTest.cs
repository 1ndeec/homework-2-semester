// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw6.Test;

using Hw6;

/// <summary>
/// test class of test methods testing methods of Functions class.
/// </summary>
[TestClass]
public sealed class FunctionsTest
{
    /// <summary>
    /// test method to test Map function.
    /// </summary>
    [TestMethod]
    public void TestMethodMap()
    {
        CollectionAssert.AreEqual(Functions.Map(new List<int>() { 1, 2, 3, 4 }, x => (x * 2)), new List<int>() { 2, 4, 6, 8 });
    }

    /// <summary>
    /// test method to how Map function works with empty lists.
    /// </summary>
    [TestMethod]
    public void TestNullMethodMap()
    {
        CollectionAssert.AreEqual(Functions.Map(new List<int>(), x => (x * 2)), new List<int>());
    }

    /// <summary>
    /// test method to test Filter function.
    /// </summary>
    [TestMethod]
    public void TestMethodFilter()
    {
        CollectionAssert.AreEqual(Functions.Filter(new List<int>() { 1, 2, 3, 4 }, x => ((x % 2) == 0 ? true : false)), new List<int>() { 2, 4 });
    }

    /// <summary>
    /// test method to how Filter function works with empty lists.
    /// </summary>
    [TestMethod]
    public void TestNullMethodFilter()
    {
        CollectionAssert.AreEqual(Functions.Filter(new List<int>(), x => ((x % 2) == 0 ? true : false)), new List<int>());
    }

    /// <summary>
    /// test method to test Fold function.
    /// </summary>
    [TestMethod]
    public void TestFindFold()
    {
        Assert.AreEqual(Functions.Fold(new List<int>() { 1, 2, 3, 4 }, 0, (x, y) => (x + y)), 10);
    }

    /// <summary>
    /// test method to how Fold function works with empty lists.
    /// </summary>
    [TestMethod]
    public void TestNullFindFold()
    {
        Assert.AreEqual(Functions.Fold(new List<int>(), 0, (x, y) => (x + y)), 0);
    }
}
