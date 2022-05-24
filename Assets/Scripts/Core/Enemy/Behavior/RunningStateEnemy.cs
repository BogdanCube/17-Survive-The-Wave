using Core.Character.Behavior;
using UnityEngine;

namespace Core.Enemy.Behavior
{
    public class RunningStateEnemy : RunningState
    {
        public override void Update()
        {
            base.Update();
            if (BehaviourSystem.Character.DetectorFighting.IsFight)
            {
                BehaviourSystem.SetState(CreateInstance<FightingStateEnemy>());
            }
        }
    }
}