using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Transform transform;
    public GameObject explosionEffect;

    float power = 30f;
    float radius = 20.0f;
    float upForce = 5.0f;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }


    private void Update()
    {
        Invoke("Detonate", 2);
        //Destroy(this.gameObject, 2.51f);

    }

    void Detonate()
    {
        Debug.Log("Detonate: Enter");
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        Instantiate(explosionEffect, new Vector3(this.transform.position.x,this.transform.position.y + 1 ,this.transform.position.z), explosionEffect.transform.rotation);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy is bombed");
                hit.attachedRigidbody.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
            }
        }
        Destroy(this.gameObject);
    }


    public void Disappear()
    {

    }
}
