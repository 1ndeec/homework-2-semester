// <copyright file="PriorityQueue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

/// <summary>
/// class for priority queues.
/// </summary>
public class PriorityQueue
{
    private Element[] heap;
    private int size;
    private int capacity;
    private long globalOrder = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="PriorityQueue"/> class.
    /// </summary>
    /// <param name="initialCapacity"> queue`s start capacity.</param>
    public PriorityQueue(int initialCapacity)
    {
        this.capacity = initialCapacity;
        this.heap = new Element[this.capacity];
        this.size = 0;
    }

    /// <summary>
    /// checks if queue is empty.
    /// </summary>
    /// <returns> true if empty, false if not. </returns>
    public bool IsEmpty()
    {
        if (this.size == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// adds new element in queue.
    /// </summary>
    /// <param name="value"> element`s value. </param>
    /// <param name="priority"> element`s priority. </param>
    public void Enqueue(string value, int priority)
    {
        if (this.size == this.capacity)
        {
            this.Resize();
        }

        this.heap[this.size] = new Element(value, priority, this.globalOrder);
        int current = this.size;
        this.size++;
        this.globalOrder++;

        while (current > 0 && this.heap[current].Priority > this.heap[this.Parent(current)].Priority)
        {
            this.Swap(current, this.Parent(current));
            current = this.Parent(current);
        }
    }

    /// <summary>
    /// grabbing our element with highest priority.
    /// </summary>
    /// <returns> value of element with highest priority. </returns>
    /// <exception cref="InvalidOperationException"> throws exception in case if deque is empty. </exception>
    public string Dequeue()
    {
        if (this.IsEmpty())
            throw new InvalidOperationException("Priority queue is empty.");

        string result = this.heap[0].Value;
        this.heap[0] = this.heap[this.size - 1];
        this.size--;

        this.HeapSort(0);
        return result;
    }

    /// <summary>
    /// sorts the heap on which our queue works.
    /// </summary>
    /// <param name="i"> index of current element. </param>
    private void HeapSort(int i)
    {
        int smallest = i;
        int left = this.LeftChild(i);
        int right = this.RightChild(i);

        if (left < this.size && this.Compare(this.heap[left], this.heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < this.size && this.Compare(this.heap[right], this.heap[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != i)
        {
            this.Swap(i, smallest);
            this.HeapSort(smallest);
        }
    }

    private int Compare(Element a, Element b)
    {
        if (a.Priority != b.Priority)
        {
            return a.Priority.CompareTo(b.Priority);
        }

        return a.Order.CompareTo(b.Order);
    }

    private void Swap(int i, int j)
    {
        Element temp = this.heap[i];
        this.heap[i] = this.heap[j];
        this.heap[j] = temp;
    }

    private void Resize()
    {
        this.capacity *= 2;
        Element[] newHeap = new Element[this.capacity];
        for (int i = 0; i < this.size; i++)
        {
            newHeap[i] = this.heap[i];
        }

        this.heap = newHeap;
    }

    private int Parent(int i)
    {
        return (i - 1) / 2;
    }

    private int LeftChild(int i)
    {
        return (2 * i) + 1;
    }

    private int RightChild(int i)
    {
        return (2 * i) + 2;
    }

    /// <summary>
    /// struct for our queue`s elements.
    /// </summary>
    private struct Element
    {
        public string Value;
        public int Priority;
        public long Order;

        public Element(string value, int priority, long order)
        {
            this.Value = value;
            this.Priority = priority;
            this.Order = order;
        }
    }
}
