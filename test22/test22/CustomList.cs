// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test22;

using System.Collections;

/// <summary>
/// Generic array-based list implementation.
/// </summary>
/// <typeparam name="T">Type of list elements.</typeparam>
public class CustomList<T>
{
    private const int DefaultCapacity = 4;
    private static readonly T[] EmptyArray = Array.Empty<T>();

    private T[] items;
    private int size;
    private int version;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomList{T}"/> class.
    /// </summary>
    public CustomList()
    {
        this.items = EmptyArray;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomList{T}"/> class with start capacity.
    /// </summary>
    /// <param name="capacity">Initial list capacity.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when capacity is negative.</exception>
    public CustomList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative");
        }

        this.items = capacity == 0 ? EmptyArray : new T[capacity];
    }

    /// <summary>
    /// Gets the number of elements in the list.
    /// </summary>
    public int Count => this.size;

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">Element index.</param>
    /// <returns>The element at specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when index is out of range.</exception>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            return this.items[index];
        }

        set
        {
            if (index < 0 || index >= this.size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            this.items[index] = value;
            this.version++;
        }
    }

    /// <summary>
    /// Adds an element to the end of the list.
    /// </summary>
    /// <param name="item">Element to add.</param>
    public void Add(T item)
    {
        if (this.size == this.items.Length)
        {
            this.EnsureCapacity(this.size + 1);
        }

        this.items[this.size++] = item;
        this.version++;
    }

    private void EnsureCapacity(int min)
    {
        if (this.items.Length < min)
        {
            int newCapacity = this.items.Length == 0 ? DefaultCapacity : this.items.Length * 2;
            if ((uint)newCapacity > Array.MaxLength)
            {
                newCapacity = Array.MaxLength;
            }

            if (newCapacity < min)
            {
                newCapacity = min;
            }

            Array.Resize(ref this.items, newCapacity);
        }
    }
}