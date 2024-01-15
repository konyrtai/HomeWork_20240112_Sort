using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Sort;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ManageSort : MonoBehaviour
    {
        [SerializeField] private Dropdown _sortByDropdown;
        [SerializeField] private Dropdown _sortTypeDropdown;
        [SerializeField] private Dropdown _sortOrderDropdown;
        [SerializeField] private Button _sortButton;

        private List<GameObject> items;

        // Start is called before the first frame update
        void Start()
        {
            items = GameObject.FindGameObjectsWithTag("Cube").ToList();

            _sortButton.onClick.AddListener(SortItems);
        }

        void SortItems()
        {

            var sortOption = (SortOption)_sortByDropdown.value;
            var sortType = (SortType)_sortTypeDropdown.value;
            var ascending = string.Equals(_sortOrderDropdown.options[_sortOrderDropdown.value].text, "Возрастанию", StringComparison.InvariantCultureIgnoreCase);

            var sortedItems = sortOption switch
            {
                SortOption.Width => items.SortBy(item => item.transform.localScale.x, sortType, ascending),
                SortOption.Height => items.SortBy(item => item.transform.localScale.y, sortType, ascending),
                _ => throw new ArgumentOutOfRangeException()
            };

            for (int i = 0; i < sortedItems.Count; i++)
            {
                var itemOnPrevPosition = items.FirstOrDefault(x => x.GetInstanceID() == sortedItems[i].GetInstanceID());
                if (itemOnPrevPosition == null)
                    throw new NullReferenceException(nameof(itemOnPrevPosition));

                var prevIndex = items.IndexOf(itemOnPrevPosition);

                //(itemOnPrevPosition.transform.position, items[i].transform.position) = (items[i].transform.position, itemOnPrevPosition.transform.position);
                (items[prevIndex], items[i]) = (items[i], items[prevIndex]);
            }

            for (int i = 0; i < items.Count; i++)
            {
                items[i].transform.position = new Vector3(i * 2, items[i].transform.position.y, items[i].transform.position.z);
            }

            foreach (var item in items)
            {
                Debug.Log($"{item.GetInstanceID()} | WIDTH: {item.transform.localScale.x} HEIGHT: {item.transform.localScale.y} | X: {item.transform.position.x} Y: {item.transform.position.y}");
            }
        }


        void RandomItemsPosition()
        {

        }

    }
}
