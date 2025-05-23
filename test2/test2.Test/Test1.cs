// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Check.Test;

using Test2;

/// <summary>
/// Test class for CustomList and ListNullCounter.
/// </summary>
[TestClass]
public sealed class Test1
{
    /// <summary>
    /// Test method for CountNullElements method.
    /// </summary>
    [TestMethod]
    public void TestCountNullElementsInt()
    {
        CustomList<int> list = new CustomList<int> { 1, 0, 3 };
        list.Add(0);
        Assert.AreEqual(2, ListNullCounter.CountNullElements(list, new IntNullChecker()));
        list.Add(0);
        Assert.AreEqual(3, ListNullCounter.CountNullElements(list, new IntNullChecker()));
        list.Add(3);
        Assert.AreEqual(3, ListNullCounter.CountNullElements(list, new IntNullChecker()));
    }

    /// <summary>
    /// Test method for CountNullElements method.
    /// </summary>
    [TestMethod]
    public void TestCountNullElementsString()
    {
        CustomList<string> list = new CustomList<string> { "bla", string.Empty, "bla" };
        list.Add(string.Empty);
        Assert.AreEqual(2, ListNullCounter.CountNullElements(list, new StringNullChecker()));
        list.Add(string.Empty);
        Assert.AreEqual(3, ListNullCounter.CountNullElements(list, new StringNullChecker()));
        list.Add("programming with envelope");
        Assert.AreEqual(3, ListNullCounter.CountNullElements(list, new StringNullChecker()));
    }

    /// <summary>
    /// Test method for CustomList`s add method.
    /// </summary>
    [TestMethod]
    public void AddTest()
    {
        CustomList<int> list = new CustomList<int> { 1, 0, 3 };
        list.Add(0);
        int[] tempArray = new int[] { 1, 0, 3, 0 };
        int i = 0;
        foreach (var item in list)
        {
            Assert.AreEqual(item, tempArray[i]);
            i++;
        }
    }

    /// <summary>
    /// Test method for CustomList`s GetEnumerator method.
    /// </summary>
    [TestMethod]
    public void EnumerableTest()
    {
        CustomList<int> list = new CustomList<int> { 1, 0, 3, 0 };
        int[] tempArray = new int[] { 1, 0, 3, 0 };
        int i = 0;
        foreach (var item in list)
        {
            Assert.AreEqual(item, tempArray[i]);
            i++;
        }
    }

    /// <summary>
    /// Test method for CustomList`s GetEnumerator method.
    /// </summary>
    [TestMethod]
    public void EnumerableTestEmpty()
    {
        CustomList<int> list = new CustomList<int>();
        foreach (var item in list)
        {
            Assert.AreEqual(false, true);
        }
    }

    /// <summary>
    /// Test method for CustomList`s constructor method.
    /// </summary>
    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void CustomListExceptionTest()
    {
        CustomList<int> list = new CustomList<int>(-5);
    }

    /// <summary>
    /// Test method for CustomList`s constructor method.
    /// </summary>
    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentNullException))]
    public void ListNullCounterExceptionListTest()
    {
        CustomList<int> list = new CustomList<int>();
        ListNullCounter.CountNullElements(null!, new StringNullChecker());
    }

    /// <summary>
    /// Test method for CustomList`s constructor method.
    /// </summary>
    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentNullException))]
    public void ListNullCounterExceptionCheckerTest()
    {
        CustomList<int> list = new CustomList<int>();
        ListNullCounter.CountNullElements(list, null!);
    }
}