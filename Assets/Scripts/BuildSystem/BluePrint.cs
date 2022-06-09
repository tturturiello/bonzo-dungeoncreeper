using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private RaycastHit hit;
    private Vector3 movePoint;
    private Rotator rotator = new Rotator();
    private Vector2 centerOfScreen = new Vector3();

    void Awake()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        centerOfScreen.Set(x, y);
    }

    void FixedUpdate()
    {
        RayCastProjection();
    }

    private void Update()
    {
        if (PlayerInput.IsOnBuildActionPressed())
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
            GameEvent.trapBuilt.Invoke();
        }

        if (PlayerInput.HasRotatedObject())
        {
            transform.Rotate(rotator.Rotate());
        }
        //StartCoroutine(WaitForRotation());
    }

    IEnumerator WaitForRotation()
    {
        yield return new WaitUntil(PlayerInput.HasRotatedObject);
        transform.Rotate(rotator.Rotate());
    }

    private void RayCastProjection()
    {
        Ray ray = Camera.main.ScreenPointToRay(centerOfScreen);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int layerMask = (1 << 8); // it casts rays only against colliders in layer 8 (environment).
        float maxDistance = 20.0f;

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            //transform.position = hit.point;
            transform.position = Vector3.Lerp(transform.position, hit.point, 0.25f);
        }
    }
}
