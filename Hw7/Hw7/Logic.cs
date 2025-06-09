// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7
{
    /// <summary>
    /// Contains calculator`s logics.
    /// </summary>
    public class Logic
    {
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
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data, contains a value to be inserted. </param>
        public void InsertValue(object sender, ButtonArgs e)
        {
            if (this.Record != "Calculation Error, 0 division")
            {
                this.Record += e.Text;
                switch (this.currentValue)
                {
                    case false:
                        this.value1 += e.Text;
                        break;
                    case true:
                        this.value2 += e.Text;
                        break;
                }

                this.isThereValue = true;
            }
        }

        /// <summary>
        /// Tries to compute a value with given operator if operands are not empty.
        /// </summary>
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data, contains an operator. </param>
        public void TryCompute(object sender, ButtonArgs e)
        {
            if (this.isThereValue && this.Record != "Calculation Error, 0 division")
            {
                if (this.value2 != string.Empty)
                {
                    this.value1 = this.Compute();
                    this.value2 = string.Empty;
                }

                this.calcOperator = e.Text;
                this.currentValue = true;
                if (this.value1 == "Calculation Error, 0 division")
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
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        public void Clear(object sender, ButtonArgs e)
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
        /// <param name="sender"> The source of the event. </param>
        /// <param name="e"> The event data. </param>
        public void Delete(object sender, ButtonArgs e)
        {
            if (this.Record != "Calculation Error, 0 division")
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
                        return "Calculation Error, 0 division";
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
}
