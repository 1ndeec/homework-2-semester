// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test22.Test;

/// <summary>
/// Implementation of IComparer for comparing integer values
/// Provides standard ascending order comparison.
/// </summary>
public class IntComparer : IComparer<int>
{
    /// <summary>
    /// Compares two integers and returns their relative order.
    /// </summary>
    /// <param name="x">First integer to compare.</param>
    /// <param name="y">Second integer to compare.</param>
    /// <returns>
    /// Less than zero if x is less than y
    /// Zero if x equals y
    /// Greater than zero if x is greater than y.
    /// </returns>
    public int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}