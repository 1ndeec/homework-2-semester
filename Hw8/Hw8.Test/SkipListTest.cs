// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw8.Test
{
    /// <summary>
    /// Test class for SkipList&lt;T&gt class.
    /// </summary>
    [TestClass]
    public sealed class SkipListTest
    {
        /// <summary>
        /// Test method for SkipList&lt;T&gt.Add method.
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            Assert.IsTrue(skiplist.Contains(1));
            Assert.IsTrue(skiplist.Contains(10));
            Assert.IsTrue(skiplist.Contains(5));
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.Remove method.
        /// </summary>
        [TestMethod]
        public void TestRemove()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            skiplist.Remove(1);
            skiplist.Remove(10);
            skiplist.Remove(5);
            Assert.IsFalse(skiplist.Remove(1968));
            Assert.IsFalse(skiplist.Contains(1));
            Assert.IsFalse(skiplist.Contains(10));
            Assert.IsFalse(skiplist.Contains(5));
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.Contains method.
        /// </summary>
        [TestMethod]
        public void TestContains()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            Assert.IsTrue(skiplist.Contains(1));
            Assert.IsTrue(skiplist.Contains(10));
            Assert.IsTrue(skiplist.Contains(5));
            skiplist.Remove(1);
            skiplist.Remove(10);
            skiplist.Remove(5);
            Assert.IsFalse(skiplist.Remove(1968));
            Assert.IsFalse(skiplist.Contains(1));
            Assert.IsFalse(skiplist.Contains(10));
            Assert.IsFalse(skiplist.Contains(5));
            Assert.IsFalse(skiplist.Contains(1968));
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.CopyTo method.
        /// </summary>
        [TestMethod]
        public void TestCopyTo()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);

            int[] testArray = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            skiplist.CopyTo(testArray, 3);
            Assert.AreEqual(string.Join(" ", testArray), "1 2 3 1 5 10 7 8 9 10");
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.CopyTo method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCopyToExceptionNull()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);

            int[]? testArray = null;
            skiplist.CopyTo(testArray!, 3);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.CopyTo method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCopyToExceptionOutOfRange()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);

            int[] testArray = new int[1] { 0 };
            skiplist.CopyTo(testArray!, -1);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.CopyTo method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCopyToExceptionArgument()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);

            int[] testArray = new int[3] { 0, 1, 3 };
            skiplist.CopyTo(testArray!, 2);
        }

        /// <summary>
        /// Test method to check how SkipList&lt;T&gt works with foreach cycle and enumenators.
        /// </summary>
        [TestMethod]
        public void TestForeach()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            int i = 0;
            foreach (int item in skiplist)
            {
                Assert.AreEqual(item, skiplist[i]);
                i++;
            }
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.Count property.
        /// </summary>
        [TestMethod]
        public void TestCount()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            Assert.AreEqual(skiplist.Count(), 3);
            skiplist.Remove(1);
            skiplist.Remove(10);
            skiplist.Remove(5);
            Assert.AreEqual(skiplist.Count(), 0);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.IsReadOnly property.
        /// </summary>
        [TestMethod]
        public void TestIsReadOnly()
        {
            SkipList<int> skiplist = new SkipList<int>();
            Assert.IsFalse(skiplist.IsReadOnly);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt[int index] property.
        /// </summary>
        [TestMethod]
        public void TestItemIndexing()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            Assert.AreEqual(skiplist[0], 1);
            Assert.AreEqual(skiplist[1], 5);
            Assert.AreEqual(skiplist[2], 10);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt[int index] property.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestItemIndexingException()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            Assert.AreEqual(skiplist[1968], 1);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.Clear method.
        /// </summary>
        [TestMethod]
        public void TestClear()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            skiplist.Clear();
            Assert.AreEqual(0, skiplist.Count);
            Assert.IsFalse(skiplist.Remove(1));
            Assert.IsFalse(skiplist.Remove(5));
            Assert.IsFalse(skiplist.Remove(10));
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.IndexOf method.
        /// </summary>
        [TestMethod]
        public void TestIndexOf()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(10);
            skiplist.Add(5);
            Assert.AreEqual(skiplist.IndexOf(1), 0);
            Assert.AreEqual(skiplist.IndexOf(5), 1);
            Assert.AreEqual(skiplist.IndexOf(10), 2);
            Assert.AreEqual(skiplist.IndexOf(1968), -1);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.Insert method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestInsert()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Insert(0, 1);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.RemoveAt method.
        /// </summary>
        [TestMethod]
        public void TestRemoveAt()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(5);
            skiplist.Add(10);
            skiplist.RemoveAt(1);
            Assert.AreEqual(skiplist[0], 1);
            Assert.AreEqual(skiplist[1], 10);
        }

        /// <summary>
        /// Test method for SkipList&lt;T&gt.RemoveAt method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAtException()
        {
            SkipList<int> skiplist = new SkipList<int>();
            skiplist.Add(1);
            skiplist.Add(5);
            skiplist.Add(10);
            skiplist.RemoveAt(1968);
        }
    }
}
