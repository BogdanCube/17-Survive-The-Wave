using Core.Enemy.Loot.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Player.Bag
{
    public class BagItemTemplate : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;

        public void Load(BagItem bagItem)
        {            
            _text.text = bagItem.Count.ToString();

            _image.sprite = bagItem.ItemData.Sprite;
        }
    }
}