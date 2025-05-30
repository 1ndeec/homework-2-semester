// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Test22
{
    /// <summary>
    /// Utilities for working with lists.
    /// </summary>
    public static class ListUtils
    {
        /// <summary>
        /// Extension method for bubble sort of a list.
        /// </summary>
        /// <typeparam name="T">Type of list elements.</typeparam>
        /// <param name="list">List to be sorted.</param>
        /// <param name="comparer">Comparer for element comparison.</param>
        /// <returns>Sorted list..</returns>
        public static CustomList<T> Sort<T>(this CustomList<T> list, IComparer<T> comparer)
        {
            ArgumentNullException.ThrowIfNull(list);

            ArgumentNullException.ThrowIfNull(comparer);

            var sortedList = new CustomList<T>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                sortedList.Add(list[i]);
            }

            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < sortedList.Count - 1; i++)
                {
                    if (comparer.Compare(sortedList[i], sortedList[i + 1]) > 0)
                    {
                        T temp = sortedList[i];
                        sortedList[i] = sortedList[i + 1];
                        sortedList[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
            while (swapped);

            return sortedList;
        }
    }
}
