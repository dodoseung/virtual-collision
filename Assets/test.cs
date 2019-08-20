using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject plane;
    public Vector3 Prev, Curr, Pos, ThisPrev, ThisCurr;

    // Start is called before the first frame update
    void Start()
    {
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Prev = Curr;
        Curr = plane.transform.position;

        ThisPrev = ThisCurr;
        ThisCurr = transform.position;

        if (Mathf.Abs((Pos - transform.position).magnitude) > 2)
        {
            transform.position = Pos;
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 PlaneVector = Curr - Prev;
        Vector3 ThisVector = ThisCurr - ThisPrev;
        Vector3 RelativeVector = PlaneVector - ThisVector;
        float time = Time.deltaTime;
        Vector3 impulse = RelativeVector / time;
        this.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        //this.GetComponent<Rigidbody>().AddForce(impulse.magnitude * plane.transform.forward, ForceMode.Impulse);
        Debug.Log("Enter" + RelativeVector.ToString("F4") + time.ToString("F4") + (impulse / 2).ToString("F4"));
    }
    /*
    private void OnCollisionStay(Collision collision)
    {
        Vector3 PlaneVector = Curr - Prev;
        Vector3 ThisVector = ThisCurr - ThisPrev;
        Vector3 RelativeVector = PlaneVector - ThisVector;
        float time = Time.deltaTime;
        Vector3 impulse = RelativeVector / time / 2;
        this.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        //this.GetComponent<Rigidbody>().AddForce(impulse.magnitude * plane.transform.forward, ForceMode.Impulse);
        Debug.Log("Stay" + RelativeVector.ToString("F4") + time.ToString("F4") + (impulse / 2).ToString("F4"));
    }

    private void OnCollisionExit(Collision collision)
    {
        Vector3 PlaneVector = Curr - Prev;
        Vector3 ThisVector = ThisCurr - ThisPrev;
        Vector3 RelativeVector = PlaneVector - ThisVector;
        float time = Time.deltaTime;
        Vector3 impulse = RelativeVector / time / 2;
        this.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
        //this.GetComponent<Rigidbody>().AddForce(impulse.magnitude * plane.transform.forward, ForceMode.Impulse);
        Debug.Log("Exit" + RelativeVector.ToString("F4") + time.ToString("F4") + (impulse / 2).ToString("F4"));
    }*/
}