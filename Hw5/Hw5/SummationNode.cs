// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores a addition operation.
/// </summary>
/// <param name="left">First operand.</param>
/// <param name="right">Second operand.</param>
public class SummationNode(Node left, Node right) : OperatorNode(left, right)
{
    /// <summary>
    /// Computes the result of the addition operation.
    /// </summary>
    /// <returns> Node`s addition operation result. </returns>
    public override int Compute() => this.Left.Compute() + this.Right.Compute();

    /// <summary>
    /// Returns a string representation of addition operation stored in node.
    /// </summary>
    /// <returns>A string representation of addition operation stored in node.</returns>
    public override string Print() => $"( + {this.Left.Print()} {this.Right.Print()} )";
}
