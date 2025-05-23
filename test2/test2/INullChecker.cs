// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test2;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Defines a method to determine if an item is considered null for a specific type.
/// </summary>
/// <typeparam name="T">The type of items to check. </typeparam>
public interface INullChecker<in T>
{
    /// <summary>
    /// Returns if given element is null.
    /// </summary>
    /// <param name="item"> Element to check whether its null. </param>
    /// <returns> True if null, false if not. </returns>
    bool IsNull(T item);
}
