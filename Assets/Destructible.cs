using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField]
    public float count;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
