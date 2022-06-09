using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RagdollManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private Collider[] ignoredCollieders = null;
    [SerializeField] private GameObject owner = null;
    //[SerializeField] private AudioSource death;

    private List<Rigidbody> ragdollBoxes;
    private List<Collider> ragdollColliders;
    private bool hasFallen = false;

    void Awake()
    {
        ragdollBoxes = GetComponentsInChildren<Rigidbody>(true).ToList();
        ragdollColliders = GetComponentsInChildren<Collider>(true).ToList();

        ragdollBoxes.RemoveAll((obj) => 
            obj.CompareTag("Weapon") || obj.CompareTag("Enemy") || obj.CompareTag("Player"));

        ragdollColliders.RemoveAll((obj) => 
            obj.CompareTag("Weapon") || obj.CompareTag("Enemy") || obj.CompareTag("Player"));

        /*
         ragdollBoxes.RemoveAll((obj) =>
            obj.gameObject.tag == "Weapon" || obj.gameObject.tag == "Enemy" || obj.gameObject.tag == "Player");

        ragdollColliders.RemoveAll((obj) =>
            obj.gameObject.tag == "Weapon" || obj.gameObject.tag == "Enemy" || obj.gameObject.tag == "Player");
         */

        ToggleRagdoll(false);

        //Invoke(nameof(Die), 0f); // TOGGLE TO TEST

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponentInParent<Rigidbody>().isKinematic = true;
        ToggleRagdoll(true);
        RemoveUselessComponents();

        bool isPlayer = GetComponentInParent<PlayerMovement>() != null;
        if (isPlayer)
        {
            GameEvent.playerDead.Invoke();
        }
        else
        {
            GameEvent.enemyDead.Invoke(owner);
        }
    }

    private void RemoveUselessComponents()
    {
        foreach (var coll in gameObject.GetComponentsInParent<Collider>())
        {
            Destroy(coll);
        }
    }

    private void ToggleRagdoll(bool state)
    {
        animator.enabled = !state;
        hasFallen = state;

        foreach (Rigidbody rb in ragdollBoxes)
        {
            rb.isKinematic = !state; // phisics will effect to the rigid bodies
        }

        foreach (Collider coll in ragdollColliders)
        {
            coll.enabled = state; // activate ragdoll's colliders
        }

        foreach (Collider ignored in ignoredCollieders)
        {
            ignored.enabled = true;
        }
    }
}
