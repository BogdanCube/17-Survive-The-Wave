using Core.Character;
using UnityEngine;

namespace Core.Player
{
    public class DetectorEnemy : DetectorFighting
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy.Enemy enemy))
            {
                _currentTarget = enemy;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Enemy.Enemy enemy))
            {
                _currentTarget = null;
            }
        }
    }
}

