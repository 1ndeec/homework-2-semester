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
/// Provides a method a check whether is integer is null (zero).
/// </summary>
public class IntNullChecker : INullChecker<int>
{
    /// <summary>
    /// Checks whether is integer is null (zero).
    /// </summary>
    /// <param name="item"> Item to check. </param>
    /// <returns> true if given integer is zero, false if not. </returns>
    public bool IsNull(int item) => item == 0;
}
