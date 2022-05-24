namespace Core.Character.Behavior
{
    public class FightingState : State
    {
        public override void Start()
        {
            BehaviourSystem.Character.AnimationStateController.IsFighting = true;
        }

        public override void Update()
        {
            if (BehaviourSystem.Character.DetectorFighting.IsFight == false)
            {
                BehaviourSystem.SetRunningState();
            }
            else if (BehaviourSystem.Character.MovementController.IsMove)
            {
                BehaviourSystem.SetRunningState();
            }
        }

        public override void End()
        {          
            BehaviourSystem.Character.AnimationStateController.IsFighting = false;
        }
    }
}
