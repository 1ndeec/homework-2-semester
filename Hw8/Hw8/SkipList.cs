// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw8;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security;

/// <summary>
/// Implementation of Skip List.
/// </summary>
/// <typeparam name="T">The type of elements stored in the skip list. Must implement IComparable&lt;T&gt; for ordering.</typeparam>
public class SkipList<T> : IList<T>
    where T : IComparable<T>
{
    private readonly int maxHeight = 16;
    private long version;
    private Node head;
    private Node tail;
    private Random random = new Random();

    /// <summary>
    /// Initializes a new instance of the <see cref="SkipList&lt;T&gt"/> class.
    /// </summary>
    public SkipList()
    {
        this.head = new Node();
        this.tail = new Node();
        this.Count = 0;
        this.version = 0;

        for (int i = 0; i < this.maxHeight; i++)
        {
            this.head.Next.Add(this.tail);
        }
    }

    /// <summary>
    /// Gets a number of elements in skip list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Gets a value indicating whether skip list is readonly.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Gets element on specifies index.
    /// </summary>
    /// <param name="index"> Index of element. </param>
    /// <returns> Value of element with given index. </returns>
    /// <exception cref="ArgumentOutOfRangeException"> index is not a valid index in the SkipList&lt;T&gt. </exception>
    /// <exception cref="NotSupportedException"> SkipList&lt;T&gt does not support setting values at specified indexes. </exception>
    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node currentNode = this.head;
            for (int i = 0; i <= index; i++)
            {
                currentNode = currentNode.Next[0];
            }

            return currentNode.Value;
        }

        set => throw new NotSupportedException();
    }

    /// <summary>
    /// Checks Whether SkipList&lt;T&gt contains given value.
    /// </summary>
    /// <param name="value"> Given value. </param>
    /// <returns> Whether SkipList&lt;T&gt contains given value. </returns>
    public bool Contains(T value)
    {
        Node currentNode = this.Find(value).CurrentNode;
        return currentNode.Value.Equals(value);
    }

    /// <summary>
    /// Adds new element to SkipList&lt;T&gt.
    /// </summary>
    /// <param name="value"> Value of an element to be added. </param>
    public void Add(T value)
    {
        this.version++;
        var found = this.Find(value);
        Node currentNode = found.CurrentNode;
        Node[] remember = found.Remember;

        if (!currentNode.Value.Equals(value))
        {
            this.Count++;
            var newNode = new Node();
            newNode.Value = value;
            newNode.Next.Add(remember[0].Next[0]);
            remember[0].Next[0] = newNode;

            for (int i = 1; this.random.Next() % 2 == 0 && i < this.maxHeight; i++)
            {
                newNode.Next.Add(remember[i].Next[i]);
                remember[i].Next[i] = newNode;
            }
        }
    }

    /// <summary>
    /// Removes an element from SkipList&lt;T&gt.
    /// </summary>
    /// <param name="value"> Value of an element to be removed.</param>
    /// <returns> Whether removal was successful. </returns>
    public bool Remove(T value)
    {
        this.version++;
        var found = this.Find(value);
        Node currentNode = found.CurrentNode;
        Node[] remember = found.Remember;

        if (currentNode.Value.Equals(value) && currentNode != this.head)
        {
            this.Count--;

            for (int i = 0; i < currentNode.Next.Count; i++)
            {
                remember[i].Next[i] = currentNode.Next[i];
            }

            return true;
        }

        return false;
    }

    /// <summary>
    /// Clears SkipList&lt;T&gt.
    /// </summary>
    public void Clear()
    {
        this.version++;
        this.head = new Node();
        this.Count = 0;
        this.tail = new Node();
        for (int i = 0; i < this.maxHeight; i++)
        {
            this.head.Next.Add(this.tail);
        }
    }

    /// <summary>
    /// Determines the index of a specific item in the SkipList&lt;T&gt.
    /// </summary>
    /// <param name="value"> the value of an item to locate in SkipList&lt;T&gt.</param>
    /// <returns> The index of item with given value in SkipList&lt;T&gt, or -1 if it was not found. </returns>
    public int IndexOf(T value)
    {
        Node currentNode = this.head.Next[0];
        int index = 0;
        while (currentNode != this.tail && !value.Equals(currentNode.Value))
        {
            index++;
            currentNode = currentNode.Next[0];
        }

        if (currentNode == this.tail)
        {
             return -1;
        }

        return index;
    }

    /// <summary>
    /// Returns a strongly-typed enumerator that iterates through the skip list.
    /// </summary>
    /// <returns> A IEnumerator object that can be used to iterate through the elements of the skip list. </returns>
    public SkipListEnum GetEnumerator() => new SkipListEnum(this);

    /// <summary>
    /// Returns an enumerator (generic) that iterates through a collection.
    /// </summary>
    /// <returns> An IEnumerator object that can be used to iterate through the collection. </returns>
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => this.GetEnumerator();

    /// <summary>
    /// Returns an enumerator (non-generic) that iterates through a collection.
    /// </summary>
    /// <returns> An IEnumerator object that can be used to iterate through the collection. </returns>
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

    /// <summary>
    /// Throws a NotSupportedException because inserting by index is not supported in SkipList&lt;T&gt;.
    /// </summary>
    /// <param name="index">The index at which to insert the item. Not used.</param>
    /// <param name="value">The item to insert. Not used.</param>
    /// <exception cref="NotSupportedException"> SkipList&lt;T&gt does not support index inserting. </exception>
    public void Insert(int index, T value) => throw new NotSupportedException();

    /// <summary>
    /// Copies the elements of the SkipList&lt;T&gt; to an Array, starting at a particular Array index.
    /// </summary>
    /// <param name="array"> The one-dimensional Array that is the destination of the elements copied from SkipList&lt;T&gt;. The Array must have zero-based indexing. </param>
    /// <param name="arrayIndex"> The zero-based index in array at which copying begins. </param>
    /// <exception cref="ArgumentNullException"> array is null. </exception>
    /// <exception cref="ArgumentOutOfRangeException"> arrayIndex is less than 0. </exception>
    /// <exception cref="ArgumentException"> The number of elements in the source SkipList&lt;T&gt; is greater than the available space from arrayIndex to the end of the destination array. </exception>
    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);

        ArgumentOutOfRangeException.ThrowIfLessThan(arrayIndex, 0);

        if (array.Length - arrayIndex - this.Count < 0)
        {
            throw new ArgumentException();
        }

        Node current = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            current = current.Next[0];
            array[i + arrayIndex] = current.Value;
        }
    }

    /// <summary>
    /// Removes element on specifies index.
    /// </summary>
    /// <param name="index"> Index of element to be removed.</param>
    public void RemoveAt(int index)
    {
        this.version++;
        T value = this[index];
        this.Remove(value);
    }

    private (Node CurrentNode, Node[] Remember) Find(T value)
    {
        int currentHeight = this.maxHeight;
        Node currentNode = this.head;
        var remember = new Node[this.maxHeight];
        while (true)
        {
            if (currentHeight == 0)
            {
                if (currentNode.Next[0] == this.tail || this.IsMore(currentNode.Next[0].Value, value))
                {
                    return (currentNode, remember);
                }
                else if (value.Equals(currentNode.Next[0].Value))
                {
                    return (currentNode.Next[0], remember);
                }
            }

            for (currentHeight = currentNode.Next.Count - 1; currentHeight >= 0; currentHeight--)
            {
                if (currentNode.Next[currentHeight] != this.tail && this.IsMore(value, currentNode.Next[currentHeight].Value))
                {
                    currentNode = currentNode.Next[currentHeight];
                    remember[currentHeight] = currentNode;
                    break;
                }

                remember[currentHeight] = currentNode;
            }

            currentHeight = currentHeight == -1 ? 0 : currentHeight;
        }
    }

    private bool IsMoreOrEqual(T value1, T value2) => value1.CompareTo(value2) >= 0;

    private bool IsMore(T value1, T value2) => value1.CompareTo(value2) > 0;

    /// <summary>
    /// Enumerator for traversing elements in a SkipList&lt;T&gt;.
    /// </summary>
    public class SkipListEnum : IEnumerator<T>
    {
        private readonly long initialVersion;
        private SkipList<T> skipList;
        private Node current;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkipListEnum"/> class for the specified skip list.
        /// </summary>
        /// <param name="skipList">The skip list to enumerate.</param>
        public SkipListEnum(SkipList<T> skipList)
        {
            this.skipList = skipList;
            this.current = skipList.head;
            this.initialVersion = skipList.version;
        }

        /// <summary>
        /// Gets the element in the skip list at the current position of the enumerator.
        /// </summary>
        public T Current => this.current.Value;

        /// <summary>
        /// Gets the current element in the skip list (non-generic implementation).
        /// </summary>
        object IEnumerator.Current => this.Current;

        /// <summary>
        /// Advances the enumerator to the next element of the skip list.
        /// </summary>
        /// <returns><c>true</c> if the enumerator was successfully advanced to the next element; <c>false</c> if the end of the collection has been reached.</returns>
        public bool MoveNext()
        {
            if (this.initialVersion != this.skipList.version)
            {
                throw new InvalidOperationException("Collection was modified during enumeration.");
            }

            if (this.current.Next[0] != this.skipList.tail)
            {
                this.current = this.current.Next[0];
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the skip list.
        /// </summary>
        public void Reset()
        {
            this.current = this.skipList.head;
        }

        /// <summary>
        /// Releases all resources used by the <see cref="SkipListEnum"/>.
        /// </summary>
        public void Dispose()
        {
        }
    }

    private class Node
    {
        public Node()
        {
            this.Next = new List<Node>();
        }

        public List<Node> Next { get; set; }

        public T Value { get; set; } = default!;
    }
}