// <copyright file="Trie.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Hw2
{
    /// <summary>
    /// class for trie data structure.
    /// </summary>
    public class Trie
    {
        private const int AlphabetSize = 26;

        private Vertex head;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie"/> class.
        /// </summary>
        public Trie()
        {
            this.Size = 0;
            this.head = new Vertex(false);
        }

        /// <summary>
        /// Gets the number of vertexes in trie (without head vertex).
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Adds new element in trie.
        /// </summary>
        /// <param name="element"> input element. </param>
        /// <returns> true if there was no such element before, false if there was one. </returns>
        public bool Add(string element)
        {
            if (this.Contains(element))
            {
                return false;
            }

            int length = element.Length;
            Vertex currentVertex = this.head;
            for (int i = 0; i < length; i++)
            {
                if (!currentVertex.IsThereInNext(element[i]))
                {
                    currentVertex.SetInNext(element[i]);
                    this.Size++;
                }

                currentVertex.HowManyEnds++; // every prefix gets one more element which starts from it
                currentVertex = currentVertex.GetFromNext(element[i]);
            }

            currentVertex.HowManyEnds++;
            currentVertex.IsTerminal = true;
            return true;
        }

        /// <summary>
        /// checks if trie contains specified element.
        /// </summary>
        /// <param name="element"> specified element. </param>
        /// <returns> true if contains, false if does not. </returns>
        public bool Contains(string element)
        {
            int length = element.Length;
            Vertex currentVertex = this.head;
            for (int i = 0; i < length; i++)
            {
                if (element[i] - 'a' >= AlphabetSize || element[i] - 'a' < 0)
                {
                    throw new ArgumentException("trie can nor contain such vertex");
                }

                if (!currentVertex.IsThereInNext(element[i]))
                {
                    return false;
                }

                currentVertex = currentVertex.GetFromNext(element[i]);
            }

            return currentVertex.IsTerminal;
        }

        /// <summary>
        /// removes specified element from trie.
        /// </summary>
        /// <param name="element"> specified element. </param>
        /// <returns> true if such element was deleted, false if there was no such element. </returns>
        public bool Remove(string element)
        {
            int length = element.Length;
            Vertex currentVertex = this.head;
            for (int i = 0; i < length; i++)
            {
                if (element[i] - 'a' >= AlphabetSize || element[i] - 'a' < 0)
                {
                    throw new ArgumentException("trie can not contain such vertex");
                }

                if (!currentVertex.IsThereInNext(element[i]))
                {
                    return false;
                }

                currentVertex = currentVertex.GetFromNext(element[i]);
            }

            bool tempIsTerminal = currentVertex.IsTerminal;

            currentVertex.IsTerminal = false;

            currentVertex = this.head;
            for (int i = 0; i < length; i++) // running one more time to decrease every prefix`s HowManyEnds by one
            {
                currentVertex.HowManyEnds--;
                currentVertex = currentVertex.GetFromNext(element[i]);
            }

            currentVertex.HowManyEnds--;

            return tempIsTerminal;
        }

        /// <summary>
        /// counting how many elements in trie starts with specified prefix.
        /// </summary>
        /// <param name="prefix"> specified prefix. </param>
        /// <returns> number of elements in trie which starts with given prefix. </returns>
        /// <exception cref="ArgumentException"> if there is no such prefix in trie. </exception>
        public int HowManyStartsWithPrefix(string prefix)
        {
            int length = prefix.Length;
            Vertex currentVertex = this.head;
            for (int i = 0; i < length; i++)
            {
                if (prefix[i] - 'a' >= AlphabetSize || prefix[i] - 'a' < 0)
                {
                    throw new ArgumentException("trie can nor contain such vertex");
                }

                if (!currentVertex.IsThereInNext(prefix[i]))
                {
                    throw new ArgumentException("no such prefix in trie");
                }

                currentVertex = currentVertex.GetFromNext(prefix[i]);
            }

            return currentVertex.HowManyEnds;
        }

        /// <summary>
        /// class for vertexes in trie.
        /// </summary>
        public class Vertex
        {
            private Vertex[] next; // array of vertexes in which you can go from this vertex

            /// <summary>
            /// Initializes a new instance of the <see cref="Vertex"/> class.
            /// </summary>
            /// <param name="isTerminal"> a value indicating whether this vertex is terminal or not. </param>
            public Vertex(bool isTerminal)
            {
                this.IsTerminal = isTerminal;
                this.next = new Vertex[AlphabetSize];
                this.HowManyEnds = 0;
            }

            /// <summary>
            /// Gets or sets a value of how many elements in trie contains this vertex.
            /// </summary>
            public int HowManyEnds { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this vertex is terminal or not.
            /// </summary>
            public bool IsTerminal { get; set; }

            /// <summary>
            /// checks if you can go from this vertex to other specified vertex.
            /// </summary>
            /// <param name="letter"> name of specified vertex. </param>
            /// <returns> true if you cam, false if you cant. </returns>
            /// <exception cref="IndexOutOfRangeException"> if trie cant contain such vertex. </exception>
            public bool IsThereInNext(char letter)
            {
                if (letter - 'a' >= AlphabetSize || letter - 'a' < 0)
                {
                    throw new ArgumentException("trie cant contain such vertex");
                }

                return this.next[letter - 'a'] == null ? false : true;
            }

            /// <summary>
            /// sets an ability of passing from this vertex to other specified vertex.
            /// </summary>
            /// <param name="letter"> name of specified vertex. </param>
            /// <exception cref="IndexOutOfRangeException"> if trie cant contain such vertex. </exception>
            public void SetInNext(char letter)
            {
                if (letter - 'a' >= AlphabetSize || letter - 'a' < 0)
                {
                    throw new ArgumentException("trie cant contain such vertex");
                }

                this.next[letter - 'a'] = new Vertex(false);
            }

            /// <summary>
            /// returns specified vertex if there is an ability of passing from this vertex to other specified vertex.
            /// </summary>
            /// <param name="letter"> name of specified vertex. </param>
            /// <returns> specified vertex. </returns>
            /// <exception cref="IndexOutOfRangeException"> if trie cant contain such vertex. </exception>
            public Vertex GetFromNext(char letter)
            {
                if (letter - 'a' >= AlphabetSize || letter - 'a' < 0)
                {
                    throw new ArgumentException("trie cant contain such vertex");
                }

                return this.next[letter - 'a'];
            }
        }
    }
}

