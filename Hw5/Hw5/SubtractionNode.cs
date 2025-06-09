// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores a subtraction operation.
/// </summary>
/// <param name="left">First operand.</param>
/// <param name="right">Second operand.</param>
public class SubtractionNode(Node left, Node right) : OperatorNode(left, right)
{
    /// <summary>
    /// Computes the result of the subtraction operation.
    /// </summary>
    /// <returns> Node`s subtraction operation result. </returns>
    public override int Compute() => this.Left.Compute() - this.Right.Compute();

    /// <summary>
    /// Returns a string representation of subtraction operation stored in node.
    /// </summary>
    /// <returns>A string representation of subtraction operation stored in node.</returns>
    public override string Print() => $"( - {this.Left.Print()} {this.Right.Print()} )";
}
