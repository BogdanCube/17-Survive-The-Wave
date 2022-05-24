using Core.Enemy.Loot;
using UnityEngine;

namespace Core.Player.Bag
{
    public class DetectorItems : MonoBehaviour
    {
        [SerializeField] private Bag _bag;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ItemTemplate item))
            {
               _bag.AddItem(item.CurrentItem);
               item.DestroyItem();
            }
        }
    }
}