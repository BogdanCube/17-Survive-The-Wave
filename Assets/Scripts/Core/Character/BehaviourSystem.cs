using Core.Character.Behavior;
using UnityEngine;

namespace Core.Character
{
    public class BehaviourSystem : MonoBehaviour 
    {
        [SerializeField] private Character _character;
        [SerializeField] private State _currentState;

        public Character Character => _character;
        
        private void Start() {
            SetState(ScriptableObject.CreateInstance<IdleState>());
        }
        
        private void Update() {
            _currentState.Update();
        }

        public void SetState(State state)
        {
            if (_currentState != null) {
                _currentState.End();
            }
            _currentState = Instantiate(state);
            _currentState.BehaviourSystem = this;
            _currentState.Start();
        }

        public virtual void SetRunningState()
        {            
            SetState(ScriptableObject.CreateInstance<RunningState>());
        }

        public virtual void SetFightingState()
        {
            SetState(ScriptableObject.CreateInstance<FightingState>());
        }
    }
}