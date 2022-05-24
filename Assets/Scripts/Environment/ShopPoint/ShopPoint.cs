using System;
using System.Collections;
using System.Collections.Generic;
using CharacterAdditions.Level;
using Core.Enemy.Loot.Data;
using Core.Player;
using Core.Player.Bag;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Environment.ShopPoint
{
    public class ShopPoint : MonoBehaviour
    {
        [SerializeField] private float _pumpingSpeed;
        
        [Space] [SerializeField] private List<BagItem> _priceItems;
        [SerializeField] private Bag _currentBagItems;
        [SerializeField] private LevelEquipment _equipment;
        
        private int _levelEquipment;
        private bool _isBuyEquipment;

        public Action<Bag,List<BagItem>> OnReplenishmentItemsEvent;
        public UnityEvent OnBuyEquipmentEvent;

        public bool IsSuitableLevel => _levelEquipment == _equipment.Level + 1;

        private void Start()
        {
            UpdateDisplayed();
        }

        public void LoadPriceItems(List<BagItem> priceItems, int levelEquipment)
        {
            _priceItems = priceItems;
            _levelEquipment = levelEquipment;
        }
        
        public IEnumerator ReplenishmentItems(Bag bag)
        {
            while (!_isBuyEquipment && IsSuitableLevel)
            {
                yield return new WaitForSeconds(_pumpingSpeed);
                foreach (var bagItem in _priceItems)
                {
                    var item = bagItem.ItemData;
                    if (bag.IsExistItem(item))
                    {
                        if(_currentBagItems.GetCountItem(item) < bagItem.Count)
                        {
                            bag.RemoveItem(item);
                            _currentBagItems.AddItem(item);

                            UpdateDisplayed();
                            if (_currentBagItems.IsComparisonItems(_priceItems))
                            {
                                _equipment.SetLevel(_levelEquipment);
                                OnBuyEquipmentEvent.Invoke();
                                _isBuyEquipment = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateDisplayed()
        {
            OnReplenishmentItemsEvent?.Invoke(_currentBagItems, _priceItems);
        }
    }
}