using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            z -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z += 1;
        }

        transform.position += new Vector3(x, 0, z).normalized * 10 * Time.deltaTime;
        //var lookAt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.up = lookAt - transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PAIWUERGFOERWIUGH");
    }
}
