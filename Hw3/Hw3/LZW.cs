// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw3;

using System.Text;

/// <summary>
/// Class of LZW compression algorithm.
/// </summary>
public class LZW
{
    /// <summary>
    /// Method of compression.
    /// </summary>
    /// <param name="path"> path of file to be compressed. </param>
    /// <returns> compression efficiency. </returns>
    public static double Compress(string path)
    {
        return CompressData(File.ReadAllBytes(path), path);
    }

    /// <summary>
    /// Method of decompression.
    /// </summary>
    /// <param name="path"> path of file to be decompressed. </param>
    public static void Decompress(string path)
    {
        var dictionary = new Dictionary<uint, byte[]>();
        for (uint i = 0; i <= byte.MaxValue; i++)
        {
            dictionary.Add(i, new byte[1] { (byte)i });
        }

        var reader = new BinaryReader(File.Open(path, FileMode.Open));
        var decompressed = new List<byte[]>();

        if (reader.BaseStream.Length > 0)
        {
            var code1 = uint.MaxValue;
            var code2 = uint.MaxValue;
            int encodingMode = 0;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                code2 = encodingMode switch
                {
                    0 => reader.ReadByte(),
                    1 => reader.ReadUInt16(),
                    2 => reader.ReadUInt32(),
                    _ => throw new ArgumentException("Unsupported code length for symbol encoding."),
                };

                byte[] newElement;

                if (code1 != uint.MaxValue)
                {
                    if (dictionary.ContainsKey(code1) && dictionary.ContainsKey(code2))
                    {
                        newElement = dictionary[code1].Append(dictionary[code2][0]).ToArray();
                    }
                    else
                    {
                        newElement = dictionary[code1].Append(dictionary[code1][0]).ToArray();
                    }

                    dictionary.Add((uint)dictionary.Count(), newElement);
                    decompressed.Add(dictionary[code1]);
                }

                code1 = code2;
                var maxValues = new uint[3] { byte.MaxValue, ushort.MaxValue, uint.MaxValue };

                if (dictionary.Count() > maxValues[encodingMode])
                {
                    encodingMode++;
                }
            }

            decompressed.Add(dictionary[code2]);
        }

        reader.Close();

        var fileName = Path.GetFileName(path);
        var newFileName = fileName[0..(fileName.Length - 7)];
        string? directory = Path.GetDirectoryName(path);
        string outputPath;
        if (directory != null)
        {
            outputPath = Path.Combine(directory, newFileName);
        }
        else
        {
            throw new ArgumentNullException("Null path.");
        }

        using var writer = new BinaryWriter(File.Open(outputPath, FileMode.Create));
        foreach (byte[] code in decompressed)
        {
            writer.Write(code);
        }

        writer.Close();
    }

    /// <summary>
    /// Method of compression, which also apply BWT algorithm on input data to be compressed.
    /// </summary>
    /// <param name="path"> path of file to be compressed. </param>
    /// <returns> compression efficiency. </returns>
    public static double CompressWithBWT(string path)
    {
        byte[] data = File.ReadAllBytes(path);

        var dataBWT = BWT.Encode(data);
        byte[] bytes = dataBWT.EncodedData.Concat(BitConverter.GetBytes(dataBWT.Position)).ToArray();

        return CompressData(bytes, path);
    }

    /// <summary>
    /// Method of compression, but works with data and not with path for file containing it.
    /// </summary>
    /// <param name="path"> path of file where we get the data, required to create .zipped file. </param>
    /// <returns> compression efficiency. </returns>
    private static double CompressData(byte[] bytes, string path)
    {
        if (bytes.Length > 0)
        {
            var writer = new BinaryWriter(File.Open(path + ".zipped", FileMode.Create));
            int encodingMode = 0;
            int currentStart = 0;
            var trie = new Trie();
            trie.AddAlphabet();

            long bytesSpent = 0;
            uint indexOfWord = 0;
            for (int currentEnd = 1; currentEnd <= bytes.Length; currentEnd++)
            {
                if (trie.Contains(bytes[currentStart..currentEnd]) == uint.MaxValue)
                {
                    indexOfWord = trie.Contains(bytes[currentStart..(currentEnd - 1)]);
                    switch (encodingMode)
                    {
                        case 0:
                            writer.Write((byte)indexOfWord);
                            break;
                        case 1:
                            writer.Write((ushort)indexOfWord);
                            break;
                        case 2:
                            writer.Write(indexOfWord);
                            break;
                    }

                    trie.Add(bytes[currentStart..currentEnd]);
                    currentStart = currentEnd - 1;
                    bytesSpent += (long)Math.Pow(2, encodingMode);

                    var maxValues = new uint[3] { byte.MaxValue, ushort.MaxValue, uint.MaxValue };
                    if (trie.CurrentWord > maxValues[encodingMode])
                    {
                        encodingMode++;
                    }
                }
            }

            indexOfWord = trie.Contains(bytes[currentStart..]);
            switch (encodingMode)
            {
                case 0:
                    writer.Write((byte)indexOfWord);
                    break;
                case 1:
                    writer.Write((ushort)indexOfWord);
                    break;
                case 2:
                    writer.Write(indexOfWord);
                    break;
            }

            bytesSpent += (long)Math.Pow(2, encodingMode);

            writer.Close();

            return (double)bytes.Length / (double)bytesSpent;
        }
        else
        {
            return 1;
        }
    }
}
