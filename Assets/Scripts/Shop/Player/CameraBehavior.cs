using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);
    private Transform target;


    private void Start()
    {
        target = GameObject.Find("X Bot (1)").transform;
    }

    private void LateUpdate()
    {
        transform.position = target.TransformPoint(camOffset);
        transform.LookAt(target);
    }
}
