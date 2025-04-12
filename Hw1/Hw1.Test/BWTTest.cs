// <copyright file="BWTTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw1.Test;

using Hw1;

/// <summary>
/// test class for BWT.
/// </summary>
[TestClass]
public sealed class BWTTest
{
    /// <summary>
    /// testing class for Encode function in BWT class.
    /// </summary>
    /// <param name="data"> input string to be encoded. </param>
    /// <param name="dataEncoded"> supposed form of the encoded string. </param>
    /// <param name="position"> supposed position. </param>
    [DataTestMethod]
    [DataRow("banana", "nnbaaa", 3)]
    [DataRow("mississippi", "pssmipissii", 4)]
    [DataRow("abracadabra", "rdarcaaaabb", 2)]
    [DataRow("panama", "npmaaa", 5)]
    [DataRow("aaaaaa", "aaaaaa", 5)] // checks if returns index of last cyclical permutation that is identical to original string
    [DataRow("abcdefg", "gabcdef", 0)]
    [DataRow("toot", "toto", 2)]
    [DataRow("abababab", "bbbbaaaa", 3)]
    [DataRow("racecar", "rceacra", 5)]
    [DataRow("thequick", "ihtucekq", 6)]
    public void EncodeTest(string data, string dataEncoded, int position)
    {
        var answer = BWT.Encode(data);
        Assert.AreEqual(answer, (dataEncoded, position));
    }

    /// <summary>
    /// testing class for Encode function in BWT class.
    /// </summary>
    /// <param name="data"> input string that to be encoded. </param>
    [DataTestMethod]
    [DataRow("")] // checks if throws exception on blank string
    [ExpectedException(typeof(System.ArgumentException))]
    public void EncodeExceptionTest(string data)
    {
        var answer = BWT.Encode(data);
    }

    /// <summary>
    /// testing class for Decode function in BWT class.
    /// </summary>
    /// <param name="data"> supposed form of decoded string. </param>
    /// <param name="dataEncoded"> input encoded string to be decoded. </param>
    /// <param name="position"> input position. </param>
    [DataTestMethod]
    [DataRow("banana", "nnbaaa", 3)]
    [DataRow("mississippi", "pssmipissii", 4)]
    [DataRow("abracadabra", "rdarcaaaabb", 2)]
    [DataRow("panama", "npmaaa", 5)]
    [DataRow("aaaaaa", "aaaaaa", 5)]
    [DataRow("abcdefg", "gabcdef", 0)]
    [DataRow("toot", "toto", 2)]
    [DataRow("abababab", "bbbbaaaa", 3)]
    [DataRow("racecar", "rceacra", 5)]
    [DataRow("thequick", "ihtucekq", 6)]
    public void DecodeTest(string data, string dataEncoded, int position)
    {
        var answer = BWT.Decode(dataEncoded, position);
        Assert.AreEqual(answer, data);
    }

    /// <summary>
    /// testing class for Decode function in BWT class.
    /// </summary>
    /// <param name="dataEncoded"> input encoded string to be decoded. </param>
    /// <param name="position"> input position. </param>
    [DataTestMethod]
    [DataRow("banana", 10)] // checks if throws IndexOutOfRangeException when position number higher that number of overall chars in string
    [DataRow("", 3)] // checks if throws IndexOutOfRangeException even with blank strings
    [ExpectedException(typeof(System.IndexOutOfRangeException))]
    public void DecodeExeptionTest(string dataEncoded, int position)
    {
        var answer = BWT.Decode(dataEncoded, position);
    }
}