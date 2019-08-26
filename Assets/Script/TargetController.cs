using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject Target;
    public Material TargetColor;
    public Vector3 HmdPos, HmdFoward, HmdRight, HmdUp, TargetPos;
    public Quaternion TargetQuat;
    public bool TargetCollision;
    public float UpperBound, LowerBound, Zoffset;
    public int TargetVelocity;

    GameObject TargetClone;
    
    void Start()
    {
        TargetVelocity = 1;
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
        TargetPos = HmdPos + Random.Range(LowerBound, UpperBound) * HmdRight + Random.Range(LowerBound, UpperBound) * HmdUp + Random.Range(Zoffset + LowerBound, Zoffset + UpperBound) * HmdFoward;
        TargetQuat = Quaternion.LookRotation(HmdPos - TargetPos);

        TargetClone = Instantiate(Target, TargetPos, TargetQuat);
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
