using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class BoucingBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 initDirection;
    [SerializeField] private float initStrength;
    [SerializeField] private Vector3 lastVelocity;
    void Awake(){
        rb = GetComponent<Rigidbody>();
        initDirection = new Vector3(1f,.3f,.5f);
        initStrength = 2f;
    }
    // Start is called before the first frame update
    void Start()
    {
         rb.velocity = initDirection*initStrength;
        // rb.MovePosition(transform.position + (initDirection * initStrength)*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = initDirection*initStrength;
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision col){
        Debug.Log("ell");
        var speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, col.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 10f);
    }
}
