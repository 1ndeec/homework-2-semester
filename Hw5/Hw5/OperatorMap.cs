// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Provides a mapping from operator symbols to corresponding node constructors for building expression trees.
/// </summary>
public static class OperatorMap
{
    private static Dictionary<string, Func<Node, Node, OperatorNode>> operatorMap =
        new Dictionary<string, Func<Node, Node, OperatorNode>>()
    {
            { "+", (l, r) => new AddNode(l, r) },
            { "-", (l, r) => new SubNode(l, r) },
            { "*", (l, r) => new MulNode(l, r) },
            { "/", (l, r) => new DivNode(l, r) },
    };

    /// <summary>
    /// Returns whether operatorMap contains an associated constructor for this operator.
    /// </summary>
    /// <param name="operatorToFind">Operator to find constructor for.</param>
    /// <returns>Whether operatorMap contains an associated constructor for this operator.</returns>
    public static bool Contains(string operatorToFind) => operatorMap.ContainsKey(operatorToFind);

    /// <summary>
    /// Returns new OperatorNode for given operator and its children.
    /// </summary>
    /// <param name="operatorToFind">Operator to base new OperatorNode on.</param>
    /// <param name="leftChild">Node which will be a left child of a new OperatorNode.</param>
    /// <param name="rightChild">Node which will be a right child of a new OperatorNode.</param>
    /// <returns>New OperatorNode for given operator and its children.</returns>
    public static Node ReturnConstructor(string operatorToFind, Node leftChild, Node rightChild) => operatorMap[operatorToFind](leftChild, rightChild);
}
