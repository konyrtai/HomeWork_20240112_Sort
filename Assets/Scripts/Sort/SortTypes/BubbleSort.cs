using System;
using System.Collections.Generic;

namespace Assets.Scripts.Sort.SortTypes
{
    /// <summary>
    /// Сортировка пузырьком
    /// </summary>
    public static class BubbleSort
    {
        public static List<TSource> Sort<TSource, TKey>(List<TSource> source, Func<TSource, TKey> keySelector, bool ascending = true) where TKey : IComparable
        {
            var list = new List<TSource>(source);

            for (var i = 1; i < list.Count; i++)
            {
                for (var j = 0; j < list.Count - i; j++)
                {
                    var result = keySelector.Invoke(list[j]).CompareTo(keySelector.Invoke(list[j + 1]));
                    var sort = ascending ? result > 0 : result < 0;

                    if (sort)
                    {
                        (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    }
                }
            }

            return list;
        }
    }
}