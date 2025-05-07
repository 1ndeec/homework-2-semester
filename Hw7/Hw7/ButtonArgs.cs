// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw7
{
    /// <summary>
    /// Provides event data containing the text of a clicked button.
    /// </summary>
    public class ButtonArgs : EventArgs
    {
        /// <summary>
        /// The text of the button.
        /// </summary>
        private readonly string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="ButtonArgs"/> class.
        /// </summary>
        /// <param name="text"> The text of the button. </param>
        public ButtonArgs(string text)
        {
            this.text = text;
        }

        /// <summary>
        /// Gets The text of the button.
        /// </summary>
        public string Text => this.text;
    }
}
