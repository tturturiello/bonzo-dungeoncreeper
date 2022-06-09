using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponTrap : Trap
{
    [SerializeField] private Collider damagePart;

    private void Start()
    {
        damagePart.enabled = false;
    }

    void FixedUpdate()
    {
        StartCoroutine(SpeedReckoner());
    }

    private IEnumerator SpeedReckoner()
    {
        float Speed;
        float UpdateDelay = 0.1f;

        YieldInstruction timedWait = new WaitForSeconds(UpdateDelay);
        Vector3 lastPosition = transform.position;
        float lastTimestamp = Time.time;

        yield return timedWait;

        var deltaPosition = (transform.position - lastPosition).magnitude;
        var deltaTime = Time.time - lastTimestamp;

        if (Mathf.Approximately(deltaPosition, 0f)) // Clean up "near-zero" displacement
            deltaPosition = 0f;

        Speed = deltaPosition / deltaTime;

        damagePart.enabled = (Speed > KillThreashHold()) || AdditionalKillCondition();
    }

    protected virtual float KillThreashHold()
    {
        return 4f;
    }

    protected virtual bool AdditionalKillCondition()
    {
        return false;
    }
}
