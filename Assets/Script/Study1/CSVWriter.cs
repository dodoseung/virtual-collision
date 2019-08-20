using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVWriter : MonoBehaviour
{

    private List<string[]> rowData = new List<string[]>();
    public Transform[] obj = new Transform[4];
    public Transform[] refer = new Transform[3];
    float timer = 0;
    int leng = 0, n = 4;
    int listLength;

    // Use this for initialization
    void Start()
    {
        Setup();
        
    }

    void Update()
    {   //if (leng == 1000)
        if (obj[0].GetComponent<TargetTran>().settrial == 36)
        {
            Save();
            Debug.Log("Saved");
        }
        else
        {
            // Add time, position, and rotation
            string[] rowDataTemp = new string[listLength];
            timer += Time.deltaTime;
            rowDataTemp[0] = timer.ToString();
            rowDataTemp[1] = obj[0].GetComponent<TargetTran>().trial.ToString();
            rowDataTemp[2] = Velocity(obj[0].GetComponent<TargetTran>().BallSpeed).ToString();
            rowDataTemp[3] = Direction(obj[0].GetComponent<TargetTran>().destPos).ToString();
            rowDataTemp[4] = Convert.ToInt32(obj[0].GetComponent<TargetTran>().collide).ToString();
            rowDataTemp[5] = Convert.ToInt32(obj[0].GetComponent<TargetTran>().collideD).ToString();

            rowDataTemp[2 + n] = obj[0].name;
            rowDataTemp[3 + n] = obj[0].position.x.ToString();
            rowDataTemp[4 + n] = obj[0].position.y.ToString();
            rowDataTemp[5 + n] = obj[0].position.z.ToString();
            rowDataTemp[6 + n] = obj[0].eulerAngles.x.ToString();
            rowDataTemp[7 + n] = obj[0].eulerAngles.y.ToString();
            rowDataTemp[8 + n] = obj[0].eulerAngles.z.ToString();
            rowDataTemp[9 + n] = obj[0].GetComponent<TargetTran>().destPos.x.ToString();
            rowDataTemp[10 + n] = obj[0].GetComponent<TargetTran>().destPos.y.ToString();
            rowDataTemp[11 + n] = obj[0].GetComponent<TargetTran>().destPos.z.ToString();
            rowDataTemp[12 + n] = obj[0].transform.localScale.x.ToString();
            rowDataTemp[13 + n] = obj[0].GetComponent<TargetTran>().BallSpeed.ToString();

            rowDataTemp[14 + n] = obj[1].name;
            rowDataTemp[15 + n] = obj[1].position.x.ToString();
            rowDataTemp[16 + n] = obj[1].position.y.ToString();
            rowDataTemp[17 + n] = obj[1].position.z.ToString();
            rowDataTemp[18 + n] = obj[1].eulerAngles.x.ToString();
            rowDataTemp[19 + n] = obj[1].eulerAngles.y.ToString();
            rowDataTemp[20 + n] = obj[1].eulerAngles.z.ToString();

            rowDataTemp[21 + n] = obj[2].name;
            rowDataTemp[22 + n] = obj[2].position.x.ToString();
            rowDataTemp[23 + n] = obj[2].position.y.ToString();
            rowDataTemp[24 + n] = obj[2].position.z.ToString();
            rowDataTemp[25 + n] = obj[2].eulerAngles.x.ToString();
            rowDataTemp[26 + n] = obj[2].eulerAngles.y.ToString();
            rowDataTemp[27 + n] = obj[2].eulerAngles.z.ToString();
            rowDataTemp[28 + n] = "L";
            rowDataTemp[29 + n] = refer[1].transform.localScale.x.ToString();
            rowDataTemp[30 + n] = refer[1].transform.localScale.y.ToString();
            rowDataTemp[31 + n] = (refer[1].transform.localScale.z * 2.0f).ToString();

            rowDataTemp[32 + n] = obj[3].name;
            rowDataTemp[33 + n] = obj[3].position.x.ToString();
            rowDataTemp[34 + n] = obj[3].position.y.ToString();
            rowDataTemp[35 + n] = obj[3].position.z.ToString();
            rowDataTemp[36 + n] = obj[3].eulerAngles.x.ToString();
            rowDataTemp[37 + n] = obj[3].eulerAngles.y.ToString();
            rowDataTemp[38 + n] = obj[3].eulerAngles.z.ToString();
            rowDataTemp[39 + n] = obj[3].GetComponent<Light>().range.ToString();

            rowDataTemp[40 + n] = obj[0].GetComponent<TargetTran>().ContactPoint.x.ToString();
            rowDataTemp[41 + n] = obj[0].GetComponent<TargetTran>().ContactPoint.y.ToString();
            rowDataTemp[42 + n] = obj[0].GetComponent<TargetTran>().ContactPoint.z.ToString();
            rowDataTemp[43 + n] = obj[0].GetComponent<TargetTran>().ContactRelativePoint.x.ToString();
            rowDataTemp[44 + n] = obj[0].GetComponent<TargetTran>().ContactRelativePoint.y.ToString();
            rowDataTemp[45 + n] = obj[0].GetComponent<TargetTran>().ContactRelativePoint.z.ToString();

            rowDataTemp[46 + n] = obj[0].GetComponent<TargetTran>().RotationToNormVect(obj[2]).x.ToString();
            rowDataTemp[47 + n] = obj[0].GetComponent<TargetTran>().RotationToNormVect(obj[2]).y.ToString();
            rowDataTemp[48 + n] = obj[0].GetComponent<TargetTran>().RotationToNormVect(obj[2]).z.ToString();

            rowDataTemp[49 + n] = obj[0].GetComponent<TargetTran>().ContactPointD.x.ToString();
            rowDataTemp[50 + n] = obj[0].GetComponent<TargetTran>().ContactPointD.y.ToString();
            rowDataTemp[51 + n] = obj[0].GetComponent<TargetTran>().ContactPointD.z.ToString();
            rowDataTemp[52 + n] = obj[0].GetComponent<TargetTran>().ContactRelativePointD.x.ToString();
            rowDataTemp[53 + n] = obj[0].GetComponent<TargetTran>().ContactRelativePointD.y.ToString();
            rowDataTemp[54 + n] = obj[0].GetComponent<TargetTran>().ContactRelativePointD.z.ToString();

            rowDataTemp[55 + n] = obj[2].right.normalized.x.ToString();
            rowDataTemp[56 + n] = obj[2].right.normalized.y.ToString();
            rowDataTemp[57 + n] = obj[2].right.normalized.z.ToString();
            rowDataTemp[58 + n] = obj[2].up.normalized.x.ToString();
            rowDataTemp[59 + n] = obj[2].up.normalized.y.ToString();
            rowDataTemp[60 + n] = obj[2].up.normalized.z.ToString();
            rowDataTemp[61 + n] = obj[2].forward.normalized.x.ToString();
            rowDataTemp[62 + n] = obj[2].forward.normalized.y.ToString();
            rowDataTemp[63 + n] = obj[2].forward.normalized.z.ToString();

            rowDataTemp[64 + n] = refer[1].position.x.ToString();
            rowDataTemp[65 + n] = refer[1].position.y.ToString();
            rowDataTemp[66 + n] = refer[1].position.z.ToString();
            rowDataTemp[67 + n] = refer[2].position.x.ToString();
            rowDataTemp[68 + n] = refer[2].position.y.ToString();
            rowDataTemp[69 + n] = refer[2].position.z.ToString();

            rowDataTemp[70 + n] = obj[0].GetComponent<TargetTran>().BallX.x.ToString();
            rowDataTemp[71 + n] = obj[0].GetComponent<TargetTran>().BallX.y.ToString();
            rowDataTemp[72 + n] = obj[0].GetComponent<TargetTran>().BallX.z.ToString();
            rowDataTemp[73 + n] = obj[0].GetComponent<TargetTran>().BallY.x.ToString();
            rowDataTemp[74 + n] = obj[0].GetComponent<TargetTran>().BallY.y.ToString();
            rowDataTemp[75 + n] = obj[0].GetComponent<TargetTran>().BallY.z.ToString();
            rowDataTemp[76 + n] = obj[0].GetComponent<TargetTran>().BallZ.x.ToString();
            rowDataTemp[77 + n] = obj[0].GetComponent<TargetTran>().BallZ.y.ToString();
            rowDataTemp[78 + n] = obj[0].GetComponent<TargetTran>().BallZ.z.ToString();

            rowDataTemp[79 + n] = obj[0].GetComponent<TargetTran>().ready.ToString();

            rowDataTemp[80 + n] = obj[0].GetComponent<TargetTran>().ColNormVec.x.ToString();
            rowDataTemp[81 + n] = obj[0].GetComponent<TargetTran>().ColNormVec.y.ToString();
            rowDataTemp[82 + n] = obj[0].GetComponent<TargetTran>().ColNormVec.z.ToString();
            rowDataTemp[83 + n] = obj[0].GetComponent<TargetTran>().ImpulseVec.x.ToString();
            rowDataTemp[84 + n] = obj[0].GetComponent<TargetTran>().ImpulseVec.y.ToString();
            rowDataTemp[85 + n] = obj[0].GetComponent<TargetTran>().ImpulseVec.z.ToString();
            rowDataTemp[86 + n] = obj[0].GetComponent<TargetTran>().ImpulseForceVec.x.ToString();
            rowDataTemp[87 + n] = obj[0].GetComponent<TargetTran>().ImpulseForceVec.y.ToString();
            rowDataTemp[88 + n] = obj[0].GetComponent<TargetTran>().ImpulseForceVec.z.ToString();

            leng++;
            rowData.Add(rowDataTemp);
        }
    }

    int Direction(Vector3 dest)
    {
        if (dest == obj[0].GetComponent<TargetTran>().BallX)
            return 1;
        else if (dest == obj[0].GetComponent<TargetTran>().BallY)
            return 2;
        else if (dest == obj[0].GetComponent<TargetTran>().BallZ)
            return 3;
        else if (dest == - obj[0].GetComponent<TargetTran>().BallX)
            return 4;
        else if (dest == - obj[0].GetComponent<TargetTran>().BallY)
            return 5;
        else if (dest == - obj[0].GetComponent<TargetTran>().BallZ)
            return 6;

        return 0;
    }

    float Velocity(float velo)
    {
        if (velo == 1.0f)
            return 1;
        else if (velo == 2.0f)
            return 2;
        else if (velo == 2.5f)
            return 2.5f;
        else if (velo == 3.0f)
            return 3;
        else if (velo == 4.0f)
            return 4;
        else if (velo == 6.0f)
            return 6;

        return 0;
    }

    void Setup()
    {
        // Creating First row of titles manually.. 
        string[] rowDataTemp = {
         "Time", "Trial", "Velocity", "Direction", "Collide", "CollideD",
         "ObjName", "PosX", "PosY", "PosZ", "RotX", "RotY", "RotZ", "DestX", "DestY", "DestZ", "Diameter", "Speed", // SoccerBall
         "ObjName", "PosX", "PosY", "PosZ", "RotX", "RotY", "RotZ", // HMD
         "ObjName", "PosX", "PosY", "PosZ", "RotX", "RotY", "RotZ", "Size", "SizeX", "SizeY", "SizeZ", // Plane
         "ObjName", "PosX", "PosY", "PosZ", "RotX", "RotY", "RotZ", "Range", // Light
         "ContactPosX", "ContactPosY", "ContactPosZ", "ContactRelativePosX", "ContactRelativePosY","ContactRelativePosZ",
         "NormalX", "NormalY", "NormalZ",
         "ContactPosXD", "ContactPosYD", "ContactPosZD", "ContactRelativePosXD", "ContactRelativePosYD","ContactRelativePosZD",
         "PlaneRightX", "PlaneRightY", "PlaneRightZ", "PlaneUpX", "PlaneUpY", "PlaneUpZ", "PlaneForwardX", "PlaneForwardY", "PlaneForwardZ",
         "FrontPlaneX", "FrontPlaneY", "FrontPlaneZ", "BackPlaneX", "BackPlaneY", "BackPlaneZ",
         "BallX_X", "BallX_Y", "BallX_Z", "BallY_X", "BallY_Y", "BallY_Z", "BallZ_X", "BallZ_Y", "BallZ_Z",
         "Ready", "ColNormVecX", "ColNormVecY", "ColNormVecZ", "ImpulseVecX", "ImpulseVecY", "ImpulseVecZ",
         "ImpulseForceVecX", "ImpulseForceVecY", "ImpulseForceVecZ"
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