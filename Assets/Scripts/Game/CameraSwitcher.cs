using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        GameEvent.playerDead.AddListener(OnPlayerDead);
    }

    void Update()
    {
        if (PlayerInput.HasSwitchedCamera())
        {
            animator.SetBool("IsFP", !animator.GetBool("IsFP"));
            GameEvent.playerPOVSwitched.Invoke();
        }
    }

    private void OnPlayerDead()
    {
        animator.SetBool("IsDead", true);
    }

    // FIXME don't work correctly
    private IEnumerator WaitForSwitchedCamera()
    {
        yield return new WaitUntil(PlayerInput.HasSwitchedCamera);
        //yield return new WaitForEndOfFrame();
        animator.SetBool("IsFP", !animator.GetBool("IsFP"));
    }
}
