using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class NPC : MonoBehaviour
{
    NavMeshAgent agent;
    StateMachine stateMachine;
    StatePatrol patrolState;
    StateChase chaseState;
    
    public float visionRange = 6f;
    public LayerMask visionMask;
    public Transform player;
    public Transform[] patrolPoints;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = GetComponent<StateMachine>();
        patrolState = new StatePatrol(this, patrolPoints);
        chaseState = new StateChase(this);
        stateMachine.SetDefaultState(patrolState);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void SetPatrolState()
    {
        stateMachine.ChangeState(patrolState);
    }

    public void SetChaseState(Transform target)
    {
        chaseState.SetTarget(target);
        stateMachine.ChangeState(chaseState);
    }

    public void SetDestination(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
