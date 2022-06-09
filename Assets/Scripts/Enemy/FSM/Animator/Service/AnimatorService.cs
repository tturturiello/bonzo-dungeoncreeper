using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorService : MonoBehaviour
{
    //private static AnimatorService _instance = null;

    [SerializeField] private Animator animator;
    [SerializeField] private ToggleGameObject weaponToggler;
    [SerializeField] private int weaponType;

    private CombactTreeService combact;
    private MotionTreeService motion;
    private IdleService idle;

    public CombactTreeService Combact { get => combact; }
    public MotionTreeService Motion { get => motion; }
    public IdleService Idle { get => idle; }
    public Animator Animator { get => animator; }

    void Awake()
    {
        //combact = CombactTreeService.Instance(animator, weaponType, weaponToggler);
        //idle = IdleService.Instance(animator, weaponToggler);
        //motion = MotionTreeService.Instance(animator);

        combact = new CombactTreeService(animator, weaponType, weaponToggler);
        idle = new IdleService(animator, weaponToggler);
        motion = new MotionTreeService(animator);
    }
}
