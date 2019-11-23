using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    /// <summary>
    ///  There are just 2 possible projectiles :  Bomb & Spike
    ///  These 2 have different characteristics ----
    /// </summary>
    ///

    #region Variables are needed
    public Rigidbody projectile;
   // public TrajectoryRenderer trajectoryRenderer;
    // It mimics mouse cursor
    public GameObject cursor;

    public Joystick joystick;

    public Transform shootPoint;
    public LayerMask layer;

    // Red line - from cannon barrel to the Shoot Point
    public LineRenderer lineVisual;

    [Range(1,20)]
    public int lineSegment = 4;

    private Camera cam;

    


    // Line rendering and launching missile 
    // will work until player's cursor
    // is below positionAllowed

        /*
    [Range(10, 30)]
    public float positionAllowedforTowerRotation;

    [Range(20.45f, 25)]
    public float positionAllowed;

    */


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        lineVisual.positionCount = lineSegment;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, layer))
        {

            cursor.SetActive(true);
            //cursor.transform.position = hit.point + Vector3.up * 0.1f;



            Vector3 vo = new Vector3(joystick.Horizontal * 30, 0, joystick.Vertical * 35);

            //CalculateVelocity(hit.point, shootPoint.position, 1f);
          //  Vector3 vd = new Vector3(joystick.Horizontal + 30, 0, joystick.Vertical + 30);

            // Make red line appear
            
                Visualize(vo);
                // trajectoryRenderer.DrawTrajectoryPoints(transform.position, vo);
            

            vo.y = transform.position.x;

            //Debug.Log("Shoot point - z  == " + cursor.transform.position.z);


            // Tower rotation to the shoot point
            RotateTower(cursor.transform.position.z, cursor.transform.position);


            // It launches projectile acc. to the type
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody obj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
                obj.velocity = vo;


            }
        }
    }

    public void Shoot() {
        Vector3 vo = new Vector3(joystick.Horizontal * 30, 0, joystick.Vertical * 30);

        Rigidbody obj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
        obj.velocity = vo;
    }

    void RotateTower(float currentPosition, Vector3 vo)
    {

            transform.rotation = Quaternion.LookRotation(vo);
        
    }

    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i / (float) lineSegment);
            lineVisual.SetPosition(i, pos);
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;

        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }

    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;

        result.y = sY;

        return result;
    }

    //position-ground=vy* t - 0.5f * gravity * t2   // vz*t


}
