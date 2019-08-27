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

        HmdPos = new Vector3(-0.211514f, 1.123112f, 0.253498f);
        HmdFoward = new Vector3(0.109726f, -0.07553031f, 0.9909914f);
        HmdRight = new Vector3(0.9930496f, 0.04732004f, -0.1065138f);
        HmdUp = new Vector3(-0.03885253f, 0.9958077f, 0.08016561f);
        PlanePos = new Vector3(0.08016561f, 1.147545f, 0.4755763f);

        if (Second)
        {
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
        TargetController.GetComponent<TargetController>().Zoffset = 3f;
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
