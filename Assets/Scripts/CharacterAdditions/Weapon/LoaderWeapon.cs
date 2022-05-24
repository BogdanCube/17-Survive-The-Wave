using UnityEngine;

namespace CharacterAdditions.Weapon
{
    public class LoaderWeapon : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        
        [Header("Graphic Parameters")] 
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private TrailRenderer _trailRenderer;
        
        
        [ContextMenu("LoadDate")]
        public void LoadData(WeaponData weaponData)
        {
            _weapon.LoadParameters(weaponData.Damage, weaponData.ChanceVampirism, weaponData.ChanceCritical);

            _meshFilter.transform.localPosition = weaponData.Offset;
            _meshFilter.mesh = weaponData.Mesh;
            _trailRenderer.colorGradient = weaponData.GradientTrail;
        }
    }
}