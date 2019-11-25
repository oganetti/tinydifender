using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Transform transform;
    public GameObject explosionEffect;
    public AudioSource audioS;
    public AudioClip audioC;

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
                audioS.PlayOneShot(audioC);
                Debug.Log("Enemy is bombed");
              //  hit.attachedRigidbody.AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);

                hit.gameObject.GetComponent<Enemy>().Die();

                Rigidbody[] rigidbodies = hit.gameObject.GetComponentsInChildren<Rigidbody>();
                for (int i=0; i < rigidbodies.Length; i++)
                {
                    audioS.PlayOneShot(audioC);
                    rigidbodies[i].AddExplosionForce(power, transform.position, radius, upForce, ForceMode.Impulse);
                }
                

            }
        }
        Destroy(this.gameObject);
    }


    public void Disappear()
    {

    }
}
