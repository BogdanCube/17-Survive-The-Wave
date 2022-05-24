using System.Collections.Generic;
using CharacterAdditions.Armor;
using CharacterAdditions.Weapon;
using UnityEngine;

namespace CharacterAdditions.Level
{
    [CreateAssetMenu(fileName = "New Equipment Data", menuName = "ScriptableObjects/CharacterAdditions/EquipmentData", order = 1)]
    public class EquipmentData : ScriptableObject
    {
        public List<Equipment> Equipments = new List<Equipment>();
    }
    [System.Serializable]
    public struct Equipment
    {
        public WeaponData WeaponData;
        public ArmorData ArmorData;
    }
}