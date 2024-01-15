using System;
using System.Collections.Generic;

namespace Assets.Scripts.Sort.SortTypes
{
    /// <summary>
    /// Быстрая сортировка
    /// </summary>
    public static class QuickSort
    {
        public static List<TSource> Sort<TSource, TKey>(List<TSource> source, Func<TSource, TKey> keySelector, bool ascending = true) where TKey : IComparable
        {
            var list = new List<TSource>(source);

            list = _QuickSort(list, keySelector, 0, list.Count - 1, ascending);

            return list;
        }
        private static List<TSource> _QuickSort<TSource, TKey>(List<TSource> source, Func<TSource, TKey> keySelector, int minIndex, int maxIndex, bool ascending = true) where TKey : IComparable
        {
            var list = new List<TSource>(source);
            if (minIndex >= maxIndex)
            {
                return list;
            }

            var pivotIndex = Partition(list, keySelector, minIndex, maxIndex, ascending);
            list = _QuickSort(list, keySelector, minIndex, pivotIndex - 1, ascending);
            list = _QuickSort(list, keySelector, pivotIndex + 1, maxIndex, ascending);

            return list;
        }

        private static int Partition<TSource, TKey>(List<TSource> list, Func<TSource, TKey> keySelector, int minIndex, int maxIndex, bool ascending = true) where TKey : IComparable
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                var result = keySelector.Invoke(list[maxIndex]).CompareTo(keySelector.Invoke(list[i]));
                var sort = ascending ? result > 0 : result < 0;

                if (sort)
                {
                    pivot++;
                    (list[pivot], list[i]) = (list[i], list[pivot]);
                }
            }

            pivot++;
            (list[pivot], list[maxIndex]) = (list[maxIndex], list[pivot]);
            return pivot;
        }

    }
}