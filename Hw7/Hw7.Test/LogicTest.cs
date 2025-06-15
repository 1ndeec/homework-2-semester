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
    /// <summary>
    /// Tests Clear method of Logic.
    /// </summary>
    [TestMethod]
    public void TestInsertValueAndClear()
    {
        var logic = new Logic();

        logic.InsertValue("1");
        Assert.AreEqual(logic.Record, "1");
        logic.InsertValue("2");
        Assert.AreEqual(logic.Record, "12");
        logic.TryCompute("+");
        Assert.AreEqual(logic.Record, "12 + ");
        logic.InsertValue("1");
        Assert.AreEqual(logic.Record, "12 + 1");
        logic.InsertValue("2");
        Assert.AreEqual(logic.Record, "12 + 12");
        logic.TryCompute("+");
        Assert.AreEqual(logic.Record, "24 + ");
        logic.Clear();
        Assert.AreEqual(logic.Record, string.Empty);
    }

    /// <summary>
    /// Tests InsertValue method of Logic.
    /// </summary>
    [TestMethod]
    public void TestZeroDivision()
    {
        var logic = new Logic();

        logic.InsertValue("1");
        Assert.AreEqual(logic.Record, "1");
        logic.InsertValue("2");
        Assert.AreEqual(logic.Record, "12");
        logic.TryCompute("+");
        Assert.AreEqual(logic.Record, "12 + ");
        logic.InsertValue("1");
        Assert.AreEqual(logic.Record, "12 + 1");
        logic.InsertValue("2");
        Assert.AreEqual(logic.Record, "12 + 12");

        logic.TryCompute("/");
        Assert.AreEqual(logic.Record, "24 / ");
        logic.InsertValue("0");
        logic.TryCompute("/");
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.InsertValue("1");

        // nothing happens
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.TryCompute("+");

        // nothing happens
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.Delete();

        // nothing happens
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");

        logic.Clear();
        Assert.AreEqual(logic.Record, string.Empty);
    }

    /// <summary>
    /// Tests TryCompute method of Logic.
    /// </summary>
    [TestMethod]
    public void TestTryCompute()
    {
        var logic = new Logic();
        logic.TryCompute("+");

        // nothing happens
        Assert.AreEqual(logic.Record, string.Empty);
        logic.InsertValue("2");
        logic.InsertValue("4");
        logic.TryCompute("+");
        Assert.AreEqual(logic.Record, "24 + ");
        logic.TryCompute("-");

        // safe operator switching
        Assert.AreEqual(logic.Record, "24 - ");
        logic.InsertValue("1");
        logic.InsertValue("2");
        logic.TryCompute("+");
        Assert.AreEqual(logic.Record, "12 + ");
        logic.TryCompute("/");
        logic.InsertValue("0");
        logic.TryCompute("+");
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
    }

    /// <summary>
    /// Tests Delete method of Logic.
    /// </summary>
    [TestMethod]
    public void TestDelete()
    {
        var logic = new Logic();
        logic.Delete();
        Assert.AreEqual(logic.Record, string.Empty); // nothing happens
        logic.InsertValue("2");
        logic.InsertValue("4");
        logic.TryCompute("+");
        logic.Delete();
        logic.TryCompute("-");

        // safe operator deleting
        Assert.AreEqual(logic.Record, "24 - ");
        logic.InsertValue("1");
        logic.InsertValue("2");
        logic.TryCompute("+");

        // safe operator deleting second part of the proof
        Assert.AreEqual(logic.Record, "12 + ");
        logic.TryCompute("/");
        logic.InsertValue("0");
        logic.TryCompute("/");
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.Delete();

        // nothing happens
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
    }
}
