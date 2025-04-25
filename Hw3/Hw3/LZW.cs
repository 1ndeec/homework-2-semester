// <copyright file="LZW.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw3
{
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
            byte[] bytes;
            try
            {
                bytes = File.ReadAllBytes(path);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"Processing failed: {exception.Message}");
                return -1;
            }

            return CompressData(bytes, path);
        }

        /// <summary>
        /// Method of decompression.
        /// </summary>
        /// <param name="path"> path of file to be decompressed. </param>
        public static void DeCompress(string path)
        {
            List<byte[]> deCompressed = new List<byte[]>();
            int encodingMode = 0;
            uint[] maxValues = new uint[3] { byte.MaxValue, ushort.MaxValue, uint.MaxValue };
            Dictionary<uint, byte[]> dictionary = new Dictionary<uint, byte[]>();
            for (uint i = 0; i <= byte.MaxValue; i++)
            {
                dictionary.Add(i, new byte[1] { (byte)i });
            }

            BinaryReader reader;

            try
            {
                reader = new BinaryReader(File.Open(path, FileMode.Open));
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"Processing failed: {exception.Message}");
                return;
            }

            if (reader.BaseStream.Length > 0)
            {
                uint code1 = uint.MaxValue, code2 = uint.MaxValue;
                byte[] newElement;
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    switch (encodingMode)
                    {
                        case 0:
                            code2 = reader.ReadByte();
                            break;
                        case 1:
                            code2 = reader.ReadUInt16();
                            break;
                        case 2:
                            code2 = reader.ReadUInt32();
                            break;
                    }

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
                        deCompressed.Add(dictionary[code1]);
                    }

                    code1 = code2;

                    if (dictionary.Count() > maxValues[encodingMode])
                    {
                        encodingMode++;
                    }
                }

                deCompressed.Add(dictionary[code2]);
            }

            reader.Close();

            var fileName = Path.GetFileName(path);
            var newFileName = fileName[0..(fileName.Length - 7)];
            var outputPath = Path.Combine(Path.GetDirectoryName(path)!, newFileName);

            using var writer = new BinaryWriter(File.Open(outputPath, FileMode.Create));
            foreach (byte[] code in deCompressed)
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
            string data;
            try
            {
                data = File.ReadAllText(path);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"Processing failed: {exception.Message}");
                return -1;
            }

            (string, int) dataBWT = BWT.Encode(data);
            string stringBWT = dataBWT.Item1 + " " + Convert.ToString(dataBWT.Item2);
            byte[] bytes = Encoding.Default.GetBytes(stringBWT);

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
                int encodingMode = 0;
                var maxValues = new uint[3] { byte.MaxValue, ushort.MaxValue, uint.MaxValue };
                int currentStart = 0;
                Trie trie = new Trie();
                trie.AddAlphabet();
                long bytesSpent = 0;
                uint indexOfWord = 0;

                var writer = new BinaryWriter(File.Open(path + ".zipped", FileMode.Create));
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
}
