using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject Target;
    public Material TargetColor;
    public Vector3 TargetPos;
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
    }

    void SpawnTarget()
    {
        TargetPos = new Vector3(Random.Range(LowerBound, UpperBound), Random.Range(LowerBound, UpperBound), Random.Range(Zoffset + LowerBound, Zoffset + UpperBound));

        TargetClone = Instantiate(Target, TargetPos, Quaternion.identity);

        TargetClone.GetComponent<Target>().TargetVelocity = TargetVelocity;

        if (TargetVelocity == 1)
        {
            TargetColor.color = Color.green;
        }
        else if (TargetVelocity == 2)
        {
            TargetColor.color = Color.yellow;
        }
        else if (TargetVelocity == 3)
        {
            TargetColor.color = Color.red;
        }
        else
        {
            TargetColor.color = Color.black;
        }
    }
}
