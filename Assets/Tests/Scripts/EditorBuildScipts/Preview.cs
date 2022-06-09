using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Material goodMat; // green
    [SerializeField] private Material badMat; // red
    [SerializeField] private List<string> snapableTags = new List<string>();

    private MeshRenderer renderer;
    private BuildSystem buildSystem;

    public bool IsSnapped { get; set; } = false;
    public bool IsFoundation { get; set; } = false;

    private void Start()
    {
        buildSystem = FindObjectOfType<BuildSystem>();
        renderer = GetComponent<MeshRenderer>();
        SwitchColor();
    }

    public void Place()
    {
        Instantiate(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void SwitchColor()
    {
        if (IsSnapped)
            renderer.material = goodMat;
        else
            renderer.material = badMat;

        if (IsFoundation)//this is the foundation rule that was added earlier
        {
            renderer.material = goodMat;
            IsSnapped = true;//we have to force this bool here, because the BuildSystem.cs requires this to be true before you can build
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (snapableTags.Contains(other.tag))
        {
            buildSystem.PauseBuildAction(true);
            transform.position = other.transform.position;
            IsSnapped = true;
            SwitchColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (snapableTags.Contains(other.tag))
        {
            IsSnapped = false;
            SwitchColor();
        }
    }
}
