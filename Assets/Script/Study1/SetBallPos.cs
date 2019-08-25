using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBallPos : MonoBehaviour
{
    public GameObject hmd, plane, ball;
    public Vector3 BallPos, BallX, BallY, BallZ;

    int buffer = 200, num = 1000, count = 0;
    Vector3 HmdPos, PlanePos;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (count >= buffer)
        {
            HmdPos += hmd.transform.position;
            PlanePos += plane.transform.position;
            BallX += hmd.transform.right;
            BallY += hmd.transform.up;
            BallZ += hmd.transform.forward;
        }

        count++;

        if(count == num)
        {
            HmdPos /= num - buffer;
            PlanePos /= num - buffer;

            BallX /= num - buffer;
            BallY /= num - buffer;
            BallZ /= num - buffer;
            BallPos = 0.2f * HmdPos + 0.8f * PlanePos;

            ball.SetActive(true);
            ball.GetComponent<TargetTran>().BallPos = BallPos;
            ball.GetComponent<TargetTran>().BallX = BallX;
            ball.GetComponent<TargetTran>().BallY = BallY;
            ball.GetComponent<TargetTran>().BallZ = BallZ;

            Destroy(this);
        }
    }
}
