using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public Plane plane;
    public GameObject plan;
    public GameObject sphere;

    public Vector3 planeNormal;
    // Start is called before the first frame update
    
    void OnEnable()
    {
        plane = new Plane(Vector3.up, Vector3.zero);
        planeNormal = plane.normal;
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        plane.normal = planeNormal;
        plan.transform.rotation = Quaternion.LookRotation(plane.normal);
        sphere.GetComponent<MeshRenderer>().material = (plane.GetSide(sphere.transform.position))
            ? Resources.Load("GreenMat") as Material
            :  Resources.Load("RedMat") as Material;
    }
}
