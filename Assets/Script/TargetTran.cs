using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTran : MonoBehaviour
{
    public float tran = 1.0f;
    public Camera cam;
    Vector3 origPos;
    float VecX, VecY, VecZ, denom;

    // Start is called before the first frame update
    void Start()
    {     
        Color orig0 = this.GetComponent<MeshRenderer>().materials[0].color;
        this.GetComponent<MeshRenderer>().materials[0].color = new Color(orig0.r, orig0.g, orig0.b, tran);
        Color orig1 = this.GetComponent<MeshRenderer>().materials[1].color;
        this.GetComponent<MeshRenderer>().materials[1].color = new Color(orig1.r, orig1.g, orig1.b, tran);

        origPos = transform.position;

        ChangeDestPos();
    }

    // Update is called once per frames
    void Update()
    {
        transform.Translate(new Vector3(VecX / denom, VecY / denom, VecZ / denom) * Time.deltaTime);

        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        // If the pos of object is out of the camera view, reset its position
        if (!onScreen || Mathf.Abs(screenPoint.z - origPos.z) > 2)
        {
            transform.position = origPos;
            ChangeDestPos();
        }
    }

    void ChangeDestPos()
    {
        VecX = Random.Range(-1.0f, 1.0f);
        VecY = Random.Range(-1.0f, 1.0f);
        VecZ = Random.Range(-1.0f, 1.0f);
        denom = Mathf.Sqrt(VecX * VecX + VecY * VecY + VecZ * VecZ);
    }

}
