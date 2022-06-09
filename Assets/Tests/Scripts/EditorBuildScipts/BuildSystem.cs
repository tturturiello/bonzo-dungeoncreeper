using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float stickTolerance = 1.5f;
    [SerializeField] private float maxDistance = 100f;

    private GameObject previewGameObject = null;
    private Preview preview = null;
    private bool isPausing = false;

    public bool IsBuilding { get; set; } = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // rotate
        {
            previewGameObject.transform.Rotate(0, 90f, 0);
        }
        if (Input.GetKeyDown(KeyCode.C)) // cancel
        {

        }
        if (Input.GetMouseButton(0) && IsBuilding)
        {
            if (preview.IsSnapped)
            {
                CompleteBuildAction();
            }
            else
            {
                Debug.Log("Not snapped.");
            }
        }

        if (IsBuilding)
        {
            if (isPausing)
            {

                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                if (Mathf.Abs(mouseX + mouseY)/2 >= stickTolerance)
                {
                    isPausing = false;
                }
            }
            else
            {
                BuildRay();
            }
        }
    }

    internal void StartBuildAction(GameObject build)
    {
        previewGameObject = Instantiate(build, Vector3.zero, Quaternion.identity);
        preview = previewGameObject.GetComponent<Preview>();
        IsBuilding = true;
    }

    internal void PauseBuildAction(bool buildState)
    {
        isPausing = buildState;
    }

    internal void CancelBuildAction()
    {
        Destroy(previewGameObject);

        previewGameObject = null;
        preview = null;
        IsBuilding = false;
    }

    internal void CompleteBuildAction()
    {
        preview.Place();

        previewGameObject = null;
        preview = null;
        IsBuilding = false;
    }

    private void BuildRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            float y = hit.point.y + (previewGameObject.transform.localScale.y / 2f);
            Vector3 pos = new Vector3(hit.point.x, y, hit.point.z);
            previewGameObject.transform.position = pos;
            previewGameObject.transform.position = hit.point;
        }
    }
}
