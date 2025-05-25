// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores an operation.
/// </summary>
/// <param name="left">First operand.</param>
/// <param name="right">Second operand.</param>
public abstract class OperatorNode(Node left, Node right) : Node
{
    private Node left = left;
    private Node right = right;

    /// <summary>
    /// Gets first operand.
    /// </summary>
    protected Node Left => this.left;

    /// <summary>
    /// Gets second operand.
    /// </summary>
    protected Node Right => this.right;
}
