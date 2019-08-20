using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Impact : MonoBehaviour
{
    public bool Integration = true;
    public bool PlaneTouch = false;
    public GameObject Plane;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 impulse = collision.impulse;
        float magnitude = impulse.magnitude;

        float speed = (Plane.GetComponent<Rigidbody>().velocity - this.GetComponent<Rigidbody>().velocity).magnitude; // The definition of a speed ?
        Vector3 pk = collision.contacts[0].normal; // The normal vector of contact point
        Vector3 vk = Plane.GetComponent<Rigidbody>().GetPointVelocity(collision.contacts[0].point); // The velocity of the touched point
        Vector3 direction = IntegrationVector(pk, vk, speed);

        if (Integration)
            this.GetComponent<Rigidbody>().AddForce(magnitude * direction - impulse, ForceMode.Impulse);

        if (collision.collider.CompareTag("Plane"))
        {
            PlaneTouch = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 impulse = collision.impulse;
        float magnitude = impulse.magnitude;

        float speed = (Plane.GetComponent<Rigidbody>().velocity - this.GetComponent<Rigidbody>().velocity).magnitude; // The definition of a speed ?
        Vector3 pk = collision.contacts[0].normal; // The normal vector of contact point
        Vector3 vk = Plane.GetComponent<Rigidbody>().GetPointVelocity(collision.contacts[0].point); // The velocity of the touched point
        Vector3 direction = IntegrationVector(pk, vk, speed);

        if (Integration)
            this.GetComponent<Rigidbody>().AddForce(magnitude * direction - impulse, ForceMode.Impulse);

        PlaneTouch = false;
    }

    private Vector3 IntegrationVector(Vector3 pk, Vector3 vk, float speed)
    {
        pk = pk.normalized;
        vk = vk.normalized;
        float a1 = 1.880565208227337f, b1 = 0.085452450340846f, a2 = 2.298139024394025f, b2 = 207.5678940745083f;
        float sigma_pk = a1 * (float)Math.Exp(b1 * speed);
        float sigma_vk = 1 / ((float)Math.Exp(b2 * speed) - 1) + a2;

        float denom = 1/(float)Math.Pow(sigma_pk,2) + 1/(float)Math.Pow(sigma_vk,2);

        float w_pk = 1 / (float)Math.Pow(sigma_pk, 2) / denom;
        float w_vk = 1 / (float)Math.Pow(sigma_vk, 2) / denom;

        Vector3 integrated_vector = w_pk*pk + w_vk*vk;

        return integrated_vector.normalized;
    }
}
