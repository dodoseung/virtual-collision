using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public GameObject TargetController, Plane, HMD, Sphere;

    Vector3 HmdPos, PlanePos;
    int buffer = 200, num = 1000, count = 0;

    void Update()
    {
        count++;

        if (count == num)
        {
            HmdPos /= num - buffer;
            PlanePos /= num - buffer;

            Debug.Log("TargetController On");
            TargetController.SetActive(true);
            TargetController.GetComponent<TargetController>().Zoffset = 5f;
            TargetController.GetComponent<TargetController>().UpperBound = 2.5f;
            TargetController.GetComponent<TargetController>().LowerBound = -2.5f;

            Debug.Log("Sphere On");
            Sphere.SetActive(true);
            Sphere.transform.position = new Vector3(PlanePos.x, PlanePos.y, PlanePos.z + 0.15f);

            this.GetComponent<SphereController>().SpherePos = new Vector3(PlanePos.x, PlanePos.y, PlanePos.z + 0.15f);

            Destroy(this);
        }
        else if (count >= buffer)
        {
            HmdPos += HMD.transform.position;
            PlanePos += Plane.transform.position;
        }
    }
}
