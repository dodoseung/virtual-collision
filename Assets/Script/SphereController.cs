﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public GameObject TargetController, Sphere;
    public bool Integration;
    public Vector3 SpherePos, HmdFoward;
    public float Friction, Bounciness, SphereDistance = 1f, SphereSpeed = 2f;

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

    public void ResetPosition()
    {
        if (!Sphere.transform.position.Equals(SpherePos))
        {
            Debug.Log("The Sphere Position is reseted");
            Sphere.GetComponent<Rigidbody>().isKinematic = true;
            Sphere.GetComponent<Rigidbody>().isKinematic = false;

            Sphere.GetComponent<Collider>().material.dynamicFriction = Friction;
            Sphere.GetComponent<Collider>().material.staticFriction = Friction;
            Sphere.GetComponent<Collider>().material.bounciness = Bounciness;
            
            if (Friction == 0 && Bounciness == 0)
                Sphere.GetComponent<Renderer>().material.color = new Color(211 / 255f, 217 / 255f, 220 / 255f); // Ice
            else if (Friction == 0.5f && Bounciness == 0)
                Sphere.GetComponent<Renderer>().material.color = new Color(129 / 255f, 91 / 255f, 55 / 255f); // Wood
            else if (Friction == 0 && Bounciness == 0.5f)
                Sphere.GetComponent<Renderer>().material.color = new Color(255 / 255f, 247 / 255f, 160 / 255f); // New Material
            else if (Friction == 0.5f && Bounciness == 0.5f)
                Sphere.GetComponent<Renderer>().material.color = new Color(148 / 255f, 119 / 255f, 100 / 255f); // Rubber

            Sphere.GetComponent<Impact>().Integration = Integration;

            Sphere.transform.position = SpherePos + SphereDistance * HmdFoward;

            CancelInvoke();

            Invoke("Shooting", 1f);
        }
    }

    void Shooting()
    {
        Sphere.GetComponent<Rigidbody>().AddForce(-SphereSpeed * HmdFoward, ForceMode.Impulse);
    }
}
