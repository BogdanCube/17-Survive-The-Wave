using UnityEngine;

namespace CharacterAdditions.Weapon
{
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "ScriptableObjects/CharacterAdditions/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        public string Name;
        public float Damage;
        [Range(0,1)] public float ChanceVampirism;
        [Range(0,1)] public float ChanceCritical;


        [Header("Graphic Parameters")]
        public Vector3 Offset;
        public Mesh Mesh;
        public Gradient GradientTrail;
    }
    
}