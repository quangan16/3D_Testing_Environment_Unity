using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    
    [SerializeField, Range(0, 100.0f)] private float maxMoveSpeed;
    [SerializeField, Range(0, 100.0f)] private float maxAcceleration;
    [SerializeField] private Vector3 currentVelocity = Vector3.zero;
    [SerializeField] private Rigidbody rb;
    

    public void Update()
    {
        GetInput();
    }
    public void GetInput()
    {
        Vector2 input = GetNormalizedInput();
        
        Vector3 direction =new Vector3( input.x, 0, input.y);
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        Vector3 desiredVelocity = direction * maxMoveSpeed;
        if (currentVelocity.x < desiredVelocity.x)
        {
            // currentVelocity.x += maxSpeedChange;
            currentVelocity.x = Mathf.Min(desiredVelocity.x, currentVelocity.x + maxSpeedChange);
        }
        else if (currentVelocity.x > desiredVelocity.x)
        {
            //TODO be ok
            //FIXME ok
            currentVelocity.x = Mathf.Max(desiredVelocity.x, currentVelocity.x - maxSpeedChange);
        }

        if (currentVelocity.z < desiredVelocity.z)
        {
            currentVelocity.z = Mathf.Min(desiredVelocity.z, currentVelocity.z + maxSpeedChange);
        }
        else if (currentVelocity.z > desiredVelocity.z)
        {
            currentVelocity.z = Mathf.Min(desiredVelocity.z, currentVelocity.z - maxSpeedChange);
        }

        // currentVelocity.x = Mathf.MoveTowards(currentVelocity.z, desiredVelocity.z, maxSpeedChange);
        // currentVelocity.z = Mathf.MoveTowards(currentVelocity.z, desiredVelocity.z, maxSpeedChange);
        
        Vector3 displacement = currentVelocity * Time.deltaTime;
        transform.localPosition += displacement;

    }

    // public void Move()
    // {
    //     // rb.AddForce(displacement * moveSpeed * Time.deltaTime, ForceMode.Impulse);
    //     
    // }


    public Vector2 GetNormalizedInput()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        return playerInput;
    }
}
