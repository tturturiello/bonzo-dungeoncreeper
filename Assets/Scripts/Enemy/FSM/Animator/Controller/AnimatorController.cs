using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimatorController : MonoBehaviour
{
    [SerializeField] protected AnimatorService animatorService;
    [SerializeField] protected GameObject owner;

    //protected static AnimatorService animatorService;

    protected void Start()
    {
        animatorService.Animator.applyRootMotion = true;
    }

    protected bool IsSameGameObject(int ID)
    {
        return owner.GetInstanceID().Equals(ID);
    }
}
