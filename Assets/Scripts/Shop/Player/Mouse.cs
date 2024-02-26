using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseXandY,
        MouseX,
        MouseY
    }

    public float sensitivityHor = 6f;
    public float sensitivityVert = 6f;
    private float _minVert = -15f;
    private float _maxVert = 15f;
    private float _rotationX;
    public RotationAxis axis = RotationAxis.MouseXandY;

    private void Start()
    {
        var body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    private void Update()
    {
        if (axis == RotationAxis.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*sensitivityHor,0);
        }

        if (axis == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);
            var rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);
            var delta = Input.GetAxis("Mouse X") * sensitivityHor;
            var rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
