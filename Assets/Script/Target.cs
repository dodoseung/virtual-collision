using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool CollisionDetection;

    void Start()
    {
        CollisionDetection = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
            CollisionDetection = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
            CollisionDetection = true;
    }
}
