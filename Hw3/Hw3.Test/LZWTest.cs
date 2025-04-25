// <copyright file="LZWTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw3.Test
{
    /// <summary>
    /// Test class for LZW test.
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public sealed class LZWTest
    {
        /// <summary>
        /// Test method to check if LZW algorithm can work with blank files.
        /// </summary>
        [TestMethod]
        public void CompressEmptyTest()
        {
            LZW.Compress("../../../TestData/emptyTest.txt");
            string compressedData = File.ReadAllText("../../../TestData/emptyTest.txt.zipped");
            Assert.AreEqual(compressedData, string.Empty);

            LZW.DeCompress("../../../TestData/emptyTest.txt.zipped"); // if previous test worked out then we don`t have to create extra .zipped file to test empty .zipped file
            string deCompressedData = File.ReadAllText("../../../TestData/emptyTest.txt");
            Assert.AreEqual(deCompressedData, string.Empty);
        }

        /// <summary>
        /// Test method to check how LZW works with small files.
        /// </summary>
        [TestMethod]
        public void CompressSmallTest()
        {
            LZW.Compress("../../../TestData/smallTest.txt");
            string compressedData = File.ReadAllText("../../../TestData/smallTest.txt.zipped");
            Assert.AreEqual(compressedData, "he\0l\0l\0o\0 \0\0\u0001\u0002\u0001 \0n\0o\0");

            LZW.DeCompress("../../../TestData/smallTest.txt.zipped");
            string deCompressedData = File.ReadAllText("../../../TestData/smallTest.txt");
            Assert.AreEqual(deCompressedData, "hello hell no");
        }

        /// <summary>
        /// Test method to check how LZW works with large files.
        /// </summary>
        [TestMethod]
        public void CompressLargeTest()
        {
            string originalData = File.ReadAllText("../../../TestData/largeTest.txt");
            Assert.IsTrue(LZW.Compress("../../../TestData/largeTest.txt") > 1);
            LZW.DeCompress("../../../TestData/largeTest.txt.zipped");
            Assert.AreEqual(originalData, File.ReadAllText("../../../TestData/largeTest.txt"));
        }

        /// <summary>
        /// Test method to compare LZW compressing with and without BWT.
        /// </summary>
        [TestMethod]
        public void CompressWithBWTCompareTest()
        {
            double without = LZW.Compress("../../../TestData/largeTestForBWT.txt");
            double with = LZW.CompressWithBWT("../../../TestData/largeTestForBWT.txt");

            Assert.AreEqual(without, 1.8560957894041776);
            Assert.AreEqual(with, 1.8791416921054391);
        }

        /// <summary>
        /// Test method to check how LZW works with .exe files.
        /// </summary>
        [TestMethod]
        public void CompressExeTest()
        {
            LZW.Compress("../../../TestData/testCalc.exe");
            LZW.DeCompress("../../../TestData/testCalc.exe.zipped");
        }
    }
}
