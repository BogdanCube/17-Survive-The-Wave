using Core.Character;
using UnityEngine;

namespace Core.Enemy
{
    public class DetectorPlayer : DetectorFighting
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Player.Player player))
            {
                _currentTarget = player;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player.Player player))
            {
                _currentTarget = null;
            }
        }
    }
}