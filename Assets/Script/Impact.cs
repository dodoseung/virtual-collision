using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Impact : MonoBehaviour
{
    public GameObject Plane;
    public bool PlaneTouch = false;
    public bool Integration;

    public Vector3 Impulse, pk, vk, Direction;
    public float Magnitude, Speed;

    public Vector3 IntegratedVector;
    public float a1, b1, a2, b2, Sigma_pk, Sigma_vk, Denom, W_pk, W_vk;

    private void OnCollisionEnter(Collision collision)
    {
        Impulse = collision.impulse;
        Magnitude = Impulse.magnitude;

        Speed = Plane.GetComponent<Rigidbody>().velocity.magnitude;
        vk = Plane.GetComponent<Rigidbody>().velocity; // The velocity of the center point
        pk = collision.contacts[0].normal; // The normal vector of contact point
        Direction = IntegrationVector(pk, vk, Speed);
        Debug.Log(Impulse.ToString("F4"));
        if (Integration)
        {
            this.GetComponent<Rigidbody>().AddForce(Magnitude * Direction - Impulse, ForceMode.Impulse);
        }

        if (collision.collider.CompareTag("Plane"))
        {
            PlaneTouch = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Impulse = collision.impulse;
        Magnitude = Impulse.magnitude;

        Speed = Plane.GetComponent<Rigidbody>().velocity.magnitude;
        vk = Plane.GetComponent<Rigidbody>().velocity; // The velocity of the center point
        pk = collision.contacts[0].normal; // The normal vector of contact point
        Direction = IntegrationVector(pk, vk, Speed);
        Debug.Log(Impulse.ToString("F4"));
        if (Integration)
        {
            this.GetComponent<Rigidbody>().AddForce(Magnitude * Direction - Impulse, ForceMode.Impulse);
        }

        if (collision.collider.CompareTag("Plane"))
        {
            PlaneTouch = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject.Find("Target(Clone)").GetComponent<Target>().SphereVelocity = this.GetComponent<Rigidbody>().velocity.magnitude;

        Impulse = Vector3.zero;
        Magnitude = 0;
        Speed = 0;
        pk = Vector3.zero;
        vk = Vector3.zero;
        Direction = Vector3.zero;
        PlaneTouch = false;    
    }

    private Vector3 IntegrationVector(Vector3 _pk, Vector3 _vk, float _speed)
    {
        _pk = pk.normalized;
        _vk = vk.normalized;

        // Center Point
        a1 = 1.018136168830097f;
        b1 = 0.748575373552740f;
        a2 = 2.590009727088067f;
        b2 = 173.3239841461182f;

        Sigma_pk = a1 * (float)Math.Exp(b1 * _speed);
        Sigma_vk = 1 / ((float)Math.Exp(b2 * _speed) - 1) + a2;

        Denom = 1/(float)Math.Pow(Sigma_pk,2) + 1/(float)Math.Pow(Sigma_vk,2);

        W_pk = 1 / (float)Math.Pow(Sigma_pk, 2) / Denom;
        W_vk = 1 / (float)Math.Pow(Sigma_vk, 2) / Denom;
        //Debug.Log("Wpk: " + W_pk.ToString("F4") + " Wvk: " + W_vk.ToString("F4"));
        IntegratedVector = W_pk*pk + W_vk*vk;

        return IntegratedVector.normalized;
    }
}
