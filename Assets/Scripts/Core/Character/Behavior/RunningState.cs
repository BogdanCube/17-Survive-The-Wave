namespace Core.Character.Behavior
{
    public class RunningState : State
    {
        public override void Start()
        {
            BehaviourSystem.Character.AnimationStateController.IsRunning = true;
        }
        public override void Update()
        {
            if (BehaviourSystem.Character.MovementController.IsMove)
            {
                BehaviourSystem.Character.MovementController.Move();
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<IdleState>());
            }
        }

        public override void End()
        {
            BehaviourSystem.Character.AnimationStateController.IsRunning = false;
        }
    }
}
