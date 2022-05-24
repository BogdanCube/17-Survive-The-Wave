using CharacterAdditions.Health;
using CharacterAdditions.Level;
using CharacterAdditions.Weapon;
using Core.Character.Behavior;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private AnimationStateController _animationStateController;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private DetectorFighting _detectorFighting;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private LevelEquipment _levelEquipment;
        [SerializeField] [CanBeNull] private ShakeCamera _shakeCamera;


        public MovementController MovementController => _movementController;
        public AnimationStateController AnimationStateController => _animationStateController;
        public HealthComponent HealthComponent => _healthComponent;
        public DetectorFighting DetectorFighting => _detectorFighting;
        public Weapon Weapon => _weapon;
        public LevelEquipment LevelEquipment => _levelEquipment;
        public ShakeCamera ShakeCamera => _shakeCamera;
    }
}