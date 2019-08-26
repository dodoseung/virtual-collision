using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool CollisionDetection, AllCollisionDetection;
    public int TargetVelocity;
    public float SphereVelocity;

    void Start()
    {
        CollisionDetection = false;
        AllCollisionDetection = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
        {
            if (TargetVelocity == 1 && SphereVelocity <= 4f)
            {
                PilotCSV(this.transform.position, collision.contacts[0].point, SphereVelocity);
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
            else if (TargetVelocity == 2 && SphereVelocity > 4f)
            {
                PilotCSV(this.transform.position, collision.contacts[0].point, SphereVelocity);
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }

            AllCollisionDetection = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.impulse.Equals(Vector3.zero))
        {
            if (TargetVelocity == 1 && SphereVelocity <= 4f)
            {
                PilotCSV(this.transform.position, collision.contacts[0].point, SphereVelocity);
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
            else if (TargetVelocity == 2 && SphereVelocity > 4f)
            {
                PilotCSV(this.transform.position, collision.contacts[0].point, SphereVelocity);
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }

            AllCollisionDetection = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        AllCollisionDetection = false;
    }

    void PilotCSV(Vector3 _PointTarget, Vector3 _PointCollision, float _Velocity)
    {
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().PointTarget = _PointTarget;
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().PointCollision = _PointCollision;
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().Velocity = _Velocity;
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().LoggingData();
    }
}
