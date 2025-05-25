// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw5;

/// <summary>
/// Represents a node that stores either an operation or a value.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Parses given string and disassembles it into operators and operands.
    /// </summary>
    /// <param name="input">The string representation of the expression to parse.</param>
    /// <returns>Root node of tree built from the given expression.</returns>
    /// <exception cref="ArgumentException">Thrown if expression is in wrong format.</exception>
    public static Node Parse(string input)
    {
        Dictionary<string, Func<Node, Node, OperatorNode>> operatorMap =
        new Dictionary<string, Func<Node, Node, OperatorNode>>()
        {
            { "+", (l, r) => new AddNode(l, r) },
            { "-", (l, r) => new SubNode(l, r) },
            { "*", (l, r) => new MulNode(l, r) },
            { "/", (l, r) => new DivNode(l, r) },
        };

        input = input.Trim();

        if (!input.StartsWith("("))
        {
            if (int.TryParse(input, out int value))
            {
                return new ValueNode(value);
            }
            else
            {
                throw new ArgumentException($"The value '{value}' is not a valid integer.");
            }
        }

        input = input.Substring(1, input.Length - 2).Trim();

        int spaceIndex = input.IndexOf(' ');
        if (spaceIndex == input.Length - 1)
        {
            throw new ArgumentException("Wrong expression format.");
        }

        string operatorSymbol = input[..spaceIndex];

        if (!operatorMap.ContainsKey(operatorSymbol))
        {
            throw new ArgumentException($"Unknown operator '{operatorSymbol}'");
        }

        string rest = input[(spaceIndex + 1)..].Trim();

        string leftExpr, rightExpr;
        int braceCount = 0;
        int splitIndex = 0;

        for (int i = 0; i < rest.Length; i++)
        {
            if (rest[i] == '(')
            {
                braceCount++;
            }
            else if (rest[i] == ')')
            {
                braceCount--;
            }

            if (braceCount == 0 && rest[i] == ' ')
            {
                splitIndex = i;
                break;
            }
        }

        if (splitIndex == input.Length - 1)
        {
            throw new ArgumentException("Wrong expression format.");
        }

        leftExpr = rest[..splitIndex];
        rightExpr = rest[(splitIndex + 1)..].Trim();

        Node leftChild = Parse(leftExpr);
        Node rightChild = Parse(rightExpr);
        return operatorMap[operatorSymbol](leftChild, rightChild);
    }

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