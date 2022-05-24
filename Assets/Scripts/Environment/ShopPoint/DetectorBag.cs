using System;
using Core.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.ShopPoint
{
    public class DetectorBag : MonoBehaviour
    {
        [SerializeField] private Image _panelBuy;
        [SerializeField] private ShopPoint _shopPoint;

        private void Start()
        {
            _panelBuy.gameObject.SetActive(false);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Player player) && _shopPoint.IsSuitableLevel)
            {
                _panelBuy.gameObject.SetActive(true);
                _panelBuy.transform.LookAt(Camera.main.transform);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                StartCoroutine(_shopPoint.ReplenishmentItems(player.Bag));
            }        
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _panelBuy.gameObject.SetActive(false);
                StopAllCoroutines();
            }
        }
    }
}