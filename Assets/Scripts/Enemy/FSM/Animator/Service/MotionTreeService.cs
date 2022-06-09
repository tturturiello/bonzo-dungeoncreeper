using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTreeService
{
    Animator animator;

    private static MotionTreeService _instance;

    public MotionTreeService(Animator animator)
    {
        this.animator = animator;
    }

    public static MotionTreeService Instance(Animator animator)
    {
        if (_instance == null)
        {
            return new MotionTreeService(animator);
        }
        return _instance;
    }

    public void Walk()
    {
        animator.SetBool(AnimatorParameter.Transition.IS_COMBACT_STATE, false);
        animator.SetFloat(AnimatorParameter.Motion.Parameter, 
            (int)AnimatorParameter.Motion.MotionTree.WALK);
    }

    public void WalkArmed()
    {
        animator.SetBool(AnimatorParameter.Transition.IS_COMBACT_STATE, false);
        animator.SetFloat(AnimatorParameter.Motion.Parameter,
            (int)AnimatorParameter.Motion.MotionTree.WALK_ARMED);
    }
}
