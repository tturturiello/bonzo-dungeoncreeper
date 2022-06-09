using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : WayPointpatrol
{
    void Start()
    {
        UpdateDestination(waypointsContainer.Current);
    }

    void Update()
    {
        UpdateSpeed();
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            UpdateDestination(waypointsContainer.Next);
        }
    }
}
