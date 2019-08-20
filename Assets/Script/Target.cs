using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool CollisionDetection;
    public int TargetVelocity;

    void Start()
    {
        CollisionDetection = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
        {
            /*
            float SphereVelocity = collision.collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            if (TargetVelocity == 1 && SphereVelocity > 0.5f && SphereVelocity <= 1.5f)
            {
                CollisionDetection = true;
            }
            else if (TargetVelocity == 2 && SphereVelocity > 1.5f && SphereVelocity <= 2.5f)
            {
                CollisionDetection = true;
            }
            else if (TargetVelocity == 3 && SphereVelocity > 2.5f && SphereVelocity <= 3.5f)
            {
                CollisionDetection = true;
            }
            */
            CollisionDetection = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
        {
            /*
            float SphereVelocity = collision.collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            if (TargetVelocity == 1 && SphereVelocity > 0.5f && SphereVelocity <= 1.5f)
            {
                CollisionDetection = true;
            }
            else if (TargetVelocity == 2 && SphereVelocity > 1.5f && SphereVelocity <= 2.5f)
            {
                CollisionDetection = true;
            }
            else if (TargetVelocity == 3 && SphereVelocity > 2.5f && SphereVelocity <= 3.5f)
            {
                CollisionDetection = true;
            }
            */
            CollisionDetection = true;
        }
    }
}
