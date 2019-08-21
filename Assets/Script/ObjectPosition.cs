using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public GameObject TargetController, Plane, HMD, Sphere;

    Vector3 HmdPos, PlanePos;
    int buffer = 20, num = 100, count = 0;

    void Update()
    {
        count++;

        if (count == num)
        {
            HmdPos /= num - buffer;
            PlanePos /= num - buffer;

            Debug.Log("TargetController On");
            TargetController.GetComponent<TargetController>().HmdPos = HmdPos;
            TargetController.GetComponent<TargetController>().Zoffset = 5f;
            TargetController.GetComponent<TargetController>().UpperBound = 2.5f;
            TargetController.GetComponent<TargetController>().LowerBound = -2.5f;
            TargetController.SetActive(true);

            Debug.Log("Sphere On");
            Sphere.SetActive(true);
            this.GetComponent<SphereController>().SpherePos = new Vector3(PlanePos.x, PlanePos.y, PlanePos.z + 0.15f);
            this.GetComponent<SphereController>().ResetPosition();

            Destroy(this);
        }
        else if (count >= buffer)
        {
            HmdPos += HMD.transform.position;
            PlanePos += Plane.transform.position;
        }
    }
}
