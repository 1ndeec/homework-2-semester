// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Hw6;

/// <summary>
/// class of methods which works with lists and lambda functions.
/// </summary>
public class Functions
{
    /// <summary>
    /// method that applies some function on list`s elements.
    /// </summary>
    /// <param name="list"> list on elements of which function will be applied. </param>
    /// <param name="function"> function to be applied on list`s elements. </param>
    /// <returns> the modified list with the function applied to each element. </returns>
    public static List<int> Map(List<int> list, Func<int, int> function)
    {
        return list.Select(x => function(x)).ToList();
    }

    /// <summary>
    /// method that selects those elements of list which passes check from given bool function.
    /// </summary>
    /// <param name="list"> list to pick elements from. </param>
    /// <param name="function"> check function. </param>
    /// <returns> list of picked elements. </returns>
    public static List<int> Filter(List<int> list, Func<int, bool> function)
    {
        return list.FindAll(x => function(x)).ToList();
    }

    /// <summary>
    /// method that compute a value from given elements of the list according to rules set by given function.
    /// </summary>
    /// <param name="list"> list of elements to compute on. </param>
    /// <param name="startSum"> start value. </param>
    /// <param name="function"> function that sets relation between given value and element of list.
    /// it gets a value and element of the list and returns new value according to internal logic of the function.</param>
    /// <returns> computed value. </returns>
    public static int Fold(List<int> list, int startSum, Func<int, int, int> function)
    {
        foreach (var x in list)
        {
            startSum = function(startSum, x);
        }

        return startSum;
    }
}
