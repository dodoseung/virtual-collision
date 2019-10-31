using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class PilotCSV : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    public Vector3 PointTarget, PointCollision;
    public float Velocity;
    int leng = 0, listLength;

    // Use this for initialization
    void Start()
    {
        Setup();
    }

    void Update()
    {
        if (GameObject.Find("TestController").GetComponent<MainController>().SetTrial == 16)
        {
            Save();
            Debug.Log("Saved");
        }
    }

    public void LoggingData()
    {
        MainController MainController = GameObject.Find("TestController").GetComponent<MainController>();
        string[] rowDataTemp = new string[listLength];

        rowDataTemp[0] = MainController.AllTrial.ToString();
        rowDataTemp[1] = MainController.SetTrial.ToString();
        rowDataTemp[2] = MainController.Trial.ToString();
        rowDataTemp[3] = MainController.Integration.ToString();
        rowDataTemp[4] = MainController.TargetVelocity.ToString();
        rowDataTemp[5] = MainController.Friction.ToString();
        rowDataTemp[6] = MainController.Bounciness.ToString();
        rowDataTemp[7] = PointTarget.x.ToString();
        rowDataTemp[8] = PointTarget.y.ToString();
        rowDataTemp[9] = PointTarget.z.ToString();
        rowDataTemp[10] = PointCollision.x.ToString();
        rowDataTemp[11] = PointCollision.y.ToString();
        rowDataTemp[12] = PointCollision.z.ToString();
        rowDataTemp[13] = Velocity.ToString();

        leng++;
        rowData.Add(rowDataTemp);
    }

    void Setup()
    {
        // Creating First row of titles manually.. 
        string[] rowDataTemp = {
         "AllTrial", "SetTrial", "Trial", "Integration", "TargetVelocity", "Friction", "Bounciness", "PointTargetX", "PointTargetY", // Test Controller
         "PointTargetZ", "PointCollisionX", "PointCollisionY", "PointCollisionZ", "Velocity"};

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