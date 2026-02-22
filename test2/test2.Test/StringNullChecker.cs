// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Check.Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2;

/// <summary>
/// provides a method to check whether is string is null (empty).
/// </summary>
public class StringNullChecker : INullChecker<string>
{
    /// <summary>
    /// Checks whether is string is null (empty).
    /// </summary>
    /// <param name="item"> Item to check. </param>
    /// <returns> true if given string is empty, false if not. </returns>
    public bool IsNull(string item) => item == string.Empty;
}