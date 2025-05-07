// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7
{
    /// <summary>
    /// class for out main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private Logic logic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.logic = new Logic();
        }

        /// <summary>
        /// Handles the click event on button1. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button1.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button2. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button2_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button2.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button3. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button3_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button3.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button4. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button4_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button4.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button5. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button5_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button5.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button6. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button6_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button6.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button7. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button7_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button7.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button8. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button8_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button8.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button9. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button9_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button9.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button10. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button10_Click(object sender, EventArgs e)
        {
            this.logic.InsertValue(this, new ButtonArgs(this.button10.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button11_Click(object sender, EventArgs e)
        {
            this.logic.TryCompute(this, new ButtonArgs(this.button11.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button12_Click(object sender, EventArgs e)
        {
            this.logic.TryCompute(this, new ButtonArgs(this.button12.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button13_Click(object sender, EventArgs e)
        {
            this.logic.TryCompute(this, new ButtonArgs(this.button13.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button11. Inserts the button's text into the logic handler and updates the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button14_Click(object sender, EventArgs e)
        {
            this.logic.TryCompute(this, new ButtonArgs(this.button14.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button11. Deletes last char in the textbox, if there are any and if there is no error in the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button15_Click(object sender, EventArgs e)
        {
            this.logic.Delete(this, new ButtonArgs(this.button15.Text));
            this.textBox1.Text = this.logic.Record;
        }

        /// <summary>
        /// Handles the click event on button11. Clears the textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data associated with the mouse click.</param>
        private void Button16_Click(object sender, EventArgs e)
        {
            this.logic.Clear(this, new ButtonArgs(this.button16.Text));
            this.textBox1.Text = this.logic.Record;
        }
    }
}