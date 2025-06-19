// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw8.Test;

/// <summary>
/// Test class for SkipList&lt;T&gt class.
/// </summary>
[TestClass]
public sealed class SkipListTest
{
    private SkipList<int> skiplist = new SkipList<int>();

    /// <summary>
    /// Initializes skiplist.
    /// </summary>
    [TestInitialize]
    public void SkipListInitialize()
    {
        this.skiplist = new SkipList<int>();
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.Add method.
    /// </summary>
    [TestMethod]
    public void TestAdd()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.IsTrue(this.skiplist.Contains(1));
        Assert.IsTrue(this.skiplist.Contains(10));
        Assert.IsTrue(this.skiplist.Contains(5));
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.Remove method.
    /// </summary>
    [TestMethod]
    public void TestRemove()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        this.skiplist.Remove(1);
        this.skiplist.Remove(10);
        this.skiplist.Remove(5);
        Assert.IsFalse(this.skiplist.Remove(1968));
        Assert.IsFalse(this.skiplist.Contains(1));
        Assert.IsFalse(this.skiplist.Contains(10));
        Assert.IsFalse(this.skiplist.Contains(5));
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.Contains method.
    /// </summary>
    [TestMethod]
    public void TestContains()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.IsTrue(this.skiplist.Contains(1));
        Assert.IsTrue(this.skiplist.Contains(10));
        Assert.IsTrue(this.skiplist.Contains(5));
        this.skiplist.Remove(1);
        this.skiplist.Remove(10);
        this.skiplist.Remove(5);
        Assert.IsFalse(this.skiplist.Remove(1968));
        Assert.IsFalse(this.skiplist.Contains(1));
        Assert.IsFalse(this.skiplist.Contains(10));
        Assert.IsFalse(this.skiplist.Contains(5));
        Assert.IsFalse(this.skiplist.Contains(1968));
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.CopyTo method.
    /// </summary>
    [TestMethod]
    public void TestCopyTo()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);

        int[] testArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        this.skiplist.CopyTo(testArray, 3);
        Assert.AreEqual(string.Join(" ", testArray), "1 2 3 1 5 10 7 8 9 10");
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.CopyTo method.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestCopyToExceptionNull()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);

        int[]? testArray = null;
        this.skiplist.CopyTo(testArray!, 3);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.CopyTo method.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestCopyToExceptionOutOfRange()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);

        int[] testArray = new int[1] { 0 };
        this.skiplist.CopyTo(testArray!, -1);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.CopyTo method.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestCopyToExceptionArgument()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);

        int[] testArray = new int[3] { 0, 1, 3 };
        this.skiplist.CopyTo(testArray!, 2);
    }

    /// <summary>
    /// Test method to check how SkipList&lt;T&gt works with foreach cycle and enumenators.
    /// </summary>
    [TestMethod]
    public void TestForeach()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        int i = 0;
        foreach (int item in this.skiplist)
        {
            Assert.AreEqual(item, this.skiplist[i]);
            i++;
        }
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.Count property.
    /// </summary>
    [TestMethod]
    public void TestCount()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.AreEqual(this.skiplist.Count(), 3);
        this.skiplist.Remove(1);
        this.skiplist.Remove(10);
        this.skiplist.Remove(5);
        Assert.AreEqual(this.skiplist.Count(), 0);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.IsReadOnly property.
    /// </summary>
    [TestMethod]
    public void TestIsReadOnly()
    {
        Assert.IsFalse(this.skiplist.IsReadOnly);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt[int index] property.
    /// </summary>
    [TestMethod]
    public void TestItemIndexing()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.AreEqual(this.skiplist[0], 1);
        Assert.AreEqual(this.skiplist[1], 5);
        Assert.AreEqual(this.skiplist[2], 10);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt[int index] property.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestItemIndexingException()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.AreEqual(this.skiplist[1968], 1);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.Clear method.
    /// </summary>
    [TestMethod]
    public void TestClear()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        this.skiplist.Clear();
        Assert.AreEqual(0, this.skiplist.Count);
        Assert.IsFalse(this.skiplist.Remove(1));
        Assert.IsFalse(this.skiplist.Remove(5));
        Assert.IsFalse(this.skiplist.Remove(10));
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.IndexOf method.
    /// </summary>
    [TestMethod]
    public void TestIndexOf()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.AreEqual(this.skiplist.IndexOf(1), 0);
        Assert.AreEqual(this.skiplist.IndexOf(5), 1);
        Assert.AreEqual(this.skiplist.IndexOf(10), 2);
        Assert.AreEqual(this.skiplist.IndexOf(1968), -1);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.Insert method.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(NotSupportedException))]
    public void TestInsert()
    {
        this.skiplist.Insert(0, 1);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.RemoveAt method.
    /// </summary>
    [TestMethod]
    public void TestRemoveAt()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(5);
        this.skiplist.Add(10);
        this.skiplist.RemoveAt(1);
        Assert.AreEqual(this.skiplist[0], 1);
        Assert.AreEqual(this.skiplist[1], 10);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.RemoveAt method.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestRemoveAtException()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(5);
        this.skiplist.Add(10);
        this.skiplist.RemoveAt(1968);
    }

    /// <summary>
    /// Test method for SkipList&lt;T&gt.RemoveAt method.
    /// </summary>
    [TestMethod]
    public void TestModifyingMidEnumeratingException()
    {
        this.skiplist.Add(1);
        this.skiplist.Add(10);
        this.skiplist.Add(5);
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            foreach (int item in this.skiplist)
            {
                this.skiplist.Add(11);
            }
        });

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            foreach (int item in this.skiplist)
            {
                this.skiplist.Remove(11);
            }
        });

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            foreach (int item in this.skiplist)
            {
                this.skiplist.RemoveAt(2);
            }
        });

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            foreach (int item in this.skiplist)
            {
                this.skiplist.Clear();
            }
        });

    }
}
