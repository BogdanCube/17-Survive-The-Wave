using System.Collections.Generic;
using Core.Enemy.Loot.Data;
using UnityEngine;

namespace Core.Player.Bag
{
    public class DisplayedBag : MonoBehaviour
    {
        [SerializeField] private Bag _bag;
        [SerializeField] private BagItemTemplate _template;
        private void OnEnable()
        {
            _bag.OnUpdateBagEvent += OnUpdateBag;
        }

        private void OnDisable()
        {
            _bag.OnUpdateBagEvent -= OnUpdateBag;
        }

        public void OnUpdateBag(List<BagItem> items)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            foreach (var item in items)
            {
                var template = Instantiate(_template, this.transform);
                template.Load(item);
            }
        }
    }
}