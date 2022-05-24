using CharacterAdditions.Armor;
using CharacterAdditions.Weapon;
using UnityEngine;

namespace CharacterAdditions.Level
{
    public class LevelEquipment : MonoBehaviour
    {
        [SerializeField] [Range(0, 3)] private int _level;
        [SerializeField] private EquipmentData _equipmentData;

        [Header("Loaders")] 
        [SerializeField] private LoaderWeapon _loaderWeapon;
        [SerializeField] private LoaderArmor _loaderArmor;

        public int Level => _level;
        private void Awake()
        {
            UpdateEquipment();
        }
        
        public void SetLevel(int level)
        {
            _level = level;
            SetEquipment(_level);
        }
        public void SetEquipment(int level)
        {
            var currentWeapon = _equipmentData.Equipments[level].WeaponData;
            _loaderWeapon.LoadData(currentWeapon);
            
            var currentArmor = _equipmentData.Equipments[level].ArmorData;
            _loaderArmor.LoadData(currentArmor);
        }
        
        [ContextMenu("UpdateEquipment")]
        private void UpdateEquipment()
        {
            SetEquipment(_level);
        }
    }
}