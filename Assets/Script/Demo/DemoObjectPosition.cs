using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoObjectPosition : MonoBehaviour
{
    public GameObject TargetController, Plane, HMD, Sphere;

    public Vector3 HmdPos, HmdFoward, HmdRight, HmdUp, PlanePos;
    public bool Second;
    int buffer = 250, num = 1000, count = 0;

    private void Start()
    {
        HmdPos = Vector3.zero;
        HmdFoward = Vector3.zero;
        HmdRight = Vector3.zero;
        HmdUp = Vector3.zero;
        PlanePos = Vector3.zero;
 
        if (Second)
        {
            HmdPos = new Vector3(0.134612f, 1.247254f, 0.2088506f);
            HmdFoward = new Vector3(0.05196295f, - 0.08140586f, 0.9952887f);
            HmdRight = new Vector3(0.9985265f, 0.01886023f, - 0.05057435f);
            HmdUp = new Vector3(-0.01467216f, 0.9964612f, 0.08225657f);

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
        TargetController.GetComponent<DemoTargetController>().HmdPos = HmdPos;
        TargetController.GetComponent<DemoTargetController>().HmdFoward = HmdFoward;
        TargetController.GetComponent<DemoTargetController>().HmdRight = HmdRight;
        TargetController.GetComponent<DemoTargetController>().HmdUp = HmdUp;
        TargetController.GetComponent<DemoTargetController>().Xoffset = -1f;
        TargetController.GetComponent<DemoTargetController>().Yoffset = -1f;
        TargetController.GetComponent<DemoTargetController>().Zoffset = 4f;
        TargetController.GetComponent<DemoTargetController>().UpperBound = 1f;
        TargetController.GetComponent<DemoTargetController>().LowerBound = -1f;

        Debug.Log("Sphere On");
        Sphere.SetActive(true);
        //Vector3 TempPos = 0.4f * (PlanePos - HmdPos);
        //this.GetComponent<SphereController>().SpherePos = HmdPos + TempPos + new Vector3(0, 0, TempPos.magnitude); //new Vector3(PlanePos.x, PlanePos.y, PlanePos.z + 0.15f);
        this.GetComponent<DemoSphereController>().SpherePos = HmdPos + new Vector3(0.2f, -0.2f, 0.45f);
        this.GetComponent<DemoSphereController>().HmdFoward = HmdFoward;
        this.GetComponent<DemoSphereController>().ResetPosition();

        HMD.transform.position = HmdPos;

        Destroy(this);
    }
}
