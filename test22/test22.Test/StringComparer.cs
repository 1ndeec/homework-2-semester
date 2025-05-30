// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test22.Test;

/// <summary>
/// Implementation of IComparer for comparing string values
/// Provides standard ascending order comparison.
/// </summary>
public class StringComparer : IComparer<string>
{
    /// <summary>
    /// Compares two strings and returns their relative order.
    /// </summary>
    /// <param name="x">First string to compare (can be null).</param>
    /// <param name="y">Second string to compare (can be null).</param>
    /// <returns>
    /// Less than zero if x is less than y
    /// Zero if x equals y
    /// Greater than zero if x is greater than y.
    /// </returns>
    public int Compare(string? x, string? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        return string.Compare(x, y, StringComparison.Ordinal);
    }
}