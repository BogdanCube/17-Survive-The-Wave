using CharacterAdditions.Health;
using Core.Character;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CharacterAdditions.Weapon
{
     public class Weapon : MonoBehaviour
     {
         [SerializeField] private HealthComponent _healthComponent;
         private float _damage;
         private float _chanceVampirism;
         private float _chanceCritical;
         

         public void LoadParameters(float damage, float chanceVampirism, float chanceCritical)
         {
             _damage = damage;
             _chanceVampirism = chanceVampirism;
             _chanceCritical = chanceCritical;
         }
         public void TakeHit(Character character)
         {
             if (character.HealthComponent.IsDeath == false)
             {
                 character.HealthComponent.Hit(_damage);     
                 _healthComponent.Heal(CurrentHeal());
             }
         }
         private float CurrentDamage()
         {
             return _chanceCritical > Random.Range(0f, 1f) ? _damage * 2 : _damage;
         }

         private float CurrentHeal()
         {
             return _chanceVampirism > Random.Range(0f, 1f) ? _damage / 2 : 0;
         }
     }
}

