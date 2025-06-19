// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7.Test;

using Hw7;

/// <summary>
/// Test class for Logic Class.
/// </summary>
[TestClass]
public sealed class LogicTest
{
    private Logic logic = new Logic();

    /// <summary>
    /// Initializes Logic element.
    /// </summary>
    [TestInitialize]
    public void InitializeLogic()
    {
        this.logic = new Logic();
    }

    /// <summary>
    /// Tests Clear method of Logic.
    /// </summary>
    [TestMethod]
    public void TestInsertValueAndClear()
    {
        this.logic.InsertValue("1");
        Assert.AreEqual(this.logic.Record, "1");
        this.logic.InsertValue("2");
        Assert.AreEqual(this.logic.Record, "12");
        this.logic.TryCompute("+");
        Assert.AreEqual(this.logic.Record, "12 + ");
        this.logic.InsertValue("1");
        Assert.AreEqual(this.logic.Record, "12 + 1");
        this.logic.InsertValue("2");
        Assert.AreEqual(this.logic.Record, "12 + 12");
        this.logic.TryCompute("+");
        Assert.AreEqual(this.logic.Record, "24 + ");
        this.logic.Clear();
        Assert.AreEqual(this.logic.Record, string.Empty);
    }

    /// <summary>
    /// Tests InsertValue method of Logic.
    /// </summary>
    [TestMethod]
    public void TestZeroDivision()
    {
        this.logic.InsertValue("1");
        Assert.AreEqual(this.logic.Record, "1");
        this.logic.InsertValue("2");
        Assert.AreEqual(this.logic.Record, "12");
        this.logic.TryCompute("+");
        Assert.AreEqual(this.logic.Record, "12 + ");
        this.logic.InsertValue("1");
        Assert.AreEqual(this.logic.Record, "12 + 1");
        this.logic.InsertValue("2");
        Assert.AreEqual(this.logic.Record, "12 + 12");

        this.logic.TryCompute("/");
        Assert.AreEqual(this.logic.Record, "24 / ");
        this.logic.InsertValue("0");
        this.logic.TryCompute("/");
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");
        this.logic.InsertValue("1");

        // nothing happens
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");
        this.logic.TryCompute("+");

        // nothing happens
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");
        this.logic.Delete();

        // nothing happens
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");

        this.logic.Clear();
        Assert.AreEqual(this.logic.Record, string.Empty);
    }

    /// <summary>
    /// Tests TryCompute method of Logic.
    /// </summary>
    [TestMethod]
    public void TestTryCompute()
    {
        this.logic.TryCompute("+");

        // nothing happens
        Assert.AreEqual(this.logic.Record, string.Empty);
        this.logic.InsertValue("2");
        this.logic.InsertValue("4");
        this.logic.TryCompute("+");
        Assert.AreEqual(this.logic.Record, "24 + ");
        this.logic.TryCompute("-");

        // safe operator switching
        Assert.AreEqual(this.logic.Record, "24 - ");
        this.logic.InsertValue("1");
        this.logic.InsertValue("2");
        this.logic.TryCompute("+");
        Assert.AreEqual(this.logic.Record, "12 + ");
        this.logic.TryCompute("/");
        this.logic.InsertValue("0");
        this.logic.TryCompute("+");
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");
    }

    /// <summary>
    /// Tests Delete method of Logic.
    /// </summary>
    [TestMethod]
    public void TestDelete()
    {
        this.logic.Delete();
        Assert.AreEqual(this.logic.Record, string.Empty); // nothing happens
        this.logic.InsertValue("2");
        this.logic.InsertValue("4");
        this.logic.TryCompute("+");
        this.logic.Delete();
        this.logic.TryCompute("-");

        // safe operator deleting
        Assert.AreEqual(this.logic.Record, "24 - ");
        this.logic.InsertValue("1");
        this.logic.InsertValue("2");
        this.logic.TryCompute("+");

        // safe operator deleting second part of the proof
        Assert.AreEqual(this.logic.Record, "12 + ");
        this.logic.TryCompute("/");
        this.logic.InsertValue("0");
        this.logic.TryCompute("/");
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");
        this.logic.Delete();

        // nothing happens
        Assert.AreEqual(this.logic.Record, "Calculation Error, 0 division");
    }
}
