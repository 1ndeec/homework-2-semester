// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7;

/// <summary>
/// Contains calculator`s logics.
/// </summary>
public class Logic
{
    private const string CalcErrorZero = "Calculation Error, 0 division";
    private string value1 = string.Empty;
    private string value2 = string.Empty;
    private string calcOperator = string.Empty;
    private bool currentValue = false;
    private bool isThereValue = false;

    /// <summary>
    /// Gets or sets the most recent operation data.
    /// </summary>
    public string Record { get; set; } = string.Empty;

    /// <summary>
    /// Inserts a value in operands and in record.
    /// </summary>
    /// <param name="value"> Value. </param>
    public void InsertValue(string value)
    {
        if (this.Record != CalcErrorZero)
        {
            this.Record += value;
            switch (this.currentValue)
            {
                case false:
                    this.value1 += value;
                    break;
                case true:
                    this.value2 += value;
                    break;
            }

            this.isThereValue = true;
        }
    }

    /// <summary>
    /// Tries to compute a value with given operator if operands are not empty.
    /// </summary>
    /// <param name="operatorText"> Operator`s text representation. </param>
    public void TryCompute(string operatorText)
    {
        if (this.isThereValue && this.Record != CalcErrorZero)
        {
            if (this.value2 != string.Empty)
            {
                this.value1 = this.Compute();
                this.value2 = string.Empty;
            }

            this.calcOperator = operatorText;
            this.currentValue = true;
            if (this.value1 == CalcErrorZero)
            {
                this.Record = this.value1;
            }
            else
            {
                this.Record = $"{this.value1} {this.calcOperator} ";
            }
        }
    }

    /// <summary>
    /// Sets all data in class member to default values.
    /// </summary>
    public void Clear()
    {
        this.value1 = string.Empty;
        this.value2 = string.Empty;
        this.calcOperator = string.Empty;
        this.currentValue = false;
        this.isThereValue = false;
        this.Record = string.Empty;
    }

    /// <summary>
    /// Deletes last inserted operand or operator.
    /// </summary>
    public void Delete()
    {
        if (this.Record != CalcErrorZero)
        {
            if (this.value2 != string.Empty)
            {
                this.value2 = this.value2[0..^1];
                this.Record = this.Record[0..^1];
            }
            else if (this.calcOperator != string.Empty)
            {
                this.calcOperator = string.Empty;
                this.Record = this.Record[0..^3];
                this.currentValue = false;
            }
            else if (this.value1 != string.Empty)
            {
                this.value1 = this.value1[0..^1];
                if (this.value1 == string.Empty)
                {
                    this.isThereValue = false;
                }

                this.Record = this.Record[0..^1];
            }
        }
    }

    private string Compute()
    {
        switch (this.calcOperator)
        {
            case "*":
                return Convert.ToString(Convert.ToInt32(this.value1) * Convert.ToInt32(this.value2));
            case "/":
                if (this.value2 == "0")
                {
                    return CalcErrorZero;
                }
                else
                {
                    return Convert.ToString(Convert.ToInt32(this.value1) / Convert.ToInt32(this.value2));
                }

            case "+":
                return Convert.ToString(Convert.ToInt32(this.value1) + Convert.ToInt32(this.value2));
            case "-":
                return Convert.ToString(Convert.ToInt32(this.value1) - Convert.ToInt32(this.value2));
        }

        return "Calculation Error, wrong operator";
    }
}
