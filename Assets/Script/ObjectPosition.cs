using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public GameObject TargetController, Plane, HMD, Sphere;

    public Vector3 HmdPos, HmdFoward, HmdRight, HmdUp, PlanePos;
    public bool Second;
    int buffer = 500, num = 1500, count = 0;

    private void Start()
    {
        HmdPos = Vector3.zero;
        HmdFoward = Vector3.zero;
        HmdRight = Vector3.zero;
        HmdUp = Vector3.zero;
        PlanePos = Vector3.zero;
 
        if (Second)
        {
            HmdPos = new Vector3(-0.2111456f, 1.244039f, 0.3260671f);
            HmdFoward = new Vector3(0.052163f, 0.05381452f, 0.9964519f);
            HmdRight = new Vector3(0.9983464f, 0.01219775f, -0.05255679f);
            HmdUp = new Vector3(-0.0147833f, 0.9977602f, -0.05306929f);
            PlanePos = new Vector3(-0.002709893f, 1.144056f, 0.6387287f);

            SetPosition();
        }
    }

    void Update()
    {
        if (count >= buffer)
        {
            HmdPos += HMD.transform.position; 
            HmdFoward += HMD.transform.forward;
            HmdRight += HMD.transform.right;
            HmdUp += HMD.transform.up;
            PlanePos += Plane.transform.position;
        }

        count++;

        if (count == num)
        {
            HmdPos /= num - buffer;
            HmdFoward /= num - buffer;
            HmdRight /= num - buffer;
            HmdUp /= num - buffer;
            PlanePos /= num - buffer;

            SetPosition();
        }
        
    }

    void SetPosition()
    {
        Debug.Log("TargetController On");
        TargetController.SetActive(true);
        TargetController.GetComponent<TargetController>().HmdPos = HmdPos;
        TargetController.GetComponent<TargetController>().HmdFoward = HmdFoward;
        TargetController.GetComponent<TargetController>().HmdRight = HmdRight;
        TargetController.GetComponent<TargetController>().HmdUp = HmdUp;
        TargetController.GetComponent<TargetController>().Xoffset = -1f;
        TargetController.GetComponent<TargetController>().Yoffset = -1f;
        TargetController.GetComponent<TargetController>().Zoffset = 4f;
        TargetController.GetComponent<TargetController>().UpperBound = 1f;
        TargetController.GetComponent<TargetController>().LowerBound = -1f;

        Debug.Log("Sphere On");
        Sphere.SetActive(true);
        this.GetComponent<SphereController>().SpherePos = new Vector3(PlanePos.x, PlanePos.y, PlanePos.z + 0.15f);
        this.GetComponent<SphereController>().HmdFoward = HmdFoward;
        this.GetComponent<SphereController>().ResetPosition();

        Destroy(this);
    }
}
