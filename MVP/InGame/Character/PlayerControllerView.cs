using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UniRx.Triggers;
using UniRx;
using System;

namespace Holo5GunGame.View
{
    public class PlayerControllerView : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject =null;

        public IObservable<Behavior.BulletBehavior> OnBulletHit => _playerObject.OnTriggerEnterAsObservable().Where(x => x.gameObject.CompareTag("Bullet")).Select(x => x.GetComponent<Behavior.BulletBehavior>());
        
        [SerializeField] private float _moveSpeed = 0.0f;

        [SerializeField] private Animator _animator => _playerObject.GetComponent<Animator>();
        [SerializeField] private NavMeshAgent _navMeshAgent => _playerObject.GetComponent<NavMeshAgent>();
        [SerializeField] private Transform _playerTransform => _playerObject.transform;
        public float AnimatorMoveSpeed
        {
            set { _animator.SetFloat("MoveSpeed", value); }
        }

        public Vector3 Move
        {
            set {
                _navMeshAgent.Move(value * _moveSpeed);
                if(value.magnitude > 0) _playerTransform.rotation =  Quaternion.LookRotation(value);
            }
        }

        public NavMeshAgent NavMeshAgent
        {
            get { return _navMeshAgent; }
        }

    }
}