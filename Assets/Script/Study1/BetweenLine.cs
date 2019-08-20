using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenLine : MonoBehaviour {

    public float move = 0;
    public int NoteNumPlus1;
    public GameObject obj1, obj2;
    Vector3 temp;
    Vector3 pos;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 o1 = obj1.transform.position;
        Vector3 o2 = obj2.transform.position;      

        temp = (o1 + o2) / 2;

        transform.localScale = new Vector3(0.001f, (o2 - o1).magnitude / 2, 0.001f);
        transform.position = temp;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, o2 - o1);
    }

}

