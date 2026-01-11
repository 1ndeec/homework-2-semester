// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test22.Test;

using System.Collections.Generic;
using Test22;

/// <summary>
/// Unit tests for CustomList class functionality.
/// </summary>
[TestClass]
public sealed class CustomListTest
{
    /// <summary>
    /// Tests the Add method by verifying elements are correctly appended
    /// and accessible via indexer.
    /// </summary>
    [TestMethod]
    public void TestAddMethod()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        // Verify all elements were added in correct order
        for (int i = 0; i < 4; i++)
        {
            Assert.AreEqual(list[i], i + 1);
        }
    }

    /// <summary>
    /// Tests element replacement through indexer by modifying values
    /// and verifying the changes.
    /// </summary>
    [TestMethod]
    public void TestReplaceMethod()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        // Modify elements via indexer
        list[0] = 0;
        list[1] = 2;
        list[2] = 4;
        list[3] = 6;

        // Verify elements were correctly modified
        for (int i = 0; i < 4; i++)
        {
            Assert.AreEqual(list[i], i * 2);
        }
    }

    /// <summary>
    /// Tests that attempting to replace an element at an invalid index
    /// throws ArgumentOutOfRangeException.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestReplaceExceptionMethod()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        // This should throw as index 4 is out of bounds
        list[4] = 0;
    }

    /// <summary>
    /// Tests that attempting to access an element at an invalid index
    /// throws ArgumentOutOfRangeException.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestGetExceptionMethod()
    {
        var list = new CustomList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        // This should throw as index 7 is out of bounds
        int temp = list[7];
    }
}