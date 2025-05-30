// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test11;

/// <summary>
/// Represents a sparse vector that efficiently stores only non-zero elements.
/// </summary>
public class SparseVector
{
    // Dictionary stores only non-zero elements (index -> value)
    private readonly Dictionary<int, double> elements;
    private readonly int dimension;

    /// <summary>
    /// Initializes a new instance of the <see cref="SparseVector"/> class.
    /// </summary>
    /// <param name="dimension">Vector dimension (must be positive).</param>
    /// <exception cref="ArgumentException">Thrown when dimension is not positive.</exception>
    public SparseVector(int dimension)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException("Vector dimension must be positive", nameof(dimension));
        }

        this.dimension = dimension;
        this.elements = new Dictionary<int, double>();
    }

    /// <summary>
    /// Gets the vector dimension.
    /// </summary>
    public int Dimension => this.dimension;

    /// <summary>
    /// Gets a value indicating whether the vector is a zero vector (all elements are 0).
    /// </summary>
    public bool IsZero => this.elements.Count == 0;

    /// <summary>
    /// Indexer for vector elements (returns 0 for non-stored indices).
    /// </summary>
    /// <param name="index">Element index (0-based).</param>
    /// <exception cref="IndexOutOfRangeException">Thrown when index is out of bounds.</exception>
    public double this[int index]
    {
        get
        {
            this.CheckIndex(index);
            return this.elements.TryGetValue(index, out double value) ? value : 0.0;
        }

        set
        {
            this.CheckIndex(index);
            if (value != 0.0)
            {
                this.elements[index] = value;
            }
            else
            {
                this.elements.Remove(index);
            }
        }
    }

    /// <summary>
    /// Adds another vector to this vector.
    /// </summary>
    /// <param name="other">Vector to add.</param>
    /// <returns>New vector containing the sum.</returns>
    /// <exception cref="ArgumentNullException">Thrown when other vector is null.</exception>
    /// <exception cref="ArgumentException">Thrown when dimensions don't match.</exception>
    public SparseVector Add(SparseVector other)
    {
        this.CheckDimensions(other);

        var result = new SparseVector(this.dimension);

        // Copy all non-zero elements from this vector
        foreach (var kvp in this.elements)
        {
            result[kvp.Key] = kvp.Value;
        }

        // Add elements from the other vector
        foreach (var kvp in other.elements)
        {
            result[kvp.Key] += kvp.Value;
        }

        return result;
    }

    /// <summary>
    /// Subtracts another vector from this vector.
    /// </summary>
    /// <param name="other">Vector to subtract.</param>
    /// <returns>New vector containing the difference.</returns>
    public SparseVector Subtract(SparseVector other)
    {
        this.CheckDimensions(other);

        var result = new SparseVector(this.dimension);

        // Copy all non-zero elements from this vector
        foreach (var kvp in this.elements)
        {
            result[kvp.Key] = kvp.Value;
        }

        // Subtract elements from the other vector
        foreach (var kvp in other.elements)
        {
            result[kvp.Key] -= kvp.Value;
        }

        return result;
    }

    /// <summary>
    /// Computes dot product with another vector.
    /// </summary>
    /// <param name="other">Vector to multiply with.</param>
    /// <returns>Dot product value.</returns>
    public double DotProduct(SparseVector other)
    {
        this.CheckDimensions(other);

        double result = 0.0;

        // Optimization: iterate over the vector with fewer non-zero elements
        var smaller = this.elements.Count < other.elements.Count ? this.elements : other.elements;
        var larger = this.elements.Count < other.elements.Count ? other.elements : this.elements;

        foreach (var kvp in smaller)
        {
            if (larger.TryGetValue(kvp.Key, out double otherValue))
            {
                result += kvp.Value * otherValue;
            }
        }

        return result;
    }

    // Validates that index is within vector bounds
    private void CheckIndex(int index)
    {
        if (index < 0 || index >= this.dimension)
        {
            throw new IndexOutOfRangeException($"Index {index} is out of bounds for vector of dimension {this.dimension}");
        }
    }

    // Validates vectors have matching dimensions
    private void CheckDimensions(SparseVector other)
    {
        ArgumentNullException.ThrowIfNull(other);

        if (this.dimension != other.dimension)
        {
            throw new ArgumentException("Vectors must have matching dimensions");
        }
    }
}