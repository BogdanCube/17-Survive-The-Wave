using UnityEngine;

namespace CharacterAdditions.Armor
{
    [CreateAssetMenu(fileName = "New Armor Data", menuName = "ScriptableObjects/CharacterAdditions/ArmorData", order = 1)]
    public class ArmorData : ScriptableObject
    {
        public string Name;
        public float AdditionalHealth;
        
        [Header("Graphic Parameters")]
        public Mesh MeshHelmet;
        public Mesh MeshBreastplate;
    }
}