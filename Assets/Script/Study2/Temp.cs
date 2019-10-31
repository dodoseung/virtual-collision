using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] rowDataTemp = {
         "Time", "AllTrial", "MaxTrial", "SetTrial", "Trial", "Model1_Normal", "Model2_Integ", // Main Controller
         "integration", "TargetVelocity", "Friction", "Bounciness", "MainTargetCollision",
         "SpherePosX", "SpherePosY", "SpherePosZ", "SphereDistance", "SphereSpeed", // Sphere Controller
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
         "SphereScaleX", "SphereScaleY", "SphereScaleZ", "SphereRightX", "SphereRightY", "SphereRightZ", // 6
         "SphereUpX", "SphereUpY", "SphereUpZ", "SphereFowardX", "SphereFowardY", "SphereFowardZ", // 6
         "SphereRadius", "SphereColorR", "SphereColorG", "SphereColorB", // 4
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
         "LightRange", "LightIntensity", "LightColorR", "LightColorG", "LightColorB" // 5
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
