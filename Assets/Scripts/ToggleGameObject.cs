using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private bool activate;

    void Start()
    {
        Toggle(activate);
    }

    public void Toggle(bool active)
    {
        target.SetActive(active);
    }
}
