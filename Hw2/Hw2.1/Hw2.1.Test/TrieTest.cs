// <copyright file="TrieTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw2.Test;

using Hw2;

/// <summary>
/// Testing class for Trie class.
/// </summary>
[TestClass]
public class TrieTest
{
    /// <summary>
    /// testing method for trie`s add method.
    /// </summary>
    /// <param name="element"> element to add. </param>
    [DataTestMethod]
    [DataRow("")] // testing blank line
    [DataRow("blabla")]
    public void TrieAddTest(string element)
    {
        Trie trie = new Hw2.Trie();
        Assert.AreEqual(trie.Add(element), true);
    }

    /// <summary>
    /// testing method for trie`s add method.
    /// </summary>
    /// <param name="element"> element to add. </param>
    [DataTestMethod]
    [DataRow("asdf1")] // testing elements with some chars outside of alphabet
    [ExpectedException(typeof(System.ArgumentException))]
    public void TrieAddTestException(string element)
    {
        Trie trie = new Hw2.Trie();
        trie.Add(element);
    }

    /// <summary>
    /// testing method for trie`s contains method.
    /// </summary>
    /// <param name="element"> element to check if there such in trie. </param>
    [TestMethod]
    public void TrieContainsTest()
    {
        Trie trie = new Trie();
        trie.Add("asdfa");
        Assert.AreEqual(trie.Contains("asdfa"), true);
        Assert.AreEqual(trie.Contains("asdfab"), false); // testing elements which are not represented in trie
    }

    /// <summary>
    /// testing method for trie`s contains method.
    /// </summary>
    /// <param name="element"> element to check if there such in trie. </param>
    [DataTestMethod]
    [DataRow("asdf1")] // testing elements with some chars outside of alphabet
    [ExpectedException(typeof(System.ArgumentException))]
    public void TrieContainsTestException(string element)
    {
        Trie trie = new Hw2.Trie();
        trie.Add("asdfa");
        trie.Contains(element);
    }

    /// <summary>
    /// testing method for trie`s remove method.
    /// </summary>
    /// <param name="element"> element to remove from trie. </param>
    [DataTestMethod]
    public void TrieRemoveTest()
    {
        Trie trie = new Trie();
        trie.Add("asdfa");
        Assert.AreEqual(trie.Remove("asdfa"), true);
        //trie.Add("asdfa");
        //Assert.AreEqual(trie.Remove("asdfab"), false); // testing elements which are not represented in trie
    }

    /// <summary>
    /// testing method for trie`s remove method.
    /// </summary>
    /// <param name="element"> element to remove from trie. </param>
    [DataTestMethod]
    [ExpectedException(typeof(System.ArgumentException))]
    public void TrieRemoveTestException()
    {
        Trie trie = new Hw2.Trie();
        trie.Add("asdfa");
        trie.Remove("asdf1"); // testing elements with some chars outside of alphabet
    }

    /// <summary>
    /// testing method for trie`s HowManyStartsWithPrefix method.
    /// </summary>
    /// <param name="prefix"> prefix to count number of elements containing it. </param>
    [DataTestMethod]
    public void HowManyStartsWithPrefixTest()
    {
        Trie trie = new Hw2.Trie();
        trie.Add("asdfa");
        trie.Add("asdfab");
        trie.Add("bla");
        Assert.AreEqual(trie.HowManyStartsWithPrefix(""), 3);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("asdf"), 2);
        trie.Add("asdfa");
        Assert.AreEqual(trie.HowManyStartsWithPrefix("asdf"), 2); // checking if adding already existing in trie element will not change the value
        Assert.AreEqual(trie.HowManyStartsWithPrefix("asdfa"), 2);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("asdfab"), 1);
        Assert.AreEqual(trie.HowManyStartsWithPrefix("b"), 1);
    }

    /// <summary>
    /// testing method for trie`s HowManyStartsWithPrefix method.
    /// </summary>
    /// <param name="prefix"> prefix to count number of elements containing it. </param>
    [DataTestMethod]
    [ExpectedException(typeof(System.ArgumentException))]
    public void HowManyStartsWithPrefixTestException()
    {
        Trie trie = new Hw2.Trie();
        trie.Add("asdfa");
        trie.Add("asdfab");
        trie.Add("bla");
        trie.HowManyStartsWithPrefix("zaza"); // checking prefix which is not represented in trie
    }
}

