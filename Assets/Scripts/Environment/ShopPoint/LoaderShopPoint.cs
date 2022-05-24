using System;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.ShopPoint
{
    public class LoaderShopPoint : MonoBehaviour
    {
        [SerializeField] private ShopPointData _shopPointData;
        
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private ShopPoint _shopPoint;

        private void Start()
        {
            Load();
        }
        private void Load()
        {
            _meshFilter.mesh = _shopPointData.Mesh;

            var priceItems = _shopPointData.PriceItems;
            var level = _shopPointData.LevelEquipment;
            _shopPoint.LoadPriceItems(priceItems, level);
        }

    }
}