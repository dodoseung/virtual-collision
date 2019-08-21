using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject TargetController;
    public int trial;
    public int TargetVelocity;
    public bool SphereShooting, integration, TargetCollision;

    void Start()
    {
        trial = 0;
        SphereShooting = false;
        TargetVelocity = 1;
        integration = false;
    }

    // Update is called once per frame
    void Update()
    {
        TargetCollision = TargetController.GetComponent<TargetController>().TargetCollision;

        if (TargetCollision)
        {
            trial++;
        }
    }
}
