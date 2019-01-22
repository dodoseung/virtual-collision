using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    public Transform[] obj = new Transform[2];

    // Use this for initialization
    void Start()
    {
        Setup();
    }

    void Update()
    {
        if(rowData.Count == 100)
        {
            Save();
        }
        else if (rowData.Count <= 100)
        {
            // Add time, position, and rotation
            string[] rowDataTemp = new string[1 + obj.Length * 7];
            rowDataTemp[0] = System.DateTime.Now.Millisecond.ToString();

            for (int i = 0; i < obj.Length; i++)
            {
                rowDataTemp[7 * i + 1] = obj[i].name;
                rowDataTemp[7 * i + 2] = obj[i].position.x.ToString();
                rowDataTemp[7 * i + 3] = obj[i].position.y.ToString();
                rowDataTemp[7 * i + 4] = obj[i].position.z.ToString();
                rowDataTemp[7 * i + 5] = obj[i].rotation.x.ToString();
                rowDataTemp[7 * i + 6] = obj[i].rotation.y.ToString();
                rowDataTemp[7 * i + 7] = obj[i].rotation.z.ToString();
            }
            rowData.Add(rowDataTemp);
        }
    }

    void Setup()
    {
        // Creating First row of titles manually..
        string[] rowDataTemp = new string[1 + obj.Length * 7];

        rowDataTemp[0] = "Time";

        for (int i = 0; i < obj.Length; i++)
        {
            rowDataTemp[7 * i + 1] = "ObjName";
            rowDataTemp[7 * i + 2] = "PosX";
            rowDataTemp[7 * i + 3] = "PosY";
            rowDataTemp[7 * i + 4] = "PosZ";
            rowDataTemp[7 * i + 5] = "RotX";
            rowDataTemp[7 * i + 6] = "RotY";
            rowDataTemp[7 * i + 7] = "RotZ";
        }
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