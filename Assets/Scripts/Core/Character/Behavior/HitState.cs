using UnityEngine;

namespace Core.Character.Behavior
{
    public class HitState : State
    {
        public override void Start()
        {
            BehaviourSystem.Character.ShakeCamera?.StartShake();
        }
        public override void Update()
        {
            if (BehaviourSystem.Character.MovementController.IsMove)
            {
                BehaviourSystem.SetRunningState();
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<IdleState>());
            }
        }

        public override void End()
        {
            
        }
    }
}