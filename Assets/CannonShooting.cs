using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CannonShooting : MonoBehaviour
{
    // TrajectoryPoint and Ball will be instantiated
    public GameObject TrajectoryPointPrefeb;
    public GameObject BallPrefb;

    public Transform shootPoint;
    public Transform target;

    private Vector3 targetInitialPosition;

    public Joystick joystick;

    [Range(1,4)]
    public float joystickMovementSpeed;

    private GameObject ball;
    private float power = 1.5f;
    private int numOfTrajectoryPoints = 30;
    private GameObject[] trajectoryPoints;

    

    void Start()
    {
        Time.timeScale = 1;

        targetInitialPosition = target.position;

        InstantiateTrajectoryPoints();

    }

    void InstantiateTrajectoryPoints() {

        trajectoryPoints = new GameObject[numOfTrajectoryPoints];

        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            GameObject dot = (GameObject)Instantiate(TrajectoryPointPrefeb);
            dot.GetComponent<MeshRenderer>().enabled = false;
            trajectoryPoints[i] = dot;
        }
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Began:" + touch.position);
                target.position = targetInitialPosition;

                Vector3 vel = GetForceFrom(shootPoint.position, target.position);

                setTrajectoryPoints(shootPoint.position, vel);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("End:" + touch.position);
                hideTrajectoryPoints();
                
            }

            if (touch.phase == TouchPhase.Moved)
            {
                target.position += new Vector3(joystick.Horizontal * joystickMovementSpeed * 0.5f, 0, joystick.Vertical * joystickMovementSpeed);

                Vector3 vel = GetForceFrom(shootPoint.position, target.position);

                //These 2 line rotate trajectory points towards to target

                setTrajectoryPointsPositions(shootPoint.position, vel);
            }

        }

        //else {
            

        //}

        Debug.Log("joystick horizontal: " + joystick.Horizontal + "\nJoystick vertical: " + joystick.Vertical);

        if (Input.GetMouseButtonDown(0))
        {
            createBall();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            throwBall();
        }



        
        //setTrajectoryPoints(shootPoint.position, vel / BallPrefb.GetComponent<Rigidbody>().mass);

    }

    //---------------------------------------    
    // Following method creates new ball
    //---------------------------------------


    private void hideTrajectoryPoints() {
        for (int i = 0; i < numOfTrajectoryPoints; i++) {
            trajectoryPoints[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void createBall()
    {
        ball = (GameObject)Instantiate(BallPrefb);
        Vector3 pos = shootPoint.position;
        //pos.z = 1;
        ball.transform.position = pos;
        ball.SetActive(false);
    }

    //---------------------------------------    
    // Following method gives force to the ball
    //---------------------------------------

    private void throwBall()
    {
        ball.SetActive(true);
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce(GetForceFrom(shootPoint.position, target.position), ForceMode.Impulse);
    }


    private Vector3 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        // Target Position - Start Position
        return ((new Vector3(toPos.x, toPos.y, toPos.z) - new Vector3(fromPos.x, fromPos.y, fromPos.z)) * power);

    }


    void setTrajectoryPointsPositions(Vector3 startPoint, Vector3 velocity)
    {

        //float time = ((Mathf.Abs(velocity.y) / Physics.gravity.magnitude) * 2);

        float fTime = 0.09f;

        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {

            float dz = velocity.z * fTime;
            float dx = velocity.x * fTime;

            float dy = fTime * velocity.y - 0.5f * (Physics.gravity.magnitude * fTime * fTime);


            Vector3 pos = new Vector3(startPoint.x + dx, startPoint.y + dy, startPoint.z + dz);

            trajectoryPoints[i].transform.position = pos;
            trajectoryPoints[i].GetComponent<MeshRenderer>().enabled = true;

            fTime += 0.07f;

        }


    }
    //  */

    void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y) + (pVelocity.z * pVelocity.z));
        Debug.Log("Set trajectory points");
        // float velocity = Mathf.Sqrt((pVelocity.x - pStartPosition.x) + (pVelocity.y - pStartPosition.y) + (pVelocity.z - pStartPosition.z));
        float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));

        //   float angleX, angleY, angleZ;

        //    angleX = Mathf.Rad2Deg * (Vector3.Angle(pVelocity,)));

        float time = (pVelocity.y / Physics.gravity.magnitude) * 2;

        //float dx = pVelocity.x * time;       
        float fTime = 0;

        fTime += 0.1f;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);

            float dy = velocity * fTime - (Physics.gravity.magnitude * fTime * fTime / 2.0f) * Mathf.Sin(angle * Mathf.Deg2Rad);

            float dz = velocity * fTime * Mathf.Tan(angle * Mathf.Deg2Rad);

            Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, pStartPosition.z + dz);
            trajectoryPoints[i].transform.position = pos;
            trajectoryPoints[i].GetComponent<MeshRenderer>().enabled = true;

            trajectoryPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }
}
