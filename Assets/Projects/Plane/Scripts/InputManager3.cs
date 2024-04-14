using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager3 : MonoBehaviour
{
    public Plane plane;

    public Rigidbody ball;

    public float moveSpeed;

    public bool isMouseDown = false;

    private Ray ray;
    public InputActionReference stop;
    private bool hasRotated = false;

    [SerializeField] private float rotateSpeed;

    public Coroutine temp;
    // Start is called before the first frame update
    void Start()
    {
        plane = GameController.Instance.plane;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            isMouseDown = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        ExirCoroutine();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (isMouseDown && plane.Raycast(ray, out float enter) &&
            Vector3.Distance(ball.transform.position, ray.GetPoint(enter)) > 0.3f)
        {
            Vector3 moveDirection  = ray.GetPoint(enter) - ball.transform.position;
            moveDirection.y = 0f;
            ball.MovePosition(ball.transform.position + moveDirection.normalized *Time.fixedDeltaTime  * moveSpeed * Vector3.Distance(ball.transform.position,
                ray.GetPoint(enter)));
            isMouseDown = false;
            ExirCoroutine();
            // if(hasRotated == true) StopAllCoroutines();
            if(hasRotated == false  ) temp = StartCoroutine(RotateToMousePos(moveDirection, 0.1f)); 
           
           
        }
    }

    public void ExirCoroutine()
    {
       
        if(temp != null)
        {
            StopCoroutine(temp);
            temp = null;
            hasRotated = false;
        }
    }

    IEnumerator RotateToMousePos(Vector3 targetDir, float rotationTime)
    {
        hasRotated = true;
        while (Quaternion.Angle(ball.transform.rotation, Quaternion.LookRotation(targetDir))> 0.1f)
        {
            
            ball.transform.rotation = Quaternion.Slerp(ball.transform.rotation, Quaternion.LookRotation(targetDir),
                Time.deltaTime * rotateSpeed);
            yield return null;
        }

        hasRotated = false;
    }
    
    

}

