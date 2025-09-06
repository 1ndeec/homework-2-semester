// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw3;

/// <summary>
/// class for functions related to Burrows-Wheeler transform algorithm.
/// </summary>
public class BWT
{
    /// <summary>
    /// Requires a string that user want to encode.
    /// Returns encoded string and specified key.
    /// </summary>
    /// <param name="data"> Input string. </param>
    /// <returns> Encoded string and specified key. </returns>
    public static (byte[] EncodedData, int Position) Encode(byte[] data)
    {
        int length = data.Length;
        var output = new byte[length];

        // if blank line
        if (length == 0)
        {
            throw new ArgumentException("Input cannot be blank or whitespace.");
        }

        var revolver = new byte[length][];

        // getting cyclical permutations
        for (int i = 0; i < length; i++)
        {
            revolver[i] = data[i..].Concat(data[..i]).ToArray();
        }

        Array.Sort(revolver, (a, b) =>
        {
            for (int i = 0; i < a.Length; i++)
            {
                int cmp = a[i].CompareTo(b[i]);
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            return 0;
        });

        // last element in sorted cyclic permutation array which is equal to entered string
        int index = 0;

        // sorting permutations
        for (int i = 0; i < length; i++)
        {
            // if equal to origin string, then remember the index
            if (revolver[i] == data)
            {
                index = i;
            }

            // remember last char
            output[i] = revolver[i][length - 1];
        }

        return (output, index);
    }
}
