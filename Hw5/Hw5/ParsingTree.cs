// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents an expression`s parsing tree.
/// </summary>
public class ParsingTree
{
    private Node root;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParsingTree"/> class.
    /// </summary>
    public ParsingTree()
    {
        this.root = new ValueNode(0);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ParsingTree"/> class.
    /// </summary>
    /// <param name="toParse">String representation of the expression.</param>
    public ParsingTree(string toParse)
    {
        this.root = Node.Parse(toParse);
    }

    /// <summary>
    /// Returns a string representation of parsed expression.
    /// </summary>
    /// <returns>A string representation of parsed expression.</returns>
    public string Print()
    {
        return this.root.Print();
    }

    /// <summary>
    /// Returns the result of parsed expression.
    /// </summary>
    /// <returns>The result of parsed expression.</returns>
    public int Compute()
    {
        return this.root.Compute();
    }
}
