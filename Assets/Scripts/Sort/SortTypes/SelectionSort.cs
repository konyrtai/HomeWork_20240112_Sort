using System.Collections.Generic;
using System;


/// <summary>
/// Сортировка выбором
/// </summary>
public static class SelectionSort
{
    public static List<TSource> Sort<TSource, TKey>(List<TSource> array, Func<TSource, TKey> keySelector, int currentIndex = 0, bool ascending = true) where TKey : IComparable
    {
        if (currentIndex == array.Count)
            return array;


        var index = IndexOfMin(array, keySelector, currentIndex, ascending);

        if (index != currentIndex)
        {

            (array[index], array[currentIndex]) = (array[currentIndex], array[index]);
        }

        return Sort(array, keySelector, currentIndex + 1, ascending);
    }

    private static int IndexOfMin<TSource, TKey>(List<TSource> list, Func<TSource, TKey> keySelector, int n, bool ascending = true) where TKey : IComparable
    {
        int value = n;
        for (var i = n; i < list.Count; ++i)
        {
            var result = keySelector.Invoke(list[i]).CompareTo(keySelector.Invoke(list[value]));
            var sort = ascending ? result < 0 : result > 0;
            if (sort)
            {
                value = i;
            }
        }

        return value;
    }

}