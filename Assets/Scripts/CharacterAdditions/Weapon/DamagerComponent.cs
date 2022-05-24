using Core.Character;
using UnityEngine;
using UnityEngine.Events;

namespace CharacterAdditions.Weapon
{
    public class DamagerComponent : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Character character))
            {                
                _weapon.TakeHit(character);
            }
        }
    }
}

