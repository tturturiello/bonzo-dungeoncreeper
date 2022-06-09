using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombactTreeService
{
    private Animator animator;
    private ToggleGameObject weaponToggler;
    private readonly int weaponType;

    private static CombactTreeService _instance;

    public CombactTreeService(Animator animator, int weaponType, ToggleGameObject weaponToggler)
    {
        this.animator = animator;
        this.weaponToggler = weaponToggler;
        this.weaponType = weaponType;
    }

    public static CombactTreeService Instance(Animator animator, int weaponType, ToggleGameObject weapon)
    {
        if (_instance == null)
        {
            return new CombactTreeService(animator, weaponType, weapon);
        }
        return _instance;
    }

    public void Run()
    {
        weaponToggler.Toggle(false);
        animator.SetBool(AnimatorParameter.Transition.IS_COMBACT_STATE, false);
        animator.SetFloat(AnimatorParameter.Motion.Parameter, 
                (int)AnimatorParameter.Motion.MotionTree.RUN);
    }

    public void Attack()
    {
        animator.SetBool(AnimatorParameter.Transition.IS_COMBACT_STATE, true);
        animator.SetFloat(AnimatorParameter.Combact.GetParameter(weaponType),
            AnimatorParameter.Combact.GetRandomAttack(weaponType));

        weaponToggler.Toggle(true);
    }

    public void WalkForward()
    {
        animator.SetBool(AnimatorParameter.Transition.IS_COMBACT_STATE, false);
        animator.SetFloat(AnimatorParameter.Motion.Parameter, 
            (int)AnimatorParameter.Motion.MotionTree.WALK_ARMED);
    }
}
