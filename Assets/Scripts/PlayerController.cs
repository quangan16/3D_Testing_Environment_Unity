using System;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 inputDirection;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravityMagnitude;
    [SerializeField] private float jumpStrength;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Vector3 currentVelocity;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private float mouseSentitive;
    [SerializeField] private Camera headCam;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float airVelocity;
    public void Start()
    {
        Init();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        inputDirection = InputManager.GetInput3D();
        CheckGrounded();
        Move();
        ApplyGravity();
        Jump();
        currentVelocity = controller.velocity;
    }

    public void LateUpdate()
    {
        RotateLookWithMouse();
    }

    public void Init()
    {
       
    }

    public void CheckGrounded()
    {
        isGrounded = controller.isGrounded;
        // currentVelocity = 
    }
    //
    public void Move()
    {
       
        
         if (isGrounded)
         {
             moveDirection = (inputDirection.z * transform.forward + inputDirection.x * transform.right);
             if (moveDirection.sqrMagnitude > 1f) moveDirection.Normalize();
             controller.Move(moveDirection * (moveSpeed * Time.deltaTime));
         }
         else
         {
             controller.Move(moveDirection * (moveSpeed * Time.deltaTime * 0.6f));
         }
      

    }

    public void ApplyGravity()
    {
        if (!isGrounded)
        {
            airVelocity -= gravityMagnitude * Time.deltaTime;
        }
        else
        {
            airVelocity = -100.0f;
        }
        
        controller.Move(Vector3.up * (airVelocity * Time.deltaTime));
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            airVelocity = 4.0f;
        }

        controller.Move(Vector3.up * (airVelocity * Time.deltaTime));
    }

    [SerializeField] private float horizontal = 0f;
    [SerializeField] private float vertical = 0f;

    public void RotateLookWithMouse()
    {
        
        horizontal += Input.GetAxis("Mouse X") * mouseSentitive;
        vertical += Input.GetAxis("Mouse Y") * mouseSentitive;
        vertical = Mathf.Clamp(vertical, -90.0f, 90.0f);
        horizontal = Mathf.Repeat(horizontal, 360);
        // headCam.transform.Rotate(new Vector3(-vertical, horizontal));
        float z = headCam.transform.eulerAngles.z;
        transform.eulerAngles = new Vector3(0, horizontal, 0);
        headCam.transform.localEulerAngles  = new Vector3(-vertical,0 , 0f);
        // headCam.transform.rotation.
    }
}

[System.Serializable]
public class PlayerAnimation 
{
    [SerializeField] private Animator playerAnimator;
    
    // public void 
}

// public class ReadOnlyInpector : 