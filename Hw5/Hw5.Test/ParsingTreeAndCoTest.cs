// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5.Test;

using Hw5;

/// <summary>
/// Provides test methods for ParsingTree, AddNode, SubNode, MulNode, DivNode, ValueNode classes.
/// </summary>
[TestClass]
public sealed class ParsingTreeAndCoTest
{
    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    public void ParsingTreeRegularTest()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression1.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
        Assert.AreEqual(tree.Compute(), 4);
        Assert.AreEqual(tree.Print(), "( * ( + 1 1 ) 2 )");
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    public void ParsingTreeNegativeValuesTest()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression9.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
        Assert.AreEqual(tree.Compute(), -4);
        Assert.AreEqual(tree.Print(), "( * ( + 1 1 ) -2 )");
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest1()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression2.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest2()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression3.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest3()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression4.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest4()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression5.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest5()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression6.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest6()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression7.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for ParsingTree class.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ParsingTreeExceptionTest7()
    {
        using StreamReader sr = new StreamReader("../../../testExpressions/testExpression8.txt");
        var tree = new ParsingTree(sr.ReadToEnd());
    }

    /// <summary>
    /// Test method for AddNode class.
    /// </summary>
    [TestMethod]
    public void AddNodeRegularTest()
    {
        var node = new SummationNode(new ValueNode(10), new ValueNode(12));
        Assert.AreEqual(node.Compute(), 22);
        Assert.AreEqual(node.Print(), "( + 10 12 )");
    }

    /// <summary>
    /// Test method for DivNode class.
    /// </summary>
    [TestMethod]
    public void DivNodeRegularTest()
    {
        var node = new DivisionNode(new ValueNode(10), new ValueNode(5));
        Assert.AreEqual(node.Compute(), 2);
        Assert.AreEqual(node.Print(), "( / 10 5 )");
    }

    /// <summary>
    /// Test method for MulNode class.
    /// </summary>
    [TestMethod]
    public void MulNodeRegularTest()
    {
        var node = new MultiplicationNode(new ValueNode(10), new ValueNode(12));
        Assert.AreEqual(node.Compute(), 120);
        Assert.AreEqual(node.Print(), "( * 10 12 )");
    }

    /// <summary>
    /// Test method for SubNode class.
    /// </summary>
    [TestMethod]
    public void SubNodeRegularTest()
    {
        var node = new SubtractionNode(new ValueNode(10), new ValueNode(12));
        Assert.AreEqual(node.Compute(), -2);
        Assert.AreEqual(node.Print(), "( - 10 12 )");
    }

    /// <summary>
    /// Test method for ValueNode class.
    /// </summary>
    [TestMethod]
    public void ValueNodeTest()
    {
        var node = new ValueNode(10);
        Assert.AreEqual(node.Compute(), 10);
        Assert.AreEqual(node.Print(), "10");
    }
}
