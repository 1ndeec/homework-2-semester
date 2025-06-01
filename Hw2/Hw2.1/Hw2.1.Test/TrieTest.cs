// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw2.Test;

using Hw2;

/// <summary>
/// Testing class for Trie class.
/// </summary>
[TestClass]
public class TrieTest
{
    private Trie? trie;

    /// <summary>
    /// Sets up trie for tests.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        this.trie = new Trie();
    }

    /// <summary>
    /// testing method for trie`s add method.
    /// </summary>
    /// <param name="element"> element to add. </param>
    [DataTestMethod]
    [DataRow("")] // testing blank line
    [DataRow("blabla")]
    public void TrieAddTest(string element)
    {
        Assert.IsTrue(this.trie!.Add(element));
    }

    /// <summary>
    /// testing method for trie`s contains method.
    /// </summary>
    /// <param name="element"> element to check if there such in trie. </param>
    [TestMethod]
    public void TrieContainsTest()
    {
        this.trie!.Add("asdfa");
        Assert.IsTrue(this.trie!.Contains("asdfa"));
        Assert.IsFalse(this.trie!.Contains("asdfab")); // testing elements which are not represented in trie
    }

    /// <summary>
    /// testing method for trie`s remove method.
    /// </summary>
    /// <param name="element"> element to remove from trie. </param>
    [DataTestMethod]
    public void TrieRemoveTest()
    {
        this.trie!.Add("asdfa");
        Assert.IsTrue(this.trie!.Remove("asdfa"));
        this.trie!.Add("asdfa");
        Assert.IsFalse(this.trie!.Remove("asdfab")); // testing elements which are not represented in trie
    }

    /// <summary>
    /// testing method for trie`s HowManyStartsWithPrefix method.
    /// </summary>
    /// <param name="prefix"> prefix to count number of elements containing it. </param>
    [DataTestMethod]
    public void HowManyStartsWithPrefixTest()
    {
        this.trie!.Add("asdfa");
        this.trie!.Add("asdfab");
        this.trie!.Add("bla");
        Assert.AreEqual(this.trie!.HowManyStartsWithPrefix(string.Empty), 3);
        Assert.AreEqual(this.trie!.HowManyStartsWithPrefix("asdf"), 2);
        this.trie!.Add("asdfa");
        Assert.AreEqual(this.trie!.HowManyStartsWithPrefix("asdf"), 2); // checking if adding already existing in trie element will not change the value
        Assert.AreEqual(this.trie!.HowManyStartsWithPrefix("asdfa"), 2);
        Assert.AreEqual(this.trie!.HowManyStartsWithPrefix("asdfab"), 1);
        Assert.AreEqual(this.trie!.HowManyStartsWithPrefix("b"), 1);
    }

    /// <summary>
    /// testing method for trie`s HowManyStartsWithPrefix method.
    /// </summary>
    /// <param name="prefix"> prefix to count number of elements containing it. </param>
    [DataTestMethod]
    [ExpectedException(typeof(System.ArgumentException))]
    public void HowManyStartsWithPrefixTestException()
    {
        this.trie!.Add("asdfa");
        this.trie!.Add("asdfab");
        this.trie!.Add("bla");
        this.trie!.HowManyStartsWithPrefix("zaza"); // checking prefix which is not represented in trie
    }
}