using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisChange : MonoBehaviour
{
    public float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 OrigRot = transform.localEulerAngles;
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 10.0f);
        transform.localRotation = Quaternion.Euler(OrigRot.x, OrigRot.y, -15.0f);
    }
}
