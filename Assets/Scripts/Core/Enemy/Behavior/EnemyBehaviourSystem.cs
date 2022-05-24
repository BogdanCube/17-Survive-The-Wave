using Core.Character;
using Core.Enemy.Behavior;
using UnityEngine;

namespace Core.Enemy
{
    public class EnemyBehaviourSystem : BehaviourSystem
    {
        public override void SetRunningState()
        {
            SetState(ScriptableObject.CreateInstance<RunningStateEnemy>());
        }

        public override void SetFightingState()
        {
            SetState(ScriptableObject.CreateInstance<FightingStateEnemy>());
        }
    }
}