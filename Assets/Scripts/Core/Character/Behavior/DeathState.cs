using UnityEngine;

namespace Core.Character.Behavior
{
    public class DeathState : State
    {
        public override void Start()
        {
            BehaviourSystem.Character.AnimationStateController.Death();
        }

        public override void Update()
        {
            
        }

        public override void End()
        {
            
        }
    }
}