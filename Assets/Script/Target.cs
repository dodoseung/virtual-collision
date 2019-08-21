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

            if (TargetVelocity == 1 && SphereVelocity > 0f && SphereVelocity <= 2f)
            {
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
            else if (TargetVelocity == 3 && SphereVelocity > 2.5f && SphereVelocity <= 3.5f)
            {
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
            */
            BroadcastMessage("Explode");
            CollisionDetection = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
        {
            /*
            float SphereVelocity = collision.collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

            if (TargetVelocity == 1 && SphereVelocity > 2f && SphereVelocity <= 4f)
            {
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
            else if (TargetVelocity == 3 && SphereVelocity > 2.5f && SphereVelocity <= 3.5f)
            {
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
            */
            BroadcastMessage("Explode");
            CollisionDetection = true;
        }
    }
}
