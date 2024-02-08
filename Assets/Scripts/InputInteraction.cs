using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInteraction : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;

    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //    
    // }

    public void RotateWithMouse()
    {
        
    }

    public void OnMouseDrag()
    {
        Vector3 rotateDirection = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        // if(rotateDirection.magnitude>=10.0f) rotateDirection.Normalize();
        // Vector3 rotateDirection = InputManager.GetMouseDragInput();
        // transform.Rotate(new Vector3(rotateDirection.y, -rotateDirection.x, 0) * rotateSpeed, Space.World);
        rb.AddTorque(new Vector3(rotateDirection.y, -rotateDirection.x, 0) * rotateSpeed, ForceMode.Force);
    }
}


