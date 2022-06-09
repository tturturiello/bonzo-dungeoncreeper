using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsContainer : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    private int wayPointIndex = 0;

    public Transform Current { get => waypoints[wayPointIndex]; }
    public Transform Next
    {
        get
        {
            wayPointIndex = (wayPointIndex + 1) % waypoints.Length;
            return waypoints[wayPointIndex];
        }
    }
}
