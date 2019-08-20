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

            //rowDataTemp[1] = obj[0].GetComponent<TargetTran>().trial.ToString();
            //rowDataTemp[4] = Convert.ToInt32(obj[0].GetComponent<TargetTran>().collide).ToString();
            //rowDataTemp[5] = Convert.ToInt32(obj[0].GetComponent<TargetTran>().collideD).ToString();

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