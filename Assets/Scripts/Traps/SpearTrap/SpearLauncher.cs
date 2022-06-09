using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: azionare in modo attivo la trappola: o ray cast o una label a true
// TODO: ESCLUDERE IL MURO SU CUI E' APPOGGIATA
// TODO: Spear dovrebbe venir assunta a runtime
public class SpearLauncher : Trap, IInventoryItem
{
    [SerializeField] private Rigidbody spear;

    [SerializeField] private Sprite image;

    [SerializeField] private Transform forward;

    [SerializeField] private GameObject u0;
    [SerializeField] private GameObject u1;

    [SerializeField] private int intensity = 25;

    private Vector3 direction;

    public Sprite Image => image;

    public string Name => "SpearLauncher";

    public BuildSystem.ItemMask UID => BuildSystem.ItemMask.SPEAR_LAUNCHER;

    public bool IsMemberOfTrap()
        => BuildSystem.InventoryMask == (int)BuildSystem.TrapMask.SPEAR_TRAP;

    void Start()
    {
        direction = forward.position - transform.position;
        //Invoke(nameof(Shoot), 2f); // TOGGLE TO TEST
    }

    void Update()
    {


        //int layerMask = 1 << 10 + 1 << 8;

        if (Physics.Raycast(forward.position, direction, out RaycastHit hit))
        //if (Physics.Raycast(forward.position, direction, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            //Debug.DrawRay(forward.position, direction * hit.distance, Color.red);
            u0.transform.position = gameObject.transform.position;
            u1.transform.position = hit.point;

            //Debug.Log("AAA");
            Rigidbody hitObject = hit.rigidbody;

            if (hitObject != null)
            {
                bool isTarget = hitObject.gameObject.tag == "Enemy" 
                    || hitObject.gameObject.tag == "Player";

                //bool isTarget = hitObject.gameObject.layer == 10;
                //Shoot();

                Debug.Log(hitObject.gameObject.tag);

                if (isTarget)
                {
                    Shoot();
                    AudioManager.AudioEvent.spearThrown.Invoke(gameObject);
                }
                return;
            }
        }
    }

    void Shoot()
    {
        spear.GetComponent<Rigidbody>().velocity = direction * intensity;
        GetComponent<SpearLauncher>().enabled = false;
    }

}
