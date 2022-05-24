using System.Collections.Generic;
using Core.Enemy.Loot.Data;
using Core.Player.Bag;
using UnityEngine;

namespace Environment.ShopPoint
{
    public class DisplayerBagShop : MonoBehaviour
    {
        [SerializeField] private ShopPoint _shopPoint;
        [SerializeField] private ShopItemTemplate _template;
   
        private void OnEnable()
        {
            _shopPoint.OnReplenishmentItemsEvent += OnReplenishmentItems;
        }

        private void OnDisable()
        {
            _shopPoint.OnReplenishmentItemsEvent -= OnReplenishmentItems;
        }

        public void OnReplenishmentItems(Bag currentBagItems, List<BagItem> priceBagItems)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            foreach (var priceItem in priceBagItems)
            {
                foreach (var currentItems in currentBagItems.BagItems)
                {
                    if (currentItems.ItemData == priceItem.ItemData)
                    {
                        var sprite = priceItem.ItemData.Sprite;
                        var minCount = currentItems.Count;
                        var maxCount = priceItem.Count;
                        
                        var template = Instantiate(_template, this.transform);
                        template.Load(sprite,minCount,maxCount);
                    }
                }

            }
        }
    }
}