using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject Target;
    public Vector3 TargetPos;
    public bool TargetCollision;
    public float UpperBound, LowerBound, Zoffset;

    GameObject TargetClone;
    
    void Start()
    {
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
    }
}
