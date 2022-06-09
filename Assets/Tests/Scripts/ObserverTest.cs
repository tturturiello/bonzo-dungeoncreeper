using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObserverTest : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform owner;

    [SerializeField] private GameObject beginRay;
    [SerializeField] private GameObject endRay;

    private bool _isPlayerInPOVRange = false;
    private bool _isPlayerSeen = false;

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
        GetComponent<Collider>().enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Entered");
        }
        Debug.Log(other.gameObject.tag);
        _isPlayerInPOVRange = other.gameObject.tag == "Player";
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
            _isPlayerInPOVRange = false;
    }

    void Update()
    {
        if (_isPlayerInPOVRange)
        {
            beginRay.transform.position = owner.transform.position + Vector3.up;
            endRay.transform.position = player.position + Vector3.up;

            Vector3 direction = player.position - owner.transform.position + Vector3.up;

            if (Physics.Raycast(owner.transform.position, direction, out RaycastHit raycastHit))
            {
                Rigidbody hitObject = raycastHit.rigidbody;

                if (hitObject != null)
                {
                    if (hitObject.transform == player)
                    {
                        _isPlayerSeen = true; // See player
                    }
                    return;
                }
                _isPlayerSeen = false; // Can't see player
            }
        }
    }
}
