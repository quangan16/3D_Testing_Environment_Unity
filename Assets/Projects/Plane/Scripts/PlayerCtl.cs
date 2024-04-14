using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtl : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float moveSpeed;

    private bool canJump;
    private bool canMove;
    public InputActionReference movementInput;
    public Vector2 moveDirection;

    public float gravityMagnitude;
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyGravity();
        Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    public void ApplyGravity()
    {
        rb.MovePosition(new Vector3(0, 0, -gravityMagnitude));
    }

   
    public void Move()
    {
        moveDirection = movementInput.action.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y);
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * moveSpeed);
    }
}
