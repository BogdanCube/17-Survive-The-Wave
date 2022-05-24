using CharacterAdditions.Health;
using JetBrains.Annotations;
using UnityEngine;

namespace CharacterAdditions.Armor
{
    public class LoaderArmor : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        
        [Header("Graphic Parameters")] 
        [SerializeField] [CanBeNull] private MeshFilter _meshHelmet;
        [SerializeField] [CanBeNull] private MeshFilter _meshBreastplate;
        
        public void LoadData(ArmorData armorData)
        {
            _healthComponent.IncreaseMaxHealth(armorData.AdditionalHealth);
            if (_meshHelmet != null) _meshHelmet.mesh = armorData.MeshHelmet;
            _meshBreastplate.mesh = armorData.MeshBreastplate;
        }
    }
}