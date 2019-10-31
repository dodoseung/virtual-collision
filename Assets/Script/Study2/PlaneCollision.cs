using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public bool col;
    // Start is called before the first frame update
    void Start()
    {
        col = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        col = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        col = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }
}
