using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : WayPointpatrol
{
    private Transform target;

    void Awake()
    {
        GameEvent.gotPlayer.AddListener((player) => OnPlayerGot(player.transform));
    }

    void OnPlayerGot(Transform player)
    {
        target = player.transform;
        UpdateDestination(target);
        UpdateSpeed();
    }
}
