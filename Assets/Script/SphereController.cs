using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject TargetController, Sphere;
    public int SphereShooting;
    public Vector3 SpherePos;
    
    void Update()
    {
        if (TargetController.GetComponent<TargetController>().TargetCollision)
        {
            ResetPosition();
        }

        if (Sphere.GetComponent<Impact>().PlaneTouch)
        {
            Invoke("ResetPosition", 3f);
        }

        if (Sphere.transform.position.z < (SpherePos.z - 1.0f))
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        if (!Sphere.transform.position.Equals(SpherePos))
        {
            Debug.Log("The Sphere Position is reseted");
            Sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (SphereShooting > 0)
            {
                Sphere.transform.position = SpherePos + new Vector3(0, 0, 2f);
                Invoke("Shooting", 1f);
            }
            else
            {
                Sphere.transform.position = SpherePos;
            }
        }
    }

    void Shooting()
    {
        Sphere.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -SphereShooting), ForceMode.Impulse);
    }
}
