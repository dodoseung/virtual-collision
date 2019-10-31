using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSphereController : MonoBehaviour
{
    public GameObject TargetController, Sphere;
    public PhysicMaterial PhysicsMaterial;
    public bool Integration;
    public Vector3 SpherePos, HmdFoward;
    public float Friction, Bounciness, SphereDistance = 0f, SphereSpeed = 0f;

    void Update()
    {
        if (TargetController.GetComponent<DemoTargetController>().TargetCollision)
        {
            ResetPosition();
        }

        if (Sphere.GetComponent<Impact>().PlaneTouch)
        {
            Invoke("ResetPosition", 5f);
        }

        if (Sphere.transform.position.z < (SpherePos.z - 1.0f))
        {
            ResetPosition();
        }

        if ((Sphere.transform.position - SpherePos).magnitude > 7f)
        {
            ResetPosition();
        }

        ChangeSphereProperties();
    }

    public void ResetPosition()
    {
        if (!Sphere.transform.position.Equals(SpherePos))
        {
            Debug.Log("The Sphere Position is reseted");
            Sphere.GetComponent<Rigidbody>().isKinematic = true;
            Sphere.GetComponent<Rigidbody>().isKinematic = false;

            //Sphere.transform.position = SpherePos + SphereDistance * HmdFoward;
            Sphere.transform.position = SpherePos;

            CancelInvoke();

            Invoke("Shooting", 1f);
        }
    }

    void ChangeSphereProperties()
    {
        if (Integration)
            Sphere.GetComponent<Renderer>().material.color = new Color(42 / 255f, 255 / 255f, 188 / 255f); // Integ
        else if (!Integration)
            Sphere.GetComponent<Renderer>().material.color = new Color(255 / 255f, 178 / 255f, 0); // Normal

        Friction = 0.2f;
        Bounciness = 0.2f;

        PhysicsMaterial.dynamicFriction = Friction;
        PhysicsMaterial.staticFriction = Friction;
        PhysicsMaterial.bounciness = Bounciness;
        Sphere.GetComponent<Impact>().Integration = Integration;
        
    }

    // Move the ball to the user 'SphereSpeed' m/s
    void Shooting()
    {
        Sphere.GetComponent<Rigidbody>().AddForce(-SphereSpeed * HmdFoward, ForceMode.Impulse);
    }
}
