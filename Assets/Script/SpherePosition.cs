using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePosition : MonoBehaviour
{
    public GameObject TargetController, Sphere;
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
    }

    void ResetPosition()
    {
        if (!Sphere.transform.position.Equals(SpherePos))
        {
            Debug.Log("The Sphere Position is reseted");
            Sphere.transform.position = SpherePos;
        }
    }
}
