using System;
using System.Collections.Generic;

namespace Assets.Scripts.Sort.SortTypes
{
    /// <summary>
    /// Сортировка вставкой
    /// </summary>
    public static class InsertionSort
    {
        public static List<TSource> Sort<TSource, TKey>(List<TSource> source, Func<TSource, TKey> keySelector, bool ascending = true) where TKey : IComparable
        {
            var list = new List<TSource>(source);

            for (var i = 1; i < list.Count; i++)
            {
                var j = i;
                var key = list[i];

                bool ShouldSort()
                {
                    var result = keySelector(list[j - 1]).CompareTo(keySelector(key));
                    return ascending ? result > 0 : result < 0;
                }

                while (j > 0 && ShouldSort())
                {
                    (list[j], list[j - 1]) = (list[j - 1], list[j]);
                    j--;
                }

                list[j] = key;
            }

            return list;
        }
    }
}