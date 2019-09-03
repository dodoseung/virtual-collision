﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
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
            HmdPos = new Vector3(-0.1659156f, 1.215874f, 0.3316885f);
            HmdFoward = new Vector3(0.05342712f, - 0.08646919f, 0.9942963f);
            HmdRight = new Vector3(0.9974918f, - 0.03238526f, - 0.05629414f);
            HmdUp = new Vector3(0.03744887f, 0.9953464f, 0.08449227f);

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
        //Vector3 TempPos = 0.4f * (PlanePos - HmdPos);
        //this.GetComponent<SphereController>().SpherePos = HmdPos + TempPos + new Vector3(0, 0, TempPos.magnitude); //new Vector3(PlanePos.x, PlanePos.y, PlanePos.z + 0.15f);
        this.GetComponent<SphereController>().SpherePos = HmdPos + new Vector3(0.2f, -0.2f, 0.45f);
        this.GetComponent<SphereController>().HmdFoward = HmdFoward;
        this.GetComponent<SphereController>().ResetPosition();

        Destroy(this);
    }
}
