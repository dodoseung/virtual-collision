using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTargetController : MonoBehaviour
{
    public GameObject Target, TestController;
    public Material TargetColor;
    public Vector3 HmdPos, HmdFoward, HmdRight, HmdUp, TargetPos;
    public Quaternion TargetQuat;
    public bool TargetCollision;
    public float UpperBound, LowerBound, Xoffset, Yoffset, Zoffset, XRandom, YRandom, ZRandom;
    public int TargetVelocity, TargetCount;

    GameObject TargetClone;
    
    void Start()
    {
        TargetVelocity = 1;
        TargetCount = 0;
        TestController.GetComponent<DemoMainController>().VariableSetup();
        SpawnTarget();
    }

    void Update()
    {
        TargetCollision = TargetClone.GetComponent<Target>().CollisionDetection;

        if (TargetCollision)
        {
            Destroy(TargetClone);
            SpawnTarget();
        }

        TargetVelocityChanger();
    }

    void SpawnTarget()
    {
        /*
        if (TargetCount % 10 == 0)
        {
            XRandom = Random.Range(Xoffset + LowerBound, Xoffset + UpperBound);
            YRandom = Random.Range(Yoffset + LowerBound, Yoffset + UpperBound);
            ZRandom = Random.Range(Zoffset + LowerBound, Zoffset + UpperBound);

            TargetPos = HmdPos + YRandom * HmdRight + YRandom * HmdUp + ZRandom * HmdFoward;
            TargetQuat = Quaternion.LookRotation(HmdPos - TargetPos);
        }
        */
        TargetPos = HmdPos + new Vector3(-1.3f, -2f, 5f);
        TargetQuat = Quaternion.LookRotation(HmdPos - TargetPos);

        TargetClone = Instantiate(Target, TargetPos, TargetQuat);
        Invoke("TargetColliderActive", 0.5f);

        TargetCount++;
    }

    void TargetColliderActive()
    {
        TargetClone.GetComponent<BoxCollider>().enabled = true;
    }

    void TargetVelocityChanger()
    {
        TargetClone.GetComponent<Target>().TargetVelocity = TargetVelocity;

        if (TargetVelocity == 1)
        {
            TargetColor.color = Color.green;
        }
        else if (TargetVelocity == 2)
        {
            TargetColor.color = Color.red;
        }
        else
        {
            TargetColor.color = Color.black;
        }
    }
}
