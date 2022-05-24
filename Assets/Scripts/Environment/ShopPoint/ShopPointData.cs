using System.Collections.Generic;
using Core.Player.Bag;
using UnityEngine;

namespace Environment.ShopPoint
{
    [CreateAssetMenu(fileName = "New Shop Point", menuName = "ScriptableObjects/Shop Point", order = 1)]

    public class ShopPointData : ScriptableObject
    {
        public int LevelEquipment;
        public Mesh Mesh;
        public List<BagItem> PriceItems;
    }
}