using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

	 private float objectSpeed;
	[SerializeField] private float directionX;
	[SerializeField] private float directionZ;
	private MeshRenderer mr;

	[SerializeField] private Rigidbody rb;

	[SerializeField] private float jumpForce = 200f;
	// Start is called before the first frame update

	void Awake(){
		rb = GetComponent<Rigidbody>();
		mr = GetComponent<MeshRenderer>();
	}
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		directionX = Input.GetAxisRaw("Horizontal");
		directionZ = Input.GetAxisRaw("Vertical");
		if (gameObject.name == "TranslateBall")
		{
			objectSpeed = 10f;
			MoveWithTranslate();

		}
		if (gameObject.name == "PositionBall")
		{
			objectSpeed = 10f;
			MoveWithChangePosition();
		}


		Jump();

	}

	void FixedUpdate()
	{
		if (gameObject.name == "AddForceBall")
		{
			objectSpeed = 100f;
			MoveWithAddForce();
		}
		if (gameObject.name == "VelocityBall")
		{
			objectSpeed = 100f;
			MoveWithVelocity();
		}


		if (gameObject.name == "MovePositionBall")
		{
			objectSpeed = 10f;
			MoveWithMovePositionMethod();
		}



	}
	//_____________Transform Manipulation______________
	void MoveWithChangePosition()
	{
		transform.position += new Vector3(directionX, 0, directionZ) * objectSpeed * Time.deltaTime;
	}
	void MoveWithTranslate()
	{

		gameObject.transform.Translate(new Vector3(directionX, 0, directionZ) * objectSpeed * Time.deltaTime, Space.World);
	}


	//_______________Rigidbody Manipulation________________
	void MoveWithAddForce()
	{
		rb.AddForce(new Vector3(directionX, 0, directionZ) * objectSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
	}

	void MoveWithVelocity()
	{
		rb.velocity = Vector3.forward * objectSpeed *Time.fixedDeltaTime;
		// rb.velocity += new Vector3(directionX, 0, directionZ) * objectSpeed* Time.fixedDeltaTime;

	}
	//_______________Rigidbody Transform Manipulation________________
	//Should only use to manipulate position of kinematic object
	void MoveWithMovePositionMethod()
	{
		rb.MovePosition(transform.position + new Vector3(directionX, -9.8f, directionZ) * objectSpeed * Time.fixedDeltaTime);
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("Jumped");
			rb.AddForce(Vector3.up * jumpForce);
		}
	}

	void OnCollisionEnter(Collision collision)
	{

		Debug.Log(collision.gameObject.name);
	}

	void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.name == "CollisionWall"){
			mr.material.color = Color.blue;
		}
		
		Debug.Log("In Collision");
	}

	void OnCollisionExit(Collision collision)
	{
		if(collision.gameObject.name == "CollisionWall"){
			mr.material.color = Color.white;
		}
		Debug.Log("In Collision");
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Triggered");
		mr.material.color = Color.red;
	}


}

