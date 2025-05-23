// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test2;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// provides a simple realization of list data structure.
/// </summary>
/// <typeparam name="T"> Type of elements in the list. </typeparam>
public class CustomList<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private T[] items;
    private int count;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomList{T}"/> class.
    /// </summary>
    public CustomList()
    {
        this.items = new T[DefaultCapacity];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomList{T}"/> class.
    /// </summary>
    /// <param name="capacity"> Capacity of the list. </param>
    public CustomList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be negative.");
        }

        this.items = new T[capacity];
    }

    /// <summary>
    /// Adds new elements in the end of the list.
    /// </summary>
    /// <param name="item"> Element to add. </param>
    public void Add(T item)
    {
        if (this.count == this.items.Length)
        {
            this.EnsureCapacity();
        }

        this.items[this.count++] = item;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.count; i++)
        {
            yield return this.items[i];
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void EnsureCapacity()
    {
        int newCapacity = this.items.Length == 0 ? DefaultCapacity : this.items.Length * 2;
        T[] newItems = new T[newCapacity];
        Array.Copy(this.items, newItems, this.count);
        this.items = newItems;
    }
}
