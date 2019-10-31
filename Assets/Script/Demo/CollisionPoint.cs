using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionPoint : MonoBehaviour
{
    public GameObject TestController, TargetClone, ContactTraceInteg, ContactTraceNormal;
    public GameObject IntegScoreText, NormalScoreText;
    List<Vector3> ContactPointInteg, ContactPointNormal;
    Vector3 TargetPos, TargetForward;
    float ScoreInteg, ScoreNormal;
    Quaternion TargetRot;
    bool PointDisplay;

    void Start()
    {
        ContactPointInteg = new List<Vector3>();
        ContactPointNormal = new List<Vector3>();
        PointDisplay = false;

        ScoreInteg = 0;
        ScoreNormal = 0;
    }

    void Update()
    {
        if(GameObject.Find("Target(Clone)") != null)
        {
            TargetInformation();
        }

        if (!PointDisplay && TestController.GetComponent<DemoMainController>().SetTrial == 4)
        {
            Debug.Log("Show the traces");

            PointDisplay = true;

            for (int i = 0; i < ContactPointInteg.Count; i++)
            {
                float DistanceInteg = Vector3.Distance(TargetPos, ContactPointInteg[i]);
                if (DistanceInteg < 0.8)
                {
                    ScoreInteg += 10 / DistanceInteg;
                }
                else
                {
                    ScoreInteg -= DistanceInteg / 3;
                }

                Instantiate(ContactTraceInteg, ContactPointInteg[i], TargetClone.transform.rotation);
            }
            IntegScoreText.GetComponent<TextMeshProUGUI>().text = ScoreInteg.ToString("F0");

            for (int i = 0; i < ContactPointNormal.Count; i++)
            {
                float DistanceNormal = Vector3.Distance(TargetPos, ContactPointNormal[i]);
                if (DistanceNormal < 0.8)
                {
                    ScoreNormal += 10 / DistanceNormal;
                }
                else
                {
                    ScoreNormal -= DistanceNormal / 3;
                }
                Instantiate(ContactTraceNormal, ContactPointNormal[i], TargetClone.transform.rotation);
            }
            NormalScoreText.GetComponent<TextMeshProUGUI>().text = ScoreNormal.ToString("F0");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 ContactPoint = other.transform.position; //- TargetForward * (other.transform.lossyScale.x / 2);
        Debug.Log(ContactPoint.ToString("F3"));

        if (TestController.GetComponent<DemoMainController>().Integration)
        {
            ContactPointInteg.Add(ContactPoint);
        }
        else
        {
            ContactPointNormal.Add(ContactPoint);
        }
    }

    private void TargetInformation()
    {
        TargetClone = GameObject.Find("Target(Clone)");
        TargetPos = TargetClone.transform.position;
        TargetRot = TargetClone.transform.rotation;
        TargetForward = TargetClone.transform.forward;
        this.transform.position = TargetPos + 0.1f * TargetForward;
        this.transform.rotation = TargetRot;
    }
}
