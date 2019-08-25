using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject TargetController;
    public int Trial, MaxTrial = 30, AllTrial, SetTrial;
    public int TargetVelocity;
    public float Friction, Bounciness;
    public bool Integration;
    public bool TargetCollision;
    public int[] ShuffleList = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};

    void Start()
    {
        AllTrial = 0;
        Trial = AllTrial % MaxTrial;
        SetTrial = AllTrial / MaxTrial;

        ShuffleArray<int>(ShuffleList);
        VariableSetup(ShuffleList[SetTrial]);
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

            VariableSetup(SetTrial);
        }
    }

    void VariableSetup(int SetTrial)
    {
        if (SetTrial / 8 % 2 == 0)
            Integration = false;
        else if (SetTrial / 8 % 2 == 1)
            Integration = true;

        if (SetTrial / 4 % 2 == 0)
            TargetVelocity = 1;
        else if (SetTrial / 4 % 2 == 1)
            TargetVelocity = 3;

        if (SetTrial / 2 % 2 == 0)
            Friction = 0f;
        else if (SetTrial / 2 % 2 == 1)
            Friction = 0.5f;

        if (SetTrial / 1 % 2 == 0)
            Bounciness = 0f;
        else if (SetTrial / 1 % 2 == 1)
            Bounciness = 0.5f;

        this.GetComponent<SphereController>().Integration = Integration;
        TargetController.GetComponent<TargetController>().TargetVelocity = TargetVelocity;
        this.GetComponent<SphereController>().Friction = Friction;
        this.GetComponent<SphereController>().Bounciness = Bounciness;
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
