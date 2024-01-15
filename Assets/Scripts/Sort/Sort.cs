using System;
using System.Collections.Generic;
using Assets.Scripts.Sort.SortTypes;

namespace Assets.Scripts.Sort
{
    public static class Sort
    {
        /// <summary>
        /// Отсортировать элементы
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="items"></param>
        /// <param name="keySelector"></param>
        /// <param name="sortType"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static List<TSource> SortBy<TSource, TKey>(this List<TSource> items, Func<TSource, TKey> keySelector, SortType sortType, bool ascending = true) where TKey : IComparable
        {
            if(items == null)
                return new List<TSource>();

            return sortType switch
            {
                SortType.Bubble => BubbleSort.Sort(items, keySelector, ascending),
                SortType.Insertion => InsertionSort.Sort(items, keySelector, ascending),
                SortType.Quick => QuickSort.Sort(items, keySelector, ascending),
                SortType.Selection => SelectionSort.Sort(items, keySelector, ascending: ascending),
                _ => throw new ArgumentOutOfRangeException(nameof(sortType), sortType, "Отсутствует сортировка")
            };
        }
    }
}