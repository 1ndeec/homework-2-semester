// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw3
{
    /// <summary>
    /// class for trie data structure.
    /// </summary>
    public class Trie
    {
        private const byte AlphabetSize = 255;

        private Vertex head;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie"/> class.
        /// </summary>
        public Trie()
        {
            this.Size = 0;
            this.head = new Vertex();
            this.CurrentWord = 0;
        }

        /// <summary>
        /// Gets or sets number of word that will be added to trie next.
        /// </summary>
        public uint CurrentWord { get; set; }

        /// <summary>
        /// Gets the number of vertexes in trie (without head vertex).
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Adds new element in trie.
        /// </summary>
        /// <param name="element"> input element. </param>
        /// <returns> true if there was no such element before, false if there was one. </returns>
        public uint Add(byte[] element)
        {
            int length = element.Length;
            Vertex currentVertex = this.head;
            for (int i = 0; i < length; i++)
            {
                if (!currentVertex.IsThereInNext(element[i]))
                {
                    currentVertex.SetInNext(element[i]);
                    this.Size++;
                }

                currentVertex = currentVertex.GetFromNext(element[i]);
            }

            currentVertex.IndexOfWord = this.CurrentWord;
            this.CurrentWord++;
            return this.CurrentWord;
        }

        /// <summary>
        /// checks if trie contains specified element.
        /// </summary>
        /// <param name="element"> specified element. </param>
        /// <returns> true if contains, false if does not. </returns>
        public uint Contains(byte[] element)
        {
            int length = element.Length;
            Vertex currentVertex = this.head;
            for (int i = 0; i < length; i++)
            {
                if (!currentVertex.IsThereInNext(element[i]))
                {
                    return uint.MaxValue;
                }

                currentVertex = currentVertex.GetFromNext(element[i]);
            }

            return currentVertex.IndexOfWord;
        }

        /// <summary>
        /// Method for adding all utf-8 characters to trie.
        /// </summary>
        public void AddAlphabet()
        {
            for (ushort i = 0; i <= AlphabetSize; i++)
            {
                this.head.SetInNext((byte)i);
                this.head.GetFromNext((byte)i).IndexOfWord = this.CurrentWord;
                this.CurrentWord++;
            }
        }

        /// <summary>
        /// class for vertexes in trie.
        /// </summary>
        public class Vertex
        {
            private Dictionary<byte, Vertex> nextDictionary; // array of vertexes in which you can go from this vertex

            /// <summary>
            /// Initializes a new instance of the <see cref="Vertex"/> class.
            /// </summary>
            public Vertex()
            {
                this.nextDictionary = new Dictionary<byte, Vertex>();
            }

            /// <summary>
            /// Gets or sets the number of word whose endpoint is the given vertex.
            /// </summary>
            public uint IndexOfWord { get; set; }

            /// <summary>
            /// checks if you can go from this vertex to other specified vertex.
            /// </summary>
            /// <param name="nextElement"> next vertex to go into. </param>
            /// <returns> true if you cam, false if you cant. </returns>
            public bool IsThereInNext(byte nextElement)
            {
                return this.nextDictionary.ContainsKey(nextElement);
            }

            /// <summary>
            /// sets an ability of passing from this vertex to other specified vertex.
            /// </summary>
            /// <param name="nextElement"> next vertex to set an ability of passing to. </param>
            public void SetInNext(byte nextElement)
            {
                this.nextDictionary.Add(nextElement, new Vertex());
            }

            /// <summary>
            /// returns specified vertex if there is an ability of passing from our vertex to this specified vertex.
            /// </summary>
            /// <param name="nextElement"> specified vertex to check an ability of passing to. </param>
            /// <returns> specified vertex. </returns>
            public Vertex GetFromNext(byte nextElement)
            {
                return this.nextDictionary[nextElement];
            }
        }
    }
}
