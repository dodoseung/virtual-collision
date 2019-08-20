using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject TargetController;
    public int trial;
    public int SphereShooting, TargetVelocity;
    public bool integration, TargetCollision;

    void Start()
    {
        trial = 0;
        SphereShooting = 0;
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
