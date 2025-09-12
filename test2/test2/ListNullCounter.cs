// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test2;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a method to count null argument in CustomList.
/// </summary>
public static class ListNullCounter
{
    /// <summary>
    /// Counts null elements in the list using specified null checker.
    /// </summary>
    /// <param name="list">List to check. </param>
    /// <param name="nullChecker">Null checking logic. </param>
    /// <returns> Number of null elements in CustomList. </returns>
    /// <exception cref="ArgumentNullException">Thrown if list or nullChecker is null. </exception>
    /// <typeparam name="T"> Type of elements in the list. </typeparam>
    public static int CountNullElements<T>(CustomList<T> list, INullChecker<T> nullChecker)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        if (nullChecker == null)
        {
            throw new ArgumentNullException(nameof(nullChecker));
        }

        int nullCount = 0;
        foreach (var item in list)
        {
            if (nullChecker.IsNull(item))
            {
                nullCount++;
            }
        }

        return nullCount;
    }
}
