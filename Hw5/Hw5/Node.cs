// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores either an operation or a value.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Returns a result of the expression represented by the node.
    /// </summary>
    /// <returns>A result of the expression represented by the node.</returns>
    public abstract int Compute();

    /// <summary>
    /// Returns a string representation of the expression represented by the node.
    /// </summary>
    /// <returns>A string representation of the expression.</returns>
    public abstract string Print();
}