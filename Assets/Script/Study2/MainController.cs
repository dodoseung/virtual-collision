using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    public GameObject TargetController, Status, Sphere;
    public int Trial, MaxTrial = 30, AllTrial, SetTrial;
    public int TargetVelocity;
    public float Friction, Bounciness;
    public bool Integration, Model1_Normal = true, Model2_Integ;
    public bool TargetCollision;
    public int[] ShuffleList;

    int[] ShuffleListNormal = { 0, 1, 2, 3, 4, 5, 6, 7 }, ShuffleListInteg = {8, 9, 10, 11, 12, 13, 14, 15};

    void Start()
    {
        AllTrial = 0;
        Trial = AllTrial % MaxTrial;
        SetTrial = AllTrial / MaxTrial;

        ShuffleArray<int>(ShuffleListNormal);
        ShuffleArray<int>(ShuffleListInteg);

        if (Model2_Integ && !Model1_Normal)
        {
            ShuffleList = ShuffleListInteg;
        }
        else if (Model1_Normal && !Model2_Integ)
        {
            ShuffleList = ShuffleListNormal;
        }
        else
        {
            Debug.Log("Check the model");
        }

        VariableSetup();
    }

    // Update is called once per frame
    void Update()
    {
        TargetCollision = TargetController.GetComponent<TargetController>().TargetCollision;

        if (TargetCollision)
        {
            AllTrial++;
            Trial = AllTrial % MaxTrial;
            SetTrial = AllTrial / MaxTrial;

            VariableSetup();
        }
    }

    public void VariableSetup()
    {
        if (ShuffleList[SetTrial] / 8 % 2 == 0)
            Integration = false;
        else if (ShuffleList[SetTrial] / 8 % 2 == 1)
            Integration = true;

        if (ShuffleList[SetTrial] / 4 % 2 == 0)
            TargetVelocity = 1;
        else if (ShuffleList[SetTrial] / 4 % 2 == 1)
            TargetVelocity = 2;

        if (ShuffleList[SetTrial] / 2 % 2 == 0)
            Friction = 0f;
        else if (ShuffleList[SetTrial] / 2 % 2 == 1)
            Friction = 0.5f;

        if (ShuffleList[SetTrial] / 1 % 2 == 0)
            Bounciness = 0f;
        else if (ShuffleList[SetTrial] / 1 % 2 == 1)
            Bounciness = 0.5f;

        this.GetComponent<SphereController>().Integration = Integration;
        TargetController.GetComponent<TargetController>().TargetVelocity = TargetVelocity;
        this.GetComponent<SphereController>().Friction = Friction;
        this.GetComponent<SphereController>().Bounciness = Bounciness;

        Debug.Log("All: " + AllTrial.ToString() + " Set: " + SetTrial.ToString() + " Trial: " + Trial.ToString());
        Debug.Log("List: " + ShuffleList[SetTrial].ToString() + " / Integration: " + Integration.ToString() +
            " / TargetVel: " + TargetVelocity.ToString() + " / Friction: " + Friction.ToString() + " / Bounciness: " + Bounciness.ToString());
    }

    public static void ShuffleArray<T>(T[] array)
    {
        int random1;
        int random2;

        T tmp;

        for (int index = 0; index < array.Length; ++index)
        {
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);

            tmp = array[random1];
            array[random1] = array[random2];
            array[random2] = tmp;
        }
    }
}
