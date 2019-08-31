using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseImpact : MonoBehaviour
{
    Vector3 Velocity, AngularVelocity;

    private void FixedUpdate()
    {
        Velocity = GetComponent<Rigidbody>().velocity;
        AngularVelocity = GetComponent<Rigidbody>().angularVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Velocity;
        GetComponent<Rigidbody>().angularVelocity = AngularVelocity;

        //GetComponent<Rigidbody>().AddForce(-collision.impulse, ForceMode.Impulse);

        Velocity = GetComponent<Rigidbody>().velocity;
        AngularVelocity = GetComponent<Rigidbody>().angularVelocity;
    }
    private void OnCollisionStay(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Velocity;
        GetComponent<Rigidbody>().angularVelocity = AngularVelocity;

        //GetComponent<Rigidbody>().AddForce(-collision.impulse, ForceMode.Impulse);

        Velocity = GetComponent<Rigidbody>().velocity;
        AngularVelocity = GetComponent<Rigidbody>().angularVelocity;
    }
    
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Velocity;
        GetComponent<Rigidbody>().angularVelocity = AngularVelocity;

        //GetComponent<Rigidbody>().AddForce(-collision.impulse, ForceMode.Impulse);

        Velocity = GetComponent<Rigidbody>().velocity;
        AngularVelocity = GetComponent<Rigidbody>().angularVelocity;
    }
}
