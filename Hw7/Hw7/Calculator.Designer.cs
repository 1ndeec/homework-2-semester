// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7;

partial class Calculator
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new TableLayoutPanel();
        buttonDigit1 = new Button();
        buttonDigit2 = new Button();
        buttonDigit3 = new Button();
        buttonDigit4 = new Button();
        buttonDigit5 = new Button();
        buttonDigit6 = new Button();
        buttonDigit7 = new Button();
        buttonDigit8 = new Button();
        buttonDigit9 = new Button();
        buttonDigit0 = new Button();
        buttonOperatorAddition = new Button();
        buttonOperatorSubtraction = new Button();
        buttonOperatorMultiplication = new Button();
        buttonOperatorDivision = new Button();
        buttonDelete = new Button();
        buttonClear = new Button();
        textBox1 = new TextBox();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.Controls.Add(buttonDigit1, 0, 1);
        tableLayoutPanel1.Controls.Add(buttonDigit2, 1, 1);
        tableLayoutPanel1.Controls.Add(buttonDigit3, 2, 1);
        tableLayoutPanel1.Controls.Add(buttonDigit4, 0, 2);
        tableLayoutPanel1.Controls.Add(buttonDigit5, 1, 2);
        tableLayoutPanel1.Controls.Add(buttonDigit6, 2, 2);
        tableLayoutPanel1.Controls.Add(buttonDigit7, 0, 3);
        tableLayoutPanel1.Controls.Add(buttonDigit8, 1, 3);
        tableLayoutPanel1.Controls.Add(buttonDigit9, 2, 3);
        tableLayoutPanel1.Controls.Add(buttonDigit0, 1, 4);
        tableLayoutPanel1.Controls.Add(buttonOperatorAddition, 3, 1);
        tableLayoutPanel1.Controls.Add(buttonOperatorSubtraction, 3, 2);
        tableLayoutPanel1.Controls.Add(buttonOperatorMultiplication, 3, 3);
        tableLayoutPanel1.Controls.Add(buttonOperatorDivision, 3, 4);
        tableLayoutPanel1.Controls.Add(buttonDelete, 2, 4);
        tableLayoutPanel1.Controls.Add(buttonClear, 0, 4);
        tableLayoutPanel1.Controls.Add(textBox1, 0, 0);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 5;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(800, 450);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // button1
        // 
        buttonDigit1.Dock = DockStyle.Fill;
        buttonDigit1.Location = new Point(3, 93);
        buttonDigit1.Name = "button1";
        buttonDigit1.Size = new Size(194, 84);
        buttonDigit1.TabIndex = 0;
        buttonDigit1.Text = "1";
        buttonDigit1.UseVisualStyleBackColor = true;
        buttonDigit1.Click += DigitButton_Click;
        // 
        // button2
        // 
        buttonDigit2.Dock = DockStyle.Fill;
        buttonDigit2.Location = new Point(203, 93);
        buttonDigit2.Name = "button2";
        buttonDigit2.Size = new Size(194, 84);
        buttonDigit2.TabIndex = 1;
        buttonDigit2.Text = "2";
        buttonDigit2.UseVisualStyleBackColor = true;
        buttonDigit2.Click += DigitButton_Click;
        // 
        // button3
        // 
        buttonDigit3.Dock = DockStyle.Fill;
        buttonDigit3.Location = new Point(403, 93);
        buttonDigit3.Name = "button3";
        buttonDigit3.Size = new Size(194, 84);
        buttonDigit3.TabIndex = 2;
        buttonDigit3.Text = "3";
        buttonDigit3.UseVisualStyleBackColor = true;
        buttonDigit3.Click += DigitButton_Click;
        // 
        // button4
        // 
        buttonDigit4.Dock = DockStyle.Fill;
        buttonDigit4.Location = new Point(3, 183);
        buttonDigit4.Name = "button4";
        buttonDigit4.Size = new Size(194, 84);
        buttonDigit4.TabIndex = 3;
        buttonDigit4.Text = "4";
        buttonDigit4.UseVisualStyleBackColor = true;
        buttonDigit4.Click += DigitButton_Click;
        // 
        // button5
        // 
        buttonDigit5.Dock = DockStyle.Fill;
        buttonDigit5.Location = new Point(203, 183);
        buttonDigit5.Name = "button5";
        buttonDigit5.Size = new Size(194, 84);
        buttonDigit5.TabIndex = 4;
        buttonDigit5.Text = "5";
        buttonDigit5.UseVisualStyleBackColor = true;
        buttonDigit5.Click += DigitButton_Click;
        // 
        // button6
        // 
        buttonDigit6.Dock = DockStyle.Fill;
        buttonDigit6.Location = new Point(403, 183);
        buttonDigit6.Name = "button6";
        buttonDigit6.Size = new Size(194, 84);
        buttonDigit6.TabIndex = 5;
        buttonDigit6.Text = "6";
        buttonDigit6.UseVisualStyleBackColor = true;
        buttonDigit6.Click += DigitButton_Click;
        // 
        // button7
        // 
        buttonDigit7.Dock = DockStyle.Fill;
        buttonDigit7.Location = new Point(3, 273);
        buttonDigit7.Name = "button7";
        buttonDigit7.Size = new Size(194, 84);
        buttonDigit7.TabIndex = 6;
        buttonDigit7.Text = "7";
        buttonDigit7.UseVisualStyleBackColor = true;
        buttonDigit7.Click += DigitButton_Click;
        // 
        // button8
        // 
        buttonDigit8.Dock = DockStyle.Fill;
        buttonDigit8.Location = new Point(203, 273);
        buttonDigit8.Name = "button8";
        buttonDigit8.Size = new Size(194, 84);
        buttonDigit8.TabIndex = 7;
        buttonDigit8.Text = "8";
        buttonDigit8.UseVisualStyleBackColor = true;
        buttonDigit8.Click += DigitButton_Click;
        // 
        // button9
        // 
        buttonDigit9.Dock = DockStyle.Fill;
        buttonDigit9.Location = new Point(403, 273);
        buttonDigit9.Name = "button9";
        buttonDigit9.Size = new Size(194, 84);
        buttonDigit9.TabIndex = 8;
        buttonDigit9.Text = "9";
        buttonDigit9.UseVisualStyleBackColor = true;
        buttonDigit9.Click += DigitButton_Click;
        // 
        // button10
        // 
        buttonDigit0.Dock = DockStyle.Fill;
        buttonDigit0.Location = new Point(203, 363);
        buttonDigit0.Name = "button10";
        buttonDigit0.Size = new Size(194, 84);
        buttonDigit0.TabIndex = 9;
        buttonDigit0.Text = "0";
        buttonDigit0.UseVisualStyleBackColor = true;
        buttonDigit0.Click += DigitButton_Click;
        // 
        // button11
        // 
        buttonOperatorAddition.Dock = DockStyle.Fill;
        buttonOperatorAddition.Location = new Point(603, 93);
        buttonOperatorAddition.Name = "button11";
        buttonOperatorAddition.Size = new Size(194, 84);
        buttonOperatorAddition.TabIndex = 10;
        buttonOperatorAddition.Text = "+";
        buttonOperatorAddition.UseVisualStyleBackColor = true;
        buttonOperatorAddition.Click += OperatorButton_Click;
        // 
        // button12
        // 
        buttonOperatorSubtraction.Dock = DockStyle.Fill;
        buttonOperatorSubtraction.Location = new Point(603, 183);
        buttonOperatorSubtraction.Name = "button12";
        buttonOperatorSubtraction.Size = new Size(194, 84);
        buttonOperatorSubtraction.TabIndex = 11;
        buttonOperatorSubtraction.Text = "-";
        buttonOperatorSubtraction.UseVisualStyleBackColor = true;
        buttonOperatorSubtraction.Click += OperatorButton_Click;
        // 
        // button13
        // 
        buttonOperatorMultiplication.Dock = DockStyle.Fill;
        buttonOperatorMultiplication.Location = new Point(603, 273);
        buttonOperatorMultiplication.Name = "button13";
        buttonOperatorMultiplication.Size = new Size(194, 84);
        buttonOperatorMultiplication.TabIndex = 12;
        buttonOperatorMultiplication.Text = "*";
        buttonOperatorMultiplication.UseVisualStyleBackColor = true;
        buttonOperatorMultiplication.Click += OperatorButton_Click;
        // 
        // button14
        // 
        buttonOperatorDivision.Dock = DockStyle.Fill;
        buttonOperatorDivision.Location = new Point(603, 363);
        buttonOperatorDivision.Name = "button14";
        buttonOperatorDivision.Size = new Size(194, 84);
        buttonOperatorDivision.TabIndex = 13;
        buttonOperatorDivision.Text = "/";
        buttonOperatorDivision.UseVisualStyleBackColor = true;
        buttonOperatorDivision.Click += OperatorButton_Click;
        // 
        // button15
        // 
        buttonDelete.Dock = DockStyle.Fill;
        buttonDelete.Location = new Point(403, 363);
        buttonDelete.Name = "button15";
        buttonDelete.Size = new Size(194, 84);
        buttonDelete.TabIndex = 14;
        buttonDelete.Text = "<-";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += DeleteButton_Click;
        // 
        // button16
        // 
        buttonClear.Dock = DockStyle.Fill;
        buttonClear.Location = new Point(3, 363);
        buttonClear.Name = "button16";
        buttonClear.Size = new Size(194, 84);
        buttonClear.TabIndex = 15;
        buttonClear.Text = "C";
        buttonClear.UseVisualStyleBackColor = true;
        buttonClear.Click += ClearButton_Click;
        // 
        // textBox1
        // 
        tableLayoutPanel1.SetColumnSpan(textBox1, 4);
        textBox1.Dock = DockStyle.Fill;
        textBox1.Location = new Point(3, 3);
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.Size = new Size(794, 27);
        textBox1.TabIndex = 16;
        // 
        // Calculator
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        MinimumSize = new Size(0, 200);
        Name = "Calculator";
        Text = "Form1";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Button buttonDigit1;
    private Button buttonDigit2;
    private Button buttonDigit3;
    private Button buttonDigit4;
    private Button buttonDigit5;
    private Button buttonDigit6;
    private Button buttonDigit7;
    private Button buttonDigit8;
    private Button buttonDigit9;
    private Button buttonDigit0;
    private Button buttonOperatorAddition;
    private Button buttonOperatorSubtraction;
    private Button buttonOperatorMultiplication;
    private Button buttonOperatorDivision;
    private Button buttonDelete;
    private Button buttonClear;
    private TextBox textBox1;
}
