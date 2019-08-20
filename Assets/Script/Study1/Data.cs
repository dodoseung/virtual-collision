using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public float[] n1;
    public float[] n2;
    public float[] n3;

    // Start is called before the first frame update
    void Start()
    {
        n1 = new float[4];
        n2 = new float[3];
        n3 = new float[3];
    }

    // Update is called once per frame
    void Update()
    {
        n1[0] = GameObject.Find("HMD").transform.localPosition.x;
        n1[1] = GameObject.Find("HMD").transform.localPosition.y;
        n1[2] = GameObject.Find("HMD").transform.localPosition.z;
        n1[3] = GameObject.Find("HMD").transform.localEulerAngles.y;

        n2[0] = GameObject.Find("Main Camera").transform.localEulerAngles.x;
        n2[1] = GameObject.Find("Main Camera").transform.localEulerAngles.y;
        n2[2] = GameObject.Find("Main Camera").transform.localEulerAngles.z;

        n1[0] = GameObject.Find("DuplicatedMarker").transform.localPosition.x;
        n1[1] = GameObject.Find("DuplicatedMarker").transform.localPosition.y;
        n1[2] = GameObject.Find("DuplicatedMarker").transform.localPosition.z;
    }
}
