using System;
using System.Collections.Generic;
using Core.Enemy.Loot.Data;
using UnityEngine;

namespace Core.Player.Bag
{
    public class Bag : MonoBehaviour
    {
        [SerializeField] private List<BagItem> _bagItems;
        private Dictionary<ItemData, BagItem> _itemDictionary;

        public Action<List<BagItem>> OnUpdateBagEvent;
        public List<BagItem> BagItems => _bagItems;
        private void Start()
        {
            _bagItems = new List<BagItem>();
            _itemDictionary = new Dictionary<ItemData, BagItem>();
            UpdateBag();
        }

        public void AddItem(ItemData itemData)
        {
            if (_itemDictionary.TryGetValue(itemData, out BagItem value))
            {
                value.AddCount();
            }
            else
            {
                BagItem newItem = new BagItem(itemData);
                _bagItems.Add(newItem);
                _itemDictionary.Add(itemData,newItem);
            }
            UpdateBag();
        }

        public void RemoveItem(ItemData itemData)
        {
            if (_itemDictionary.TryGetValue(itemData, out BagItem value))
            {
                value.RemoveCount();

                if (value.Count == 0)
                {
                    _bagItems.Remove(value);
                    _itemDictionary.Remove(itemData);
                }
            }

            UpdateBag();
        }

        public bool IsExistItem(ItemData itemData)
        {
            return _itemDictionary.TryGetValue(itemData, out BagItem value);
        }

        public bool IsComparisonItems(List<BagItem> bagItems)
        {
            bool[] isComparisons = new bool[bagItems.Count];

            for (int i = 0; i < bagItems.Count; i++)
            {
                foreach (var currentItem in _bagItems)
                {
                    if (currentItem.ItemData == bagItems[i].ItemData)
                    {
                        if (currentItem.Count >= bagItems[i].Count)
                        {
                            isComparisons[i] = true;
                            break;
                        }
                    }
                }
            }

            int countComparison = 0;
            foreach (var isComparison in isComparisons)
            {
                if (isComparison)
                {
                    countComparison++;
                }
            }
            return countComparison == bagItems.Count;
        }

        public int GetCountItem(ItemData itemData)
        {
            if (_itemDictionary.TryGetValue(itemData, out BagItem value))
            {
                return value.Count;
            }

            return 0;
        }
        
        [ContextMenu("SetCheatBag")]
        private void SetCheatBag()
        {
            foreach (var item in _bagItems)
            {
                item.AddCheatCount();
            }

            UpdateBag();
        }
        [ContextMenu("UpdateBag")]
        private void UpdateBag()
        {
            OnUpdateBagEvent?.Invoke(_bagItems);
        }
    }

    [System.Serializable]
    public class BagItem
    {
        public ItemData ItemData;
        public int Count;
        
        public BagItem(ItemData itemData)
        {
            ItemData = itemData;
            AddCount();
        }

        public void AddCount()
        {
            Count++;
        }
        public void AddCheatCount()
        {
            Count+=1000;
        }

        public void RemoveCount()
        {
            Count--;
        }

        public string GetInformation()
        {
            return $"ItemData {ItemData}, Count {Count}";
        }
    }
}