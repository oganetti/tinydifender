using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Transform transform;
   // public GameObject explosionEffect;

    float power = 10f;
    float radius = 5.0f;
    float upForce = 1.0f;

    public void Hit()
    {
        Invoke("Detonate", 1);

    }

    void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        //Instantiate(explosionEffect, this.transform);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy is bombed");
                hit.attachedRigidbody.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
            }
        }
        Destroy(this);
    }


    public void Disappear()
    {

    }
}
