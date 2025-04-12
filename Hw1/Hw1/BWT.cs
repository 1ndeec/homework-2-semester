// <copyright file="BWT.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw1
{
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
        public static (string EncodedData, int Position) Encode(string data)
        {
            int length = data.Length;
            char[] output = new char[length];
            int index = 0; // last element in sorted cyclic permutation array which is equal to entered string
            string[] revolver = new string[length];

            if (length == 0) // if blank line
            {
                throw new ArgumentException("Input cannot be blank or whitespace.");
            }

            for (int i = 0; i < length; i++) // getting cyclical permutations
            {
                revolver[i] = string.Concat(data.AsSpan(i, length - i), data.AsSpan(0, i));
            }

            revolver = revolver.OrderBy(x => x).ToArray(); // sorting permutations

            for (int i = 0; i < length; i++)
            {
                if (revolver[i] == data) // if equal to origin string, then remember the index
                {
                    index = i;
                }

                output[i] = revolver[i][length - 1]; // remember last char
            }

            return (string.Join(string.Empty, output), index);
        }

        /// <summary>
        /// Requires a string and specified key that user want to decode.
        /// Returns decoded string.
        /// </summary>
        /// <param name="data"> Input string. </param>
        /// <param name="position"> Specified key. </param>
        /// <returns> Decoded string. </returns>
        public static string Decode(string data, int position)
        {
            int length = data.Length;
            char[] output = new char[length];
            SortedDictionary<char, int> alphabet = new SortedDictionary<char, int>(); // number of identical chars in string for every char
            int[] numberInPrefix = new int[length]; // number of identical chars in prefix [0...i] of the string to char which is on [i] position

            if (position >= length)
            {
                throw new IndexOutOfRangeException("position value cant be higher that number of chars in encoded string");
            }

            for (int i = 0; i < length; i++)
            {
                if (!alphabet.ContainsKey(data[i]))
                {
                    alphabet.Add(data[i], 0);
                }

                numberInPrefix[i] = alphabet[data[i]];
                alphabet[data[i]]++;
            }

            Dictionary<char, int> numberOfSmaller = new Dictionary<char, int>(); // number of chars in the string which are lexicographically smaller to certain char

            int sum = 0;
            foreach (KeyValuePair<char, int> letter in alphabet)
            {
                numberOfSmaller.Add(letter.Key, sum);
                sum += letter.Value;
            }

            for (int i = length - 1; i >= 0; i--)
            {
                output[i] = data[position];
                position = numberOfSmaller[data[position]] + numberInPrefix[position];
            }

            return string.Join(string.Empty, output);
        }
    }
}
