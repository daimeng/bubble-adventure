using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float minY = 0;
    public float maxY = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = new Vector3(target.position.x, Math.Clamp(target.position.y, minY, maxY), -10);
    }
}
