using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVWriter2 : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    public GameObject Plane, Camera, Light, TestController, TargetController, Sphere;
    GameObject Target;
    float timer = 0;
    int leng = 0, listLength;

    // Use this for initialization
    void Start()
    {
        Setup();
        
    }

    void Update()
    {
        Target = GameObject.Find("Target(Clone)");

        if (false)
        {
            Save();
            Debug.Log("Saved");
        }
        else
        {
            string[] rowDataTemp = new string[listLength];

            // Time
            timer += Time.deltaTime;
            rowDataTemp[0] = timer.ToString();

            // Test Controller (Main Controller)
            rowDataTemp[1] = TestController.GetComponent<MainController>().AllTrial.ToString();
            rowDataTemp[1] = TestController.GetComponent<MainController>().MaxTrial.ToString();
            rowDataTemp[1] = TestController.GetComponent<MainController>().SetTrial.ToString();
            rowDataTemp[1] = TestController.GetComponent<MainController>().Trial.ToString();

            rowDataTemp[4] = Convert.ToInt32(TestController.GetComponent<MainController>().Integration).ToString();
            rowDataTemp[3] = TestController.GetComponent<MainController>().TargetVelocity.ToString();
            rowDataTemp[3] = TestController.GetComponent<MainController>().Friction.ToString();
            rowDataTemp[3] = TestController.GetComponent<MainController>().Bounciness.ToString();

            rowDataTemp[5] = Convert.ToInt32(TestController.GetComponent<MainController>().TargetCollision).ToString();

            // Test Controller (Sphere Controller)
            rowDataTemp[6] = TestController.GetComponent<SphereController>().SpherePos.x.ToString();
            rowDataTemp[7] = TestController.GetComponent<SphereController>().SpherePos.y.ToString();
            rowDataTemp[8] = TestController.GetComponent<SphereController>().SpherePos.z.ToString();

            // Target Controller
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetColor.color.r.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetColor.color.g.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetColor.color.b.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().HmdPos.x.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().HmdPos.y.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().HmdPos.z.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetPos.x.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetPos.y.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetPos.z.ToString();
            rowDataTemp[6] = TargetController.GetComponent<TargetController>().TargetQuat.z.ToString();


            // Plane
            rowDataTemp[9] = Plane.transform.position.x.ToString();
            rowDataTemp[10] = Plane.transform.position.y.ToString();
            rowDataTemp[11] = Plane.transform.position.z.ToString();
            rowDataTemp[12] = Plane.transform.eulerAngles.x.ToString();
            rowDataTemp[13] = Plane.transform.eulerAngles.y.ToString();
            rowDataTemp[14] = Plane.transform.eulerAngles.z.ToString();
            rowDataTemp[23] = Plane.transform.lossyScale.x.ToString();
            rowDataTemp[24] = Plane.transform.lossyScale.y.ToString();
            rowDataTemp[25] = Plane.transform.lossyScale.z.ToString();

            rowDataTemp[15] = Plane.GetComponent<Rigidbody>().velocity.x.ToString();
            rowDataTemp[16] = Plane.GetComponent<Rigidbody>().velocity.y.ToString();
            rowDataTemp[17] = Plane.GetComponent<Rigidbody>().velocity.z.ToString();
            rowDataTemp[18] = Plane.GetComponent<Rigidbody>().velocity.magnitude.ToString();
            rowDataTemp[19] = Plane.GetComponent<Rigidbody>().angularVelocity.x.ToString();
            rowDataTemp[20] = Plane.GetComponent<Rigidbody>().angularVelocity.y.ToString();
            rowDataTemp[21] = Plane.GetComponent<Rigidbody>().angularVelocity.z.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().angularVelocity.magnitude.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().mass.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().drag.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().angularDrag.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().useGravity.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().isKinematic.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().interpolation.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().collisionDetectionMode.ToString();

            rowDataTemp[25] = Plane.transform.right.x.ToString();
            rowDataTemp[25] = Plane.transform.right.y.ToString();
            rowDataTemp[25] = Plane.transform.right.z.ToString();
            rowDataTemp[25] = Plane.transform.up.x.ToString();
            rowDataTemp[25] = Plane.transform.up.y.ToString();
            rowDataTemp[25] = Plane.transform.up.z.ToString();
            rowDataTemp[25] = Plane.transform.forward.x.ToString();
            rowDataTemp[25] = Plane.transform.forward.y.ToString();
            rowDataTemp[25] = Plane.transform.forward.z.ToString();

            // Sphere
            rowDataTemp[9] = Sphere.transform.position.x.ToString();
            rowDataTemp[10] = Sphere.transform.position.y.ToString();
            rowDataTemp[11] = Sphere.transform.position.z.ToString();
            rowDataTemp[12] = Sphere.transform.eulerAngles.x.ToString();
            rowDataTemp[13] = Sphere.transform.eulerAngles.y.ToString();
            rowDataTemp[14] = Sphere.transform.eulerAngles.z.ToString();
            rowDataTemp[23] = Sphere.transform.lossyScale.x.ToString();
            rowDataTemp[24] = Sphere.transform.lossyScale.y.ToString();
            rowDataTemp[25] = Sphere.transform.lossyScale.z.ToString();
            rowDataTemp[25] = Sphere.GetComponent<SphereCollider>().radius.ToString();

            rowDataTemp[15] = Sphere.GetComponent<Rigidbody>().velocity.x.ToString();
            rowDataTemp[16] = Sphere.GetComponent<Rigidbody>().velocity.y.ToString();
            rowDataTemp[17] = Sphere.GetComponent<Rigidbody>().velocity.z.ToString();
            rowDataTemp[18] = Sphere.GetComponent<Rigidbody>().velocity.magnitude.ToString();
            rowDataTemp[19] = Sphere.GetComponent<Rigidbody>().angularVelocity.x.ToString();
            rowDataTemp[20] = Sphere.GetComponent<Rigidbody>().angularVelocity.y.ToString();
            rowDataTemp[21] = Sphere.GetComponent<Rigidbody>().angularVelocity.z.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().angularVelocity.magnitude.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().mass.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().drag.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().angularDrag.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().useGravity.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().isKinematic.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().interpolation.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Rigidbody>().collisionDetectionMode.ToString();

            rowDataTemp[22] = Convert.ToInt32(Sphere.GetComponent<Impact>().PlaneTouch).ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Impulse.x.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Impulse.y.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Impulse.z.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().pk.x.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().pk.y.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().pk.z.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().vk.x.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().vk.y.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().vk.z.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Speed.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Direction.x.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Direction.y.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Direction.z.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Magnitude.ToString();

            rowDataTemp[22] = Sphere.GetComponent<Impact>().a1.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().b1.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().a2.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().b2.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Sigma_pk.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Sigma_vk.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().Denom.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().W_pk.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().W_vk.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().IntegratedVector.x.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().IntegratedVector.y.ToString();
            rowDataTemp[22] = Sphere.GetComponent<Impact>().IntegratedVector.z.ToString();




            leng++;
            rowData.Add(rowDataTemp);
        }
    }

    void Setup()
    {
        // Creating First row of titles manually.. 
        string[] rowDataTemp = {
         "Time", "Trial", "SphereShooting", "TargetVelocity", "integration", "TargetCollision", "SphereOffsetPosX", "SphereOffsetPosY", "SphereOffsetPosZ", // Test Controller
         "ObjName", "PosX", "PosY", "PosZ", "RotX", "RotY", "RotZ", "DestX", "DestY", "DestZ", "Diameter", "Speed", // SoccerBall
        };

        listLength = rowDataTemp.Length;

        rowData.Add(rowDataTemp);
    }

    void Save()
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

    /* https://sushanta1991.blogspot.com/2015/02/how-to-write-data-to-csv-file-in-unity.html */
}