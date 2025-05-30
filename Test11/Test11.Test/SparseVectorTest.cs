// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test11.Test;

using Test11;

/// <summary>
/// Unit tests for the SparseVector class functionality.
/// </summary>
[TestClass]
public sealed class SparseVectorTest
{
    /// <summary>
    /// Tests vector construction and element access through indexer
    /// Verifies that non-zero values are stored and zero values are handled correctly.
    /// </summary>
    [TestMethod]
    public void TestSparseVectorConstructingAndIndexationMethod()
    {
        var vector = new SparseVector(6);
        vector[0] = 1.5;
        vector[1] = 2.5;
        vector[2] = 3.5;
        vector[3] = 0;
        vector[4] = 0;
        vector[5] = 0;

        // Verify non-zero values are stored correctly
        for (int i = 0; i < 3; i++)
        {
            Assert.AreEqual(vector[i], i + 1.5);
        }

        // Verify zero values are returned correctly
        for (int i = 3; i < 6; i++)
        {
            Assert.AreEqual(vector[i], 0);
        }
    }

    /// <summary>
    /// Tests indexation.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void TestSparseVectorIndexationMethod()
    {
        var vector = new SparseVector(6);
        vector[7] = 2.5;
    }

    /// <summary>
    /// Tests that constructor throws exception for invalid negative dimension.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSparseVectorConstructingExceptionMethod()
    {
        var vector = new SparseVector(-6);
    }

    /// <summary>
    /// Tests vector addition operation
    /// Verifies that corresponding elements are added correctly.
    /// </summary>
    [TestMethod]
    public void TestSparseVectorAddMethod()
    {
        var vector1 = new SparseVector(6);
        vector1[0] = 1;
        vector1[1] = 2;
        vector1[2] = 3;

        var vector2 = new SparseVector(6);
        vector2[0] = 1;
        vector2[1] = 2;
        vector2[2] = 3;
        vector2[3] = 8;

        vector1 = vector1.Add(vector2);

        // Verify addition of corresponding elements
        for (int i = 0; i < 4; i++)
        {
            Assert.AreEqual(vector1[i], (i + 1) * 2);
        }

        // Verify remaining elements are zero
        for (int i = 4; i < 6; i++)
        {
            Assert.AreEqual(vector1[i], 0);
        }
    }

    /// <summary>
    /// Tests that addition throws exception for vectors of different dimensions.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSparseVectorAddExceptionMethod()
    {
        var vector1 = new SparseVector(6);
        var vector2 = new SparseVector(5);
        vector1 = vector1.Add(vector2);
    }

    /// <summary>
    /// Tests vector subtraction operation
    /// Verifies that corresponding elements are subtracted correctly.
    /// </summary>
    [TestMethod]
    public void TestSparseVectorSubstractMethod()
    {
        var vector1 = new SparseVector(6);
        vector1[0] = 1;
        vector1[1] = 2;
        vector1[2] = 3;

        var vector2 = new SparseVector(6);
        vector2[0] = 1;
        vector2[1] = 2;
        vector2[2] = 3;
        vector2[5] = 8;

        vector1 = vector1.Subtract(vector2);

        // Verify subtraction of corresponding elements
        for (int i = 0; i < 5; i++)
        {
            Assert.AreEqual(vector1[i], 0);
        }

        // Verify subtraction of non-corresponding element
        Assert.AreEqual(vector1[5], -8);
    }

    /// <summary>
    /// Tests that subtraction throws exception for vectors of different dimensions.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSparseVectorSubstractExceptionMethod()
    {
        var vector1 = new SparseVector(6);
        var vector2 = new SparseVector(5);
        vector1 = vector1.Subtract(vector2);
    }

    /// <summary>
    /// Tests dot product calculation
    /// Verifies correct computation of the sum of element-wise products.
    /// </summary>
    [TestMethod]
    public void TestSparseVectorDotProductMethod()
    {
        var vector1 = new SparseVector(6);
        vector1[0] = 1;
        vector1[1] = 2;
        vector1[2] = 3;

        var vector2 = new SparseVector(6);
        vector2[0] = 1;
        vector2[1] = 2;
        vector2[2] = 3;
        vector2[3] = 4;
        vector2[4] = 5;

        double dotProductResult = vector1.DotProduct(vector2);

        // Verify correct dot product calculation (1*1 + 2*2 + 3*3 + 0*4 + 0*5 + 0*0)
        Assert.AreEqual(dotProductResult, 14);
    }

    /// <summary>
    /// Tests that dot product throws exception for vectors of different dimensions.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSparseVectorDotProductExceptionMethod()
    {
        var vector1 = new SparseVector(6);
        var vector2 = new SparseVector(5);
        double dotProductResult = vector1.DotProduct(vector2);
    }

    /// <summary>
    /// Tests IsZero property
    /// Verifies correct detection of zero vectors (all elements zero).
    /// </summary>
    [TestMethod]
    public void TestSparseVectorIsZeroMethod()
    {
        // Test explicit zero vector
        var vector1 = new SparseVector(6);
        Assert.IsTrue(vector1.IsZero);

        // Test vector with all zeros set explicitly
        vector1[0] = 0;
        vector1[1] = 0;
        vector1[2] = 0;
        vector1[3] = 0;
        vector1[4] = 0;
        vector1[5] = 0;
        Assert.IsTrue(vector1.IsZero);

        // Test non-zero vector
        var vector2 = new SparseVector(6);
        vector2[0] = 1;
        Assert.IsFalse(vector2.IsZero);

        // Test newly created vector (should be zero by default)
        var vector3 = new SparseVector(6);
        Assert.IsTrue(vector3.IsZero);
    }
}
