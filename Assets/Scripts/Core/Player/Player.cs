using CharacterAdditions.Health;
using UnityEngine;

namespace Core.Player
{
    public class Player : Character.Character
    {
        [SerializeField] private Bag.Bag _bag;
        public Bag.Bag Bag => _bag;
    }
}