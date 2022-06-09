using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleService
{
    private Animator animator;
    private ToggleGameObject weaponToggler;

    private static IdleService _instance;

    public IdleService(Animator animator, ToggleGameObject weaponToggler)
    {
        this.animator = animator;
        this.weaponToggler = weaponToggler;
    }

    public static IdleService Instance(Animator animator, ToggleGameObject weaponToggler)
    {
        if (_instance == null)
        {
            return new IdleService(animator, weaponToggler);
        }
        return _instance;
    }

    public void Victory()
    {
        weaponToggler.Toggle(false);
        animator.SetBool(AnimatorParameter.Transition.IS_IDLE_STATE, false);
        animator.SetFloat(AnimatorParameter.Reaction.Parameter, 
            (int)AnimatorParameter.Reaction.ReactionTree.VICTORY);

        animator.SetTrigger(AnimatorParameter.Transition.IDLE_TRIGGER);
    }

    public void Indicate()
    {
        weaponToggler.Toggle(false);
        animator.SetFloat(AnimatorParameter.Reaction.Parameter,
            (int)AnimatorParameter.Reaction.ReactionTree.INDICATE);
        animator.SetBool(AnimatorParameter.Transition.IS_IDLE_STATE, false);

        animator.SetTrigger(AnimatorParameter.Transition.IDLE_TRIGGER);
    }

    public void Wait()
    {
        weaponToggler.Toggle(false);
        animator.SetBool(AnimatorParameter.Transition.IS_IDLE_STATE, true);

        animator.SetFloat(AnimatorParameter.Reaction.Parameter,
            (int)AnimatorParameter.Reaction.ReactionTree.IDLE_TREE);

        animator.SetFloat(AnimatorParameter.Reaction.Idle.Parameter,
            (int)AnimatorParameter.Reaction.Idle.IdleTree.FIRST);
            //Random.Range(
            //    (int)AnimatorParameter.Reaction.Idle.IdleTree.FIRST,
            //    (int)AnimatorParameter.Reaction.Idle.IdleTree.LAST));
    }

    public void Lost()
    {
        weaponToggler.Toggle(false);
        animator.SetBool(AnimatorParameter.Transition.IS_IDLE_STATE, false);

        animator.SetFloat(AnimatorParameter.Reaction.Parameter,
            (int)AnimatorParameter.Reaction.ReactionTree.SEEK);

        animator.SetTrigger(AnimatorParameter.Transition.IDLE_TRIGGER);
    }
}
