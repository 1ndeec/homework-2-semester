// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test22.Test;

using System.Collections.Generic;
using Test22;

/// <summary>
/// Unit tests for the ListUtils.Sort extension method functionality.
/// </summary>
[TestClass]
public sealed class ListUtilsTest
{
    /// <summary>
    /// Tests sorting of integer values using the IntComparer
    /// Verifies the list is sorted in ascending order.
    /// </summary>
    [TestMethod]
    public void TestSortIntMethod()
    {
        // Arrange - create an unsorted list of integers
        var list = new CustomList<int>();
        list.Add(4);
        list.Add(3);
        list.Add(2);
        list.Add(1);

        // Act - sort the list using IntComparer
        list = ListUtils.Sort(list, new IntComparer());

        // Assert - verify the list is sorted in ascending order
        for (int i = 0; i < 4; i++)
        {
            Assert.AreEqual(list[i], i + 1);
        }
    }

    /// <summary>
    /// Tests sorting of string values using the StringComparer
    /// Verifies the list is sorted in lexicographical order.
    /// </summary>
    [TestMethod]
    public void TestSortStringMethod()
    {
        // Arrange - create an unsorted list of strings
        var list = new CustomList<string>();
        list.Add("abcd");
        list.Add("abcc");
        list.Add("abbb");
        list.Add("aaaa");

        // Act - sort the list using StringComparer
        list = ListUtils.Sort(list, new StringComparer());

        // Assert - verify the exact order of sorted strings
        Assert.AreEqual(list[0], "aaaa");
        Assert.AreEqual(list[1], "abbb");
        Assert.AreEqual(list[2], "abcc");
        Assert.AreEqual(list[3], "abcd");
    }

    /// <summary>
    /// Test method for Sort method of ListUtils class, expects exception.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestSortIntExceptionListMethod()
    {
        var list = ListUtils.Sort(null!, new StringComparer());
    }

    /// <summary>
    /// Test method for Sort method of ListUtils class, expects exception.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestSortIntExceptionComparerMethod()
    {
        var tempList = new CustomList<int>();
        var list = ListUtils.Sort(tempList, null!);
    }
}