using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool Rotation, TransForward, RigidForward, ImpactForward, AddForward;
    
    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.localRotation;

        if (Rotation)
        {
            GetComponent<Rigidbody>().MoveRotation(new Quaternion(rot.x - 0.1f * Time.fixedDeltaTime, rot.y, rot.z, rot.w));
        }

        if (TransForward)
        {
            transform.position = new Vector3(pos.x, pos.y, pos.z + 0.5f * Time.fixedDeltaTime);
        }

        if (RigidForward) {
            GetComponent<Rigidbody>().MovePosition(new Vector3(pos.x, pos.y, pos.z + 0.5f * Time.fixedDeltaTime));
        }
       
        if (ImpactForward)
        {
            GetComponent<Rigidbody>().AddForce(0,0,0.5f, ForceMode.Impulse);
            ImpactForward = false;
        }
        if (AddForward)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1f));
        }

    }
}
