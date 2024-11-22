using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    private NavMeshAgent _agent;
    private Animator _animator;
    private Transform _transform;
    private float BoringTime = 5f;
    private float Timer;
    private void Start()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(target.transform.position);
        /*_animator.SetBool("IsIdle", false);
        _animator.SetBool("IsWalking", true);*/
    }

    private void Update()
    {
        //Idle et movement

        if (_agent.remainingDistance <= 0.5f)
        {
            _animator.SetBool("IsIdle", true);
            _animator.SetBool("IsWalking", false);
        }
        else
        {
            _animator.SetBool("IsIdle", false);
            _animator.SetBool("IsWalking", true);
        }

        //Different idle

        Timer -= Time.deltaTime;
        if (Timer <= 0 && !_animator.GetBool("IsWalking"))
        {
            bool IsBored = UnityEngine.Random.value > 0.5f; //J'aurais préféré Random.bool mais bon c'est stylé aussi

            _animator.SetBool("IsBored", IsBored);

            Timer = BoringTime;
        }
    }
}
