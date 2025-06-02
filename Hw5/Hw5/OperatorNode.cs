// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores an operation.
/// </summary>
/// <param name="leftNode">First operand.</param>
/// <param name="rightNode">Second operand.</param>
public abstract class OperatorNode(Node leftNode, Node rightNode) : Node
{
    private Node leftNode = leftNode;
    private Node rightNode = rightNode;

    /// <summary>
    /// Gets first operand.
    /// </summary>
    protected Node Left => this.leftNode;

    /// <summary>
    /// Gets second operand.
    /// </summary>
    protected Node Right => this.rightNode;
}
