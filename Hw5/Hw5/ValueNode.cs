// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores an integer value.
/// </summary>
/// <param name="value">The integer value stored in the node.</param>
public class ValueNode(int value) : Node
{
    private int value = value;

    /// <summary>
    /// Computes the value of the node.
    /// </summary>
    /// <returns>The integer value stored in the node.</returns>
    public override int Compute() => this.value;

    /// <summary>
    /// Returns a string representation of the node's value.
    /// </summary>
    /// <returns>A string representation of the value. </returns>
    public override string Print() => this.value.ToString();
}
