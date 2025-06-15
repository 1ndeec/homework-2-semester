// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7;

/// <summary>
/// class for out main form.
/// </summary>
public partial class Calculator : Form
{
    private Logic logic;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    public Calculator()
    {
        this.InitializeComponent();
        this.logic = new Logic();
    }

    private void DigitButton_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        ArgumentNullException.ThrowIfNull(button);

        this.logic.InsertValue(button.Text);
        this.textBox1.Text = this.logic.Record;
    }

    /// <summary>
    /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data associated with the mouse click.</param>
    private void Button11_Click(object sender, EventArgs e)
    {
        this.logic.TryCompute(this.button11.Text);
        this.textBox1.Text = this.logic.Record;
    }

    /// <summary>
    /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data associated with the mouse click.</param>
    private void Button12_Click(object sender, EventArgs e)
    {
        this.logic.TryCompute(this.button12.Text);
        this.textBox1.Text = this.logic.Record;
    }

    /// <summary>
    /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data associated with the mouse click.</param>
    private void Button13_Click(object sender, EventArgs e)
    {
        this.logic.TryCompute(this.button13.Text);
        this.textBox1.Text = this.logic.Record;
    }

    /// <summary>
    /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data associated with the mouse click.</param>
    private void Button14_Click(object sender, EventArgs e)
    {
        this.logic.TryCompute(this.button14.Text);
        this.textBox1.Text = this.logic.Record;
    }

    /// <summary>
    /// Handles the click event on button11. Deletes last char in the textbox, if there are any and if there is no error in the textbox.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data associated with the mouse click.</param>
    private void Button15_Click(object sender, EventArgs e)
    {
        this.logic.Delete();
        this.textBox1.Text = this.logic.Record;
    }

    /// <summary>
    /// Handles the click event on button11. Clears the textbox.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data associated with the mouse click.</param>
    private void Button16_Click(object sender, EventArgs e)
    {
        this.logic.Clear();
        this.textBox1.Text = this.logic.Record;
    }
}