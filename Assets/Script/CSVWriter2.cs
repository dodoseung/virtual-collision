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
            // Time
            string[] rowDataTemp = new string[listLength];
            timer += Time.deltaTime;
            rowDataTemp[0] = timer.ToString();

            // Test Controller (Main Controller)
            rowDataTemp[1] = TestController.GetComponent<MainController>().trial.ToString();
            rowDataTemp[2] = TestController.GetComponent<MainController>().SphereShooting.ToString();
            rowDataTemp[3] = TestController.GetComponent<MainController>().TargetVelocity.ToString();
            rowDataTemp[4] = Convert.ToInt32(TestController.GetComponent<MainController>().integration).ToString();
            rowDataTemp[5] = Convert.ToInt32(TestController.GetComponent<MainController>().TargetCollision).ToString();

            // Test Controller (Sphere Controller)
            rowDataTemp[6] = TestController.GetComponent<SphereController>().SpherePos.x.ToString();
            rowDataTemp[7] = TestController.GetComponent<SphereController>().SpherePos.y.ToString();
            rowDataTemp[8] = TestController.GetComponent<SphereController>().SpherePos.z.ToString();

            // Plane
            rowDataTemp[9] = Plane.transform.position.x.ToString();
            rowDataTemp[10] = Plane.transform.position.y.ToString();
            rowDataTemp[11] = Plane.transform.position.z.ToString();
            rowDataTemp[12] = Plane.transform.eulerAngles.x.ToString();
            rowDataTemp[13] = Plane.transform.eulerAngles.y.ToString();
            rowDataTemp[14] = Plane.transform.eulerAngles.z.ToString();
            rowDataTemp[15] = Plane.GetComponent<Rigidbody>().velocity.x.ToString();
            rowDataTemp[16] = Plane.GetComponent<Rigidbody>().velocity.y.ToString();
            rowDataTemp[17] = Plane.GetComponent<Rigidbody>().velocity.z.ToString();
            rowDataTemp[18] = Plane.GetComponent<Rigidbody>().velocity.magnitude.ToString();
            rowDataTemp[19] = Plane.GetComponent<Rigidbody>().angularVelocity.x.ToString();
            rowDataTemp[20] = Plane.GetComponent<Rigidbody>().angularVelocity.y.ToString();
            rowDataTemp[21] = Plane.GetComponent<Rigidbody>().angularVelocity.z.ToString();
            rowDataTemp[22] = Plane.GetComponent<Rigidbody>().angularVelocity.magnitude.ToString();
            rowDataTemp[23] = Plane.transform.lossyScale.x.ToString();
            rowDataTemp[24] = Plane.transform.lossyScale.y.ToString();
            rowDataTemp[25] = Plane.transform.lossyScale.z.ToString();

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