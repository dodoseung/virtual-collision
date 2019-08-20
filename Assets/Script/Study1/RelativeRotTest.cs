using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeRotTest : MonoBehaviour
{
    Transform test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static Vector3 getRelativePosition(Transform origin, Vector3 position)
    {
        Vector3 distance = position - origin.position;
        Vector3 relativePosition = Vector3.zero;
        relativePosition.x = Vector3.Dot(distance, origin.right.normalized);
        relativePosition.y = Vector3.Dot(distance, origin.up.normalized);
        relativePosition.z = Vector3.Dot(distance, origin.forward.normalized);

        return relativePosition;
    }

    // Update is called once per frame
    void Update()
    {
        test = GameObject.Find("testcube2").transform;

        Debug.Log(getRelativePosition(transform, test.position).x);
        Debug.Log(getRelativePosition(transform, test.position).y);
        Debug.Log(getRelativePosition(transform, test.position).z);
    }
}
