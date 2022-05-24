using System;
using DG.Tweening;
using UnityEngine;

namespace Environment.Platform
{
    public class Platform : MonoBehaviour
    {
        [ContextMenu("AddPlatform")]
        public void AddPlatform(float timeMoved)
        {           
            gameObject.SetActive(true);

            transform.position = new Vector3(0, -0.7f, 0);
            transform.localScale = Vector3.zero;

            transform.DOMove(Vector3.zero, timeMoved);
            transform.DOScale(Vector3.one, timeMoved / 2);
        }
    }
}