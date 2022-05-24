using UnityEngine;

namespace Core.Character.Behavior
{
    public class IdleState : State
    {
        public override void Start()
        {
            BehaviourSystem.Character.AnimationStateController.IsRunning = false;
        }

        public override void Update()
        {
            if (BehaviourSystem.Character.MovementController.IsMove)
            {
                BehaviourSystem.SetRunningState();
            }
            
            if (BehaviourSystem.Character.DetectorFighting.IsFight)
            {
                BehaviourSystem.SetFightingState();
            } 
        }

        public override void End()
        {
            
        }
    }
}