using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject TargetController, Sphere;
    public Vector3 SpherePos;
    public bool SphereShooting;
    
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
    }

    void ResetPosition()
    {
        if (!Sphere.transform.position.Equals(SpherePos))
        {
            Debug.Log("The Sphere Position is reseted");
            Sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            if (SphereShooting)
            {
                Sphere.transform.position = SpherePos + new Vector3(0, 0, 1f);
                Sphere.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1f), ForceMode.Impulse);
            }
            else
            {
                Sphere.transform.position = SpherePos;
            }
        }
    }
}
