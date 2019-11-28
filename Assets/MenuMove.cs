using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMove : MonoBehaviour
{
    // Start is called before the first frame update

    Transform Cameratransform;

    public Transform playertransform;
    public Vector3 offSet;

    public 
    void Start()
    {
        Cameratransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Cameratransform.position = new Vector3(playertransform.position.x, Cameratransform.position.y, Cameratransform.position.z);
    }
}
