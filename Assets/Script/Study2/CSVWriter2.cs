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
    bool flip = true;

    // Use this for initialization
    void Start()
    {
        flip = true;
        Setup();
    }

    void Update()
    {
        if (TestController.GetComponent<MainController>().SetTrial == 8)
        {
            Save(8);
            Debug.Log("Saved");
        }
        else
        {
            Target = GameObject.Find("Target(Clone)");

            string[] rowDataTemp = new string[listLength];

            // Time
            timer += Time.deltaTime;
            rowDataTemp[0] = timer.ToString();

            // Test Controller (Main Controller)
            rowDataTemp[1] = TestController.GetComponent<MainController>().AllTrial.ToString();
            rowDataTemp[2] = TestController.GetComponent<MainController>().MaxTrial.ToString();
            rowDataTemp[3] = TestController.GetComponent<MainController>().SetTrial.ToString();
            rowDataTemp[4] = TestController.GetComponent<MainController>().Trial.ToString();
            rowDataTemp[5] = Convert.ToInt32(TestController.GetComponent<MainController>().Model1_Normal).ToString();
            rowDataTemp[6] = Convert.ToInt32(TestController.GetComponent<MainController>().Model2_Integ).ToString();

            rowDataTemp[7] = Convert.ToInt32(TestController.GetComponent<MainController>().Integration).ToString();
            rowDataTemp[8] = TestController.GetComponent<MainController>().TargetVelocity.ToString();
            rowDataTemp[9] = TestController.GetComponent<MainController>().Friction.ToString();
            rowDataTemp[10] = TestController.GetComponent<MainController>().Bounciness.ToString();

            rowDataTemp[11] = Convert.ToInt32(TestController.GetComponent<MainController>().TargetCollision).ToString();

            // Test Controller (Sphere Controller)
            rowDataTemp[12] = TestController.GetComponent<SphereController>().SpherePos.x.ToString();
            rowDataTemp[13] = TestController.GetComponent<SphereController>().SpherePos.y.ToString();
            rowDataTemp[14] = TestController.GetComponent<SphereController>().SpherePos.z.ToString();
            rowDataTemp[15] = TestController.GetComponent<SphereController>().SphereDistance.ToString();
            rowDataTemp[16] = TestController.GetComponent<SphereController>().SphereSpeed.ToString();

            // Target Controller
            rowDataTemp[17] = TargetController.GetComponent<TargetController>().TargetColor.color.r.ToString();
            rowDataTemp[18] = TargetController.GetComponent<TargetController>().TargetColor.color.g.ToString();
            rowDataTemp[19] = TargetController.GetComponent<TargetController>().TargetColor.color.b.ToString();
            rowDataTemp[20] = TargetController.GetComponent<TargetController>().HmdPos.x.ToString();
            rowDataTemp[21] = TargetController.GetComponent<TargetController>().HmdPos.y.ToString();
            rowDataTemp[22] = TargetController.GetComponent<TargetController>().HmdPos.z.ToString();
            rowDataTemp[23] = TargetController.GetComponent<TargetController>().HmdFoward.x.ToString();
            rowDataTemp[24] = TargetController.GetComponent<TargetController>().HmdFoward.y.ToString();
            rowDataTemp[25] = TargetController.GetComponent<TargetController>().HmdFoward.z.ToString();
            rowDataTemp[26] = TargetController.GetComponent<TargetController>().HmdRight.x.ToString();
            rowDataTemp[27] = TargetController.GetComponent<TargetController>().HmdRight.y.ToString();
            rowDataTemp[28] = TargetController.GetComponent<TargetController>().HmdRight.z.ToString();
            rowDataTemp[29] = TargetController.GetComponent<TargetController>().HmdUp.x.ToString();
            rowDataTemp[30] = TargetController.GetComponent<TargetController>().HmdUp.y.ToString();
            rowDataTemp[31] = TargetController.GetComponent<TargetController>().HmdUp.z.ToString();
            rowDataTemp[32] = TargetController.GetComponent<TargetController>().TargetPos.x.ToString();
            rowDataTemp[33] = TargetController.GetComponent<TargetController>().TargetPos.y.ToString();
            rowDataTemp[34] = TargetController.GetComponent<TargetController>().TargetPos.z.ToString();
            rowDataTemp[35] = TargetController.GetComponent<TargetController>().TargetQuat.eulerAngles.x.ToString();
            rowDataTemp[36] = TargetController.GetComponent<TargetController>().TargetQuat.eulerAngles.y.ToString();
            rowDataTemp[37] = TargetController.GetComponent<TargetController>().TargetQuat.eulerAngles.z.ToString();
            rowDataTemp[38] = TargetController.GetComponent<TargetController>().TargetColor.color.r.ToString();
            rowDataTemp[39] = TargetController.GetComponent<TargetController>().TargetColor.color.g.ToString();
            rowDataTemp[40] = TargetController.GetComponent<TargetController>().TargetColor.color.b.ToString();
            rowDataTemp[41] = TargetController.GetComponent<TargetController>().TargetVelocity.ToString();
            rowDataTemp[42] = TargetController.GetComponent<TargetController>().UpperBound.ToString();
            rowDataTemp[43] = TargetController.GetComponent<TargetController>().LowerBound.ToString();
            rowDataTemp[44] = TargetController.GetComponent<TargetController>().Zoffset.ToString();

            // Plane
            rowDataTemp[45] = Plane.name;
            rowDataTemp[46] = Plane.transform.position.x.ToString();
            rowDataTemp[47] = Plane.transform.position.y.ToString();
            rowDataTemp[48] = Plane.transform.position.z.ToString();
            rowDataTemp[49] = Plane.transform.eulerAngles.x.ToString();
            rowDataTemp[50] = Plane.transform.eulerAngles.y.ToString();
            rowDataTemp[51] = Plane.transform.eulerAngles.z.ToString();
            rowDataTemp[52] = Plane.transform.lossyScale.x.ToString();
            rowDataTemp[53] = Plane.transform.lossyScale.y.ToString();
            rowDataTemp[54] = Plane.transform.lossyScale.z.ToString();

            rowDataTemp[55] = Plane.transform.right.x.ToString();
            rowDataTemp[56] = Plane.transform.right.y.ToString();
            rowDataTemp[57] = Plane.transform.right.z.ToString();
            rowDataTemp[58] = Plane.transform.up.x.ToString();
            rowDataTemp[59] = Plane.transform.up.y.ToString();
            rowDataTemp[60] = Plane.transform.up.z.ToString();
            rowDataTemp[61] = Plane.transform.forward.x.ToString();
            rowDataTemp[62] = Plane.transform.forward.y.ToString();
            rowDataTemp[63] = Plane.transform.forward.z.ToString();

            rowDataTemp[64] = Plane.GetComponent<Rigidbody>().velocity.x.ToString();
            rowDataTemp[65] = Plane.GetComponent<Rigidbody>().velocity.y.ToString();
            rowDataTemp[66] = Plane.GetComponent<Rigidbody>().velocity.z.ToString();
            rowDataTemp[67] = Plane.GetComponent<Rigidbody>().velocity.magnitude.ToString();
            rowDataTemp[68] = Plane.GetComponent<Rigidbody>().angularVelocity.x.ToString();
            rowDataTemp[69] = Plane.GetComponent<Rigidbody>().angularVelocity.y.ToString();
            rowDataTemp[70] = Plane.GetComponent<Rigidbody>().angularVelocity.z.ToString();
            rowDataTemp[71] = Plane.GetComponent<Rigidbody>().angularVelocity.magnitude.ToString();
            rowDataTemp[72] = Plane.GetComponent<Rigidbody>().mass.ToString();
            rowDataTemp[73] = Plane.GetComponent<Rigidbody>().drag.ToString();
            rowDataTemp[74] = Plane.GetComponent<Rigidbody>().angularDrag.ToString();
            rowDataTemp[75] = Plane.GetComponent<Rigidbody>().useGravity.ToString();
            rowDataTemp[76] = Plane.GetComponent<Rigidbody>().isKinematic.ToString();
            rowDataTemp[77] = Plane.GetComponent<Rigidbody>().interpolation.ToString();
            rowDataTemp[78] = Plane.GetComponent<Rigidbody>().collisionDetectionMode.ToString();

            // Sphere
            rowDataTemp[79] = Sphere.name;
            rowDataTemp[80] = Sphere.transform.position.x.ToString();
            rowDataTemp[81] = Sphere.transform.position.y.ToString();
            rowDataTemp[82] = Sphere.transform.position.z.ToString();
            rowDataTemp[83] = Sphere.transform.eulerAngles.x.ToString();
            rowDataTemp[84] = Sphere.transform.eulerAngles.y.ToString();
            rowDataTemp[85] = Sphere.transform.eulerAngles.z.ToString();
            rowDataTemp[86] = Sphere.transform.lossyScale.x.ToString();
            rowDataTemp[87] = Sphere.transform.lossyScale.y.ToString();
            rowDataTemp[88] = Sphere.transform.lossyScale.z.ToString();
            rowDataTemp[89] = Sphere.GetComponent<SphereCollider>().radius.ToString();
            rowDataTemp[90] = Sphere.GetComponent<Renderer>().material.color.r.ToString();
            rowDataTemp[91] = Sphere.GetComponent<Renderer>().material.color.g.ToString();
            rowDataTemp[92] = Sphere.GetComponent<Renderer>().material.color.b.ToString();

            rowDataTemp[93] = Sphere.GetComponent<Rigidbody>().velocity.x.ToString();
            rowDataTemp[94] = Sphere.GetComponent<Rigidbody>().velocity.y.ToString();
            rowDataTemp[95] = Sphere.GetComponent<Rigidbody>().velocity.z.ToString();
            rowDataTemp[96] = Sphere.GetComponent<Rigidbody>().velocity.magnitude.ToString();
            rowDataTemp[97] = Sphere.GetComponent<Rigidbody>().angularVelocity.x.ToString();
            rowDataTemp[98] = Sphere.GetComponent<Rigidbody>().angularVelocity.y.ToString();
            rowDataTemp[99] = Sphere.GetComponent<Rigidbody>().angularVelocity.z.ToString();
            rowDataTemp[100] = Sphere.GetComponent<Rigidbody>().angularVelocity.magnitude.ToString();
            rowDataTemp[101] = Sphere.GetComponent<Rigidbody>().mass.ToString();
            rowDataTemp[102] = Sphere.GetComponent<Rigidbody>().drag.ToString();
            rowDataTemp[103] = Sphere.GetComponent<Rigidbody>().angularDrag.ToString();
            rowDataTemp[104] = Sphere.GetComponent<Rigidbody>().useGravity.ToString();
            rowDataTemp[105] = Sphere.GetComponent<Rigidbody>().isKinematic.ToString();
            rowDataTemp[106] = Sphere.GetComponent<Rigidbody>().interpolation.ToString();
            rowDataTemp[107] = Sphere.GetComponent<Rigidbody>().collisionDetectionMode.ToString();

            rowDataTemp[108] = Convert.ToInt32(Sphere.GetComponent<Impact>().PlaneTouch).ToString();
            rowDataTemp[109] = Sphere.GetComponent<Impact>().Impulse.x.ToString();
            rowDataTemp[110] = Sphere.GetComponent<Impact>().Impulse.y.ToString();
            rowDataTemp[111] = Sphere.GetComponent<Impact>().Impulse.z.ToString();
            rowDataTemp[112] = Sphere.GetComponent<Impact>().pk.x.ToString();
            rowDataTemp[113] = Sphere.GetComponent<Impact>().pk.y.ToString();
            rowDataTemp[114] = Sphere.GetComponent<Impact>().pk.z.ToString();
            rowDataTemp[115] = Sphere.GetComponent<Impact>().vk.x.ToString();
            rowDataTemp[116] = Sphere.GetComponent<Impact>().vk.y.ToString();
            rowDataTemp[117] = Sphere.GetComponent<Impact>().vk.z.ToString();
            rowDataTemp[118] = Sphere.GetComponent<Impact>().Speed.ToString();
            rowDataTemp[119] = Sphere.GetComponent<Impact>().Direction.x.ToString();
            rowDataTemp[120] = Sphere.GetComponent<Impact>().Direction.y.ToString();
            rowDataTemp[121] = Sphere.GetComponent<Impact>().Direction.z.ToString();
            rowDataTemp[122] = Sphere.GetComponent<Impact>().Magnitude.ToString();

            rowDataTemp[123] = Sphere.GetComponent<Impact>().a1.ToString();
            rowDataTemp[124] = Sphere.GetComponent<Impact>().b1.ToString();
            rowDataTemp[125] = Sphere.GetComponent<Impact>().a2.ToString();
            rowDataTemp[126] = Sphere.GetComponent<Impact>().b2.ToString();
            rowDataTemp[127] = Sphere.GetComponent<Impact>().Sigma_pk.ToString();
            rowDataTemp[128] = Sphere.GetComponent<Impact>().Sigma_vk.ToString();
            rowDataTemp[129] = Sphere.GetComponent<Impact>().Denom.ToString();
            rowDataTemp[130] = Sphere.GetComponent<Impact>().W_pk.ToString();
            rowDataTemp[131] = Sphere.GetComponent<Impact>().W_vk.ToString();
            rowDataTemp[132] = Sphere.GetComponent<Impact>().IntegratedVector.x.ToString();
            rowDataTemp[133] = Sphere.GetComponent<Impact>().IntegratedVector.y.ToString();
            rowDataTemp[134] = Sphere.GetComponent<Impact>().IntegratedVector.z.ToString();

            // Target
            rowDataTemp[135] = Target.name;
            rowDataTemp[136] = Target.transform.position.x.ToString();
            rowDataTemp[137] = Target.transform.position.y.ToString();
            rowDataTemp[138] = Target.transform.position.z.ToString();
            rowDataTemp[139] = Target.transform.eulerAngles.x.ToString();
            rowDataTemp[140] = Target.transform.eulerAngles.y.ToString();
            rowDataTemp[141] = Target.transform.eulerAngles.z.ToString();
            rowDataTemp[142] = Target.transform.lossyScale.x.ToString();
            rowDataTemp[143] = Target.transform.lossyScale.y.ToString();
            rowDataTemp[144] = Target.transform.lossyScale.z.ToString();

            rowDataTemp[145] = Target.transform.right.x.ToString();
            rowDataTemp[146] = Target.transform.right.y.ToString();
            rowDataTemp[147] = Target.transform.right.z.ToString();
            rowDataTemp[148] = Target.transform.up.x.ToString();
            rowDataTemp[149] = Target.transform.up.y.ToString();
            rowDataTemp[150] = Target.transform.up.z.ToString();
            rowDataTemp[151] = Target.transform.forward.x.ToString();
            rowDataTemp[152] = Target.transform.forward.y.ToString();
            rowDataTemp[153] = Target.transform.forward.z.ToString();

            rowDataTemp[154] = Target.GetComponent<Rigidbody>().mass.ToString();
            rowDataTemp[155] = Target.GetComponent<Rigidbody>().drag.ToString();
            rowDataTemp[156] = Target.GetComponent<Rigidbody>().angularDrag.ToString();
            rowDataTemp[157] = Target.GetComponent<Rigidbody>().useGravity.ToString();
            rowDataTemp[158] = Target.GetComponent<Rigidbody>().isKinematic.ToString();
            rowDataTemp[159] = Target.GetComponent<Rigidbody>().interpolation.ToString();
            rowDataTemp[160] = Target.GetComponent<Rigidbody>().collisionDetectionMode.ToString();

            rowDataTemp[161] = Target.GetComponent<Target>().SphereVelocity.ToString();
            rowDataTemp[162] = Target.GetComponent<Target>().TargetVelocity.ToString();
            rowDataTemp[163] = Target.GetComponent<Target>().CollisionPoint.x.ToString();
            rowDataTemp[164] = Target.GetComponent<Target>().CollisionPoint.y.ToString();
            rowDataTemp[165] = Target.GetComponent<Target>().CollisionPoint.z.ToString();
            rowDataTemp[166] = Target.GetComponent<Target>().TargetImpulse.x.ToString();
            rowDataTemp[167] = Target.GetComponent<Target>().TargetImpulse.y.ToString();
            rowDataTemp[168] = Target.GetComponent<Target>().TargetImpulse.z.ToString();
            rowDataTemp[169] = Convert.ToInt32(Target.GetComponent<Target>().CollisionDetection).ToString();
            rowDataTemp[170] = Convert.ToInt32(Target.GetComponent<Target>().AllCollisionDetection).ToString();

            // Light
            rowDataTemp[171] = Light.name;
            rowDataTemp[172] = Light.transform.position.x.ToString();
            rowDataTemp[173] = Light.transform.position.y.ToString();
            rowDataTemp[174] = Light.transform.position.z.ToString();
            rowDataTemp[175] = Light.transform.eulerAngles.x.ToString();
            rowDataTemp[176] = Light.transform.eulerAngles.y.ToString();
            rowDataTemp[177] = Light.transform.eulerAngles.z.ToString();
            rowDataTemp[178] = Light.GetComponent<Light>().range.ToString();
            rowDataTemp[179] = Light.GetComponent<Light>().intensity.ToString();
            rowDataTemp[180] = Light.GetComponent<Light>().color.r.ToString();
            rowDataTemp[181] = Light.GetComponent<Light>().color.g.ToString();
            rowDataTemp[182] = Light.GetComponent<Light>().color.b.ToString();

            // Plus
            rowDataTemp[183] = TargetController.GetComponent<TargetController>().Xoffset.ToString();
            rowDataTemp[184] = TargetController.GetComponent<TargetController>().Yoffset.ToString();
            rowDataTemp[185] = TargetController.GetComponent<TargetController>().XRandom.ToString();
            rowDataTemp[186] = TargetController.GetComponent<TargetController>().YRandom.ToString();
            rowDataTemp[187] = TargetController.GetComponent<TargetController>().ZRandom.ToString();

            rowDataTemp[188] = Convert.ToInt32(Plane.GetComponent<PlaneCollision>().col).ToString();

            leng++;
            rowData.Add(rowDataTemp);
        }

        if (TestController.GetComponent<MainController>().SetTrial == 2 && flip)
        {
            Save(2);
            Debug.Log("Saved");
            flip = !flip;
            Setup();
        }
        else if (TestController.GetComponent<MainController>().SetTrial == 4 && !flip)
        {
            Save(4);
            Debug.Log("Saved");
            flip = !flip;
            Setup();
        }
        else if (TestController.GetComponent<MainController>().SetTrial == 6 && flip)
        {
            Save(6);
            Debug.Log("Saved");
            flip = !flip;
            Setup();
        }
    }

    void Setup()
    {
        rowData = new List<string[]>();

        // Creating First row of titles manually.. 
        string[] rowDataTemp = {
         "Time", "AllTrial", "MaxTrial", "SetTrial", "Trial", "Model1_Normal", "Model2_Integ", // Main Controller
         "integration", "TargetVelocity", "Friction", "Bounciness", "MainTargetCollision",
         "SpherePosVarX", "SpherePosVarY", "SpherePosVarZ", "SphereDistance", "SphereSpeed", // Sphere Controller
         "TargetColorR", "TargetColorG", "TargetColorB", "HmdPosX", "HmdPosY", "HmdPosZ", // Target Controller
         "HmdFowardX", "HmdFowardY", "HmdFowardZ", "HmdRightX", "HmdRightY", "HmdRightZ",
         "HmdUpX", "HmdUpY", "HmdUpZ", "TargetPosX", "TargetPosY", "TargetPosZ", "TargetRotX", "TargetRotY", "TargetRotZ",
         "TargetColorR", "TargetColorG", "TargetColorB", "TargetVelocity", "UpperBound", "LowerBound", "Zoffset",
         "PlaneName", "PlanePosX", "PlanePosY", "PlanePosZ", "PlaneRotX", "PlaneRotY", "PlaneRotZ", // 7 Plane
         "PlaneScaleX", "PlaneScaleY", "PlaneScaleZ", "PlaneRightX", "PlaneRightY", "PlaneRightZ", // 6
         "PlaneUpX", "PlaneUpY", "PlaneUpZ", "PlaneFowardX", "PlaneFowardY", "PlaneFowardZ", // 6
         "PlaneVelX", "PlaneVelY", "PlaneVelZ", "PlaneVel", "PlaneAngVelX", "PlaneAngVelY", "PlaneAngVelZ", "PlaneAngVel", // 8
         "PlaneMass", "PlaneDrag", "PlaneAngDrag", "PlaneUseG", "PlaneIsKin", "PlaneInterpol", "PlaneColMode", // 7
         "SphereName", "SpherePosX", "SpherePosY", "SpherePosZ", "SphereRotX", "SphereRotY", "SphereRotZ", // 7 Sphere
         "SphereScaleX", "SphereScaleY", "SphereScaleZ", "SphereRadius", "SphereColorR", "SphereColorG", "SphereColorB", // 7
         "SphereVelX", "SphereVelY", "SphereVelZ", "SphereVel", "SphereAngVelX", "SphereAngVelY", "SphereAngVelZ", "SphereAngVel", // 8
         "SphereMass", "SphereDrag", "SphereAngDrag", "SphereUseG", "SphereIsKin", "SphereInterpol", "SphereColMode", // 7
         "PlaneTouch", "SphereImpulseX", "SphereImpulseY", "SphereImpulseZ", "pkX", "pkY", "pkZ", "vkX", "vkY", "vkZ", // 10
         "IntegInputSpeed", "DirectionX", "DirectionY", "DirectionZ", "ImpulseMagnitude", // 5
         "a1", "b1", "a2", "b2", "Sigma_pk", "Sigma_vk", "Denom", "W_pk", "W_vk", "IntegVecX", "IntegVecY", "IntegVecZ", // 12
         "TargetName", "TargetPosX", "TargetPosY", "TargetPosZ", "TargetRotX", "TargetRotY", "TargetRotZ", // 7 Target
         "TargetScaleX", "TargetScaleY", "TargetScaleZ", "TargetRightX", "TargetRightY", "TargetRightZ", // 6
         "TargetUpX", "TargetUpY", "TargetUpZ", "TargetFowardX", "TargetFowardY", "TargetFowardZ", // 6
         "TargetMass", "TargetDrag", "TargetAngDrag", "TargetUseG", "TargetIsKin", "TargetInterpol", "TargetColMode", // 7
         "TargetSphereVel", "TargetVelocity", "ColPosX", "ColPosY", "ColPosZ", // 5
         "TargetImpulseX", "TargetImpulseY", "TargetImpulseZ", "TargetCollisionDetection", "TargetAllCollisionDetection", // 5
         "LightName", "LightPosX", "LightPosY", "LightPosZ", "LightRotX", "LightRotY", "LightRotZ", // 7 Light
         "LightRange", "LightIntensity", "LightColorR", "LightColorG", "LightColorB", // 5
         "Xoffset", "Yoffset", "XRandom", "YRandom", "ZRandom", "PlaneCol"
        };

        listLength = rowDataTemp.Length;

        rowData.Add(rowDataTemp);
    }

    void Save(int num)
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


        string filePath = getPath(num);

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(int num)
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data" + num.ToString() + ".csv";
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