using System;
using DG.Tweening;
using Core.Character.Behavior;
using UnityEngine;

namespace Core.Enemy
{
    public class StalkingPlayer : MovementController
    {
        [SerializeField] private Transform _target;
        public override bool IsMove => _target != null;
        
        private void Start()
        {
            _navMeshAgent.speed = _speed;
            _target = FindObjectOfType<Player.Player>().transform;
        }
        
        public override void Move()
        {
            _navMeshAgent.SetDestination(_target.position);
            transform.DOLookAt(_target.position, 0.5f);
        }
    }
}

