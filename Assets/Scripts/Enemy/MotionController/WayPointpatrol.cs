using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class WayPointpatrol : MonoBehaviour
{
    [SerializeField] protected WaypointsContainer waypointsContainer;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    [SerializeField] protected Animator animator;

    protected void UpdateSpeed()
    {
        navMeshAgent.speed = animator.velocity.magnitude;
    }

    protected void UpdateDestination(Transform destination)
    {
        navMeshAgent.SetDestination(destination.position);
    }
}
