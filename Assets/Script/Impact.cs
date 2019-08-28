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

        Speed = Plane.GetComponent<Rigidbody>().GetPointVelocity(collision.contacts[0].point).magnitude;
        pk = collision.contacts[0].normal; // The normal vector of contact point
        vk = Plane.GetComponent<Rigidbody>().GetPointVelocity(collision.contacts[0].point); // The velocity of the touched point
        Direction = IntegrationVector(pk, vk, Speed);

        if (Integration)
            this.GetComponent<Rigidbody>().AddForce(Magnitude * Direction - Impulse, ForceMode.Impulse);

        if (collision.collider.CompareTag("Plane"))
        {
            PlaneTouch = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Impulse = collision.impulse;
        Magnitude = Impulse.magnitude;

        Speed = Plane.GetComponent<Rigidbody>().GetPointVelocity(collision.contacts[0].point).magnitude;
        pk = collision.contacts[0].normal; // The normal vector of contact point
        vk = Plane.GetComponent<Rigidbody>().GetPointVelocity(collision.contacts[0].point); // The velocity of the touched point
        Direction = IntegrationVector(pk, vk, Speed);

        if (Integration)
            this.GetComponent<Rigidbody>().AddForce(Magnitude * Direction - Impulse, ForceMode.Impulse);

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
        
        a1 = 23.416504758810860f;
        b1 = 0.004467197881167f;
        a2 = 22.344494266653612f;
        b2 = 0.265585204526577f;

        /*
        a1 = 4.608524873987856f;
        b1 = 1.065647570186457e-11f;
        a2 = 4.453797446315623f;
        b2 = 1.205449002690072f;
        */

        Sigma_pk = a1 * (float)Math.Exp(b1 * _speed);
        Sigma_vk = 1 / ((float)Math.Exp(b2 * _speed) - 1) + a2;

        Denom = 1/(float)Math.Pow(Sigma_pk,2) + 1/(float)Math.Pow(Sigma_vk,2);

        W_pk = 1 / (float)Math.Pow(Sigma_pk, 2) / Denom;
        W_vk = 1 / (float)Math.Pow(Sigma_vk, 2) / Denom;
        Debug.Log("Wpk: " + W_pk.ToString("F4") + " Wvk: " + W_vk.ToString("F4"));
        IntegratedVector = W_pk*pk + W_vk*vk;

        return IntegratedVector.normalized;
    }
}
