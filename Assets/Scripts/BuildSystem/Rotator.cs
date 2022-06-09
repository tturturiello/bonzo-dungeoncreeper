using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator
{
    private const int size = 7;
    private static readonly Vector3[] rotations = { new Vector3(0, 0, 0),
       new Vector3(0, 90, 0), new Vector3(0, 0, 90), new Vector3(90, 0, 0),
       new Vector3(90, 0, 90), new Vector3(90, 90, 90), new Vector3(90, 90, 0) };

    private int cnt = 0;
    public Vector3 Rotation
    {
        get
        {
            return rotations[cnt % size];
        }
    }

    public Vector3 Rotate()
    {
        cnt++;
        return Rotation;
    }
}
