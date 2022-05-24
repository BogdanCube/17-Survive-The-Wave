using Core.Character.Behavior;

namespace Core.Enemy.Behavior
{
    public class FightingStateEnemy : FightingState
    {
        public override void Update()
        {
            if (BehaviourSystem.Character.DetectorFighting.IsFight == false)
            {
                BehaviourSystem.SetRunningState();
            }
        }
    }
}