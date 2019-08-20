using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetTran : MonoBehaviour
{
    public GameObject HitText;
    public bool collide = false, collideD = false, ready = false, LookOnce = false, TextReady = false, BallChangeTerm = false;
    public Vector3 destPos, ContactPoint, ContactRelativePoint, ContactPointD, ContactRelativePointD;
    public Vector3 ColNormVec, ImpulseVec, ImpulseForceVec;
    public float BallSpeed;
    public int trial = 0, settrial, MaxTrial;
    public Vector3 BallPos, BallX, BallY, BallZ;
    public int[] ShuffleList = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35 };

    bool ColCheck = false;

    private void OnEnable()
    {
        settrial = -1;
        ShuffleArray<int>(ShuffleList);
        ready = true;
        Invoke("ChangeDestPos", 0.3f);
    }

    void Update()
    {
        float PlaneHeight = GameObject.Find("Plane").transform.position.y;

        if (PlaneHeight < (BallPos.y - 0.3f) && !LookOnce)
        {
            ready = false;
        }

        if (!ready)
        {
            if(Vector3.Distance(BallPos, transform.position) < 2)
            {
                transform.Translate(destPos.normalized * Time.deltaTime * BallSpeed);
            }
            else
            {
                TextReady = true;
                ready = true;
                LookOnce = true;
                BallChangeTerm = true;
                transform.position = BallPos;
            }
        }

        DetectContactByDistance();
        CollideDCheck();
        HitText.SetActive(ready && TextReady);

        //Debug.Log(collideD.ToString() + ContactRelativePointD.ToString("F4") + ContactPointD.ToString("F4"));
    }

    void ChangeDestPos()
    {
        transform.position = BallPos;

        trial = 0;
        settrial++;

        BallChangeTerm = false;

        if (settrial < 36)
        {
            switch (ShuffleList[settrial] / 18)
            {
                case 0:
                    transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
                    break;
                case 1:
                    transform.localScale = new Vector3(0.20f, 0.20f, 0.20f);
                    break;
            }

            switch (ShuffleList[settrial] / 6)
            {
                case 0:
                    BallSpeed = 1f;
                    break;
                case 1:
                    BallSpeed = 2.5f;
                    break;
                case 2:
                    BallSpeed = 6f;
                    break;
                case 3:
                    BallSpeed = 1f;
                    break;
                case 4:
                    BallSpeed = 2.5f;
                    break;
                case 5:
                    BallSpeed = 6f;
                    break;
            }

            switch (ShuffleList[settrial] % 6)
            {
                case 0:
                    destPos = BallX;
                    break;
                case 1:
                    destPos = BallY;
                    break;
                case 2:
                    destPos = BallZ;
                    break;
                case 3:
                    destPos = -BallX;
                    break;
                case 4:
                    destPos = -BallY;
                    break;
                case 5:
                    destPos = -BallZ;
                    break;
            }

            Debug.Log("Speed: " + BallSpeed.ToString() + " / Dest: " + (ShuffleList[settrial] % 6 + 1).ToString() + " / Size: " + transform.localScale.ToString("F2"));
        }

        
    }

    void ChangeLookOnce()
    {
        LookOnce = false;
    }

    public static Vector3 getRelativePosition(Transform origin, Vector3 position)
    {
        Vector3 distance = position - origin.position;
        Vector3 relativePosition = Vector3.zero;
        relativePosition.x = Vector3.Dot(distance, origin.right.normalized);
        relativePosition.y = Vector3.Dot(distance, origin.up.normalized);
        relativePosition.z = Vector3.Dot(distance, origin.forward.normalized);

        return relativePosition;
    }

    // Distance between plane to point
    public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
    {
        float distance;
        Vector3 translationVector;
       
        distance = SignedDistancePlanePoint(planeNormal, planePoint, point);
        distance *= -1;
        translationVector = SetVectorLength(planeNormal, distance);
        return point + translationVector;
    }

    //Get the shortest distance between a point and a plane. The output is signed so it holds information
    //as to which side of the plane normal the point is.
    public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
    {
        return Vector3.Dot(planeNormal, (point - planePoint));
    }

    //create a vector of direction "vector" with length "size"
    public static Vector3 SetVectorLength(Vector3 vector, float size)
    {
        Vector3 vectorNormalized = Vector3.Normalize(vector);
        return vectorNormalized *= size;
    }

    void DetectContactByDistance()
    {
        Transform plane = GameObject.Find("Plane").transform;
        Transform Fplane = GameObject.Find("FrontBoard").transform;
        SphereCollider myCollider = GetComponent<SphereCollider>();
        Vector3 planeSurf = plane.position + Fplane.localScale.z * plane.forward.normalized;

        if (Mathf.Abs(SignedDistancePlanePoint(plane.forward, planeSurf, transform.position)) <= transform.localScale.x * myCollider.radius && ready && BallChangeTerm && TextReady)
        {
            ContactPointD = ProjectPointOnPlane(plane.rotation * Vector3.forward, planeSurf, transform.position);
            ContactRelativePointD = getRelativePosition(GameObject.Find("Plane").transform, ContactPointD);
            //ContactRelativePointD.z = 0;

            // For calculating minimum length between plane and ball when perpendicular point is located at out of plane
            float NormDenom;
            if (Mathf.Abs(ContactRelativePointD.x / (Fplane.localScale.x / 2)) > Mathf.Abs(ContactRelativePointD.y / (Fplane.localScale.y / 2)))
                NormDenom = Mathf.Abs(ContactRelativePointD.x / (Fplane.localScale.x / 2));
            else
                NormDenom = Mathf.Abs(ContactRelativePointD.y / (Fplane.localScale.y / 2));
            float BotLen = Mathf.Sqrt(Mathf.Pow(ContactRelativePointD.x,2) + Mathf.Pow(ContactRelativePointD.y, 2)) * (NormDenom - 1) / NormDenom;
            //ContactRelativePointD.magnitude * (NormDenom - 1) / NormDenom;

            // If a distance between the plane and the ball is lower than radius, collideD is true. 
            if (Mathf.Abs(ContactRelativePointD.x) < Fplane.localScale.x / 2 && Mathf.Abs(ContactRelativePointD.y) < Fplane.localScale.y / 2)
                collideD = true;
            else if (Math.Sqrt(Math.Pow(SignedDistancePlanePoint(plane.forward, planeSurf, transform.position), 2) + Math.Pow(BotLen, 2)) <= transform.localScale.x * myCollider.radius)
            {
                ContactPointD = planeSurf * (NormDenom - 1) / NormDenom + ContactPointD * 1 / NormDenom;
                ContactRelativePointD = getRelativePosition(GameObject.Find("Plane").transform, ContactPointD);
                collideD = true;
            }
            else
            {
                ContactPointD = Vector3.zero;
                ContactRelativePointD = Vector3.zero;
                collideD = false;
            } 
        }
        else
        {
            ContactPointD = Vector3.zero;
            ContactRelativePointD = Vector3.zero;
            collideD = false;
        }
    }

    public Vector3 RotationToNormVect(Transform obj)
    {
        Vector3 Normobj;
        Normobj.x = Mathf.Cos(obj.eulerAngles.x * (float)Math.PI / 180);
        Normobj.y = Mathf.Cos(obj.eulerAngles.y * (float)Math.PI / 180);
        Normobj.z = Mathf.Cos(obj.eulerAngles.z * (float)Math.PI / 180);

        return Normobj.normalized;
    }

    void CollideDCheck()
    {
        if (collideD)
            ColCheck = true;
        else if (ColCheck & !collideD)
        {
            ColCheck = false;
            TextReady = false;
            Invoke("ChangeLookOnce", 1f);
            trial++;

            if (trial == MaxTrial)
            {
                trial--;
                Invoke("ChangeDestPos", 0.5f); // Change dest, reset trial, and up settrial 
            }
        } 
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

    void OnCollisionEnter(Collision collision)
    {
        collide = true;
        ContactPoint = collision.contacts[0].point;
        ContactRelativePoint = getRelativePosition(GameObject.Find("Plane").transform, ContactPoint);
        ColNormVec = collision.contacts[0].normal;
        ImpulseVec = collision.impulse;
        ImpulseForceVec = collision.impulse / Time.fixedDeltaTime;
    }

    void OnCollisionExit(Collision collision)
    {
        ContactPoint = Vector3.zero;
        ContactRelativePoint = Vector3.zero;
        collide = false;
    }
}