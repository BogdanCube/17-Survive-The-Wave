using UnityEngine;
using UnityEngine.UI;

namespace Environment.ShopPoint
{
    public class ShopItemTemplate : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;

        public void Load(Sprite sprite, int currentCount, int maxCount)
        {
            _image.sprite = sprite;
            _text.text = $"{currentCount} / {maxCount}";
        }
    }
}