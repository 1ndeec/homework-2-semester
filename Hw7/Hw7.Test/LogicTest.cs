// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7.Test;

using System.Reflection;
using System.Windows.Forms;
using Hw7;

/// <summary>
/// Test class for Logic Class.
/// </summary>
[TestClass]
public sealed class LogicTest
{
    private FieldInfo value1 = typeof(Logic).GetField("value1", BindingFlags.NonPublic | BindingFlags.Instance)!; // checking private fields
    private FieldInfo value2 = typeof(Logic).GetField("value2", BindingFlags.NonPublic | BindingFlags.Instance)!; // checking private fields
    private FieldInfo calcOperator = typeof(Logic).GetField("calcOperator", BindingFlags.NonPublic | BindingFlags.Instance)!; // checking private fields
    private FieldInfo currentValue = typeof(Logic).GetField("currentValue", BindingFlags.NonPublic | BindingFlags.Instance)!; // checking private fields
    private FieldInfo isThereValue = typeof(Logic).GetField("isThereValue", BindingFlags.NonPublic | BindingFlags.Instance)!; // checking private fields

    /// <summary>
    /// Tests Clear method of Logic.
    /// </summary>
    [TestMethod]
    public void TestClear()
    {
        Logic logic = new Logic();
        logic.InsertValue(new Button(), new ButtonArgs("1"));
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        logic.InsertValue(new Button(), new ButtonArgs("1"));
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        logic.Clear(new Button(), new ButtonArgs("C"));

        Assert.AreEqual(logic.Record, string.Empty);
        Assert.AreEqual(this.value1!.GetValue(logic), string.Empty);
        Assert.AreEqual(this.value2!.GetValue(logic), string.Empty);
        Assert.AreEqual(this.calcOperator!.GetValue(logic), string.Empty);
        Assert.AreEqual(this.currentValue!.GetValue(logic), false);
        Assert.AreEqual(this.isThereValue!.GetValue(logic), false);
    }

    /// <summary>
    /// Tests InsertValue method of Logic.
    /// </summary>
    [TestMethod]
    public void TestInsertValue()
    {
        Logic logic = new Logic();

        logic.InsertValue(new Button(), new ButtonArgs("1"));
        Assert.AreEqual(logic.Record, "1");
        Assert.AreEqual(this.value1!.GetValue(logic), "1");
        Assert.AreEqual(this.isThereValue!.GetValue(logic), true);
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        Assert.AreEqual(logic.Record, "12");
        Assert.AreEqual(this.value1!.GetValue(logic), "12");
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        Assert.AreEqual(logic.Record, "12 + ");
        logic.InsertValue(new Button(), new ButtonArgs("1"));
        Assert.AreEqual(logic.Record, "12 + 1");
        Assert.AreEqual(this.value2!.GetValue(logic), "1");
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        Assert.AreEqual(logic.Record, "12 + 12");
        Assert.AreEqual(this.value2!.GetValue(logic), "12");

        logic.TryCompute(new Button(), new ButtonArgs("/"));
        logic.InsertValue(new Button(), new ButtonArgs("0"));
        logic.TryCompute(new Button(), new ButtonArgs("/"));
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.InsertValue(new Button(), new ButtonArgs("1"));
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division"); // nothing happens
    }

    /// <summary>
    /// Tests TryCompute method of Logic.
    /// </summary>
    [TestMethod]
    public void TestTryCompute()
    {
        Logic logic = new Logic();
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        Assert.AreEqual(logic.Record, string.Empty); // nothing happens
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        logic.InsertValue(new Button(), new ButtonArgs("4"));
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        Assert.AreEqual(logic.Record, "24 + ");
        logic.TryCompute(new Button(), new ButtonArgs("-"));
        Assert.AreEqual(logic.Record, "24 - "); // safe operator switching
        logic.InsertValue(new Button(), new ButtonArgs("1"));
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        Assert.AreEqual(logic.Record, "12 + ");
        logic.TryCompute(new Button(), new ButtonArgs("/"));
        logic.InsertValue(new Button(), new ButtonArgs("0"));
        logic.TryCompute(new Button(), new ButtonArgs("/"));
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.TryCompute(new Button(), new ButtonArgs("/"));
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division"); // nothing happens
    }

    /// <summary>
    /// Tests Delete method of Logic.
    /// </summary>
    [TestMethod]
    public void TestDelete()
    {
        Logic logic = new Logic();
        logic.Delete(new Button(), new ButtonArgs("<-"));
        Assert.AreEqual(logic.Record, string.Empty); // nothing happens
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        logic.InsertValue(new Button(), new ButtonArgs("4"));
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        logic.Delete(new Button(), new ButtonArgs("<-"));
        logic.TryCompute(new Button(), new ButtonArgs("-"));
        Assert.AreEqual(logic.Record, "24 - "); // safe operator deleting
        logic.InsertValue(new Button(), new ButtonArgs("1"));
        logic.InsertValue(new Button(), new ButtonArgs("2"));
        logic.TryCompute(new Button(), new ButtonArgs("+"));
        Assert.AreEqual(logic.Record, "12 + ");  // safe operator deleting second part of the proof
        logic.TryCompute(new Button(), new ButtonArgs("/"));
        logic.InsertValue(new Button(), new ButtonArgs("0"));
        logic.TryCompute(new Button(), new ButtonArgs("/"));
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division");
        logic.Delete(new Button(), new ButtonArgs("<-"));
        Assert.AreEqual(logic.Record, "Calculation Error, 0 division"); // nothing happens
    }
}
