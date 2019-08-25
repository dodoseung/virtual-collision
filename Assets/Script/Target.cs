using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool CollisionDetection;
    public int TargetVelocity;
    public float SphereVelocity;

    void Start()
    {
        CollisionDetection = false;
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
            else if (TargetVelocity == 3 && SphereVelocity > 4f)
            {
                PilotCSV(this.transform.position, collision.contacts[0].point, SphereVelocity);
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
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
            else if (TargetVelocity == 3 && SphereVelocity > 4f)
            {
                PilotCSV(this.transform.position, collision.contacts[0].point, SphereVelocity);
                BroadcastMessage("Explode");
                CollisionDetection = true;
            }
        }
    }

    void PilotCSV(Vector3 _PointTarget, Vector3 _PointCollision, float _Velocity)
    {
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().PointTarget = _PointTarget;
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().PointCollision = _PointCollision;
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().Velocity = _Velocity;
        GameObject.Find("PilotCSV").GetComponent<PilotCSV>().LoggingData();
    }
}
