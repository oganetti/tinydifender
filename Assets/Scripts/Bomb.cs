using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Transform transform;
    public GameObject explosionEffect;
    public AudioSource audioS;
    public AudioClip audioC;

    SphereCollider collider;

    float power = 20f;
    float radius = 10.0f;
    float upForce = 5.0f;

    private void Start()
    {
        transform = GetComponent<Transform>();
        collider = GetComponent<SphereCollider>();
    }


    private void Update()
    {
       // Invoke("Detonate", 2);
        //Destroy(this.gameObject, 2.51f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy") {
            Detonate(collision.gameObject);
            Destroy(this.gameObject);
        }
    } 

    public void Detonate(GameObject gameObject)
    {
        Debug.Log("Detonate: Enter");
        Instantiate(explosionEffect, new Vector3(this.transform.position.x,this.transform.position.y + 1 ,this.transform.position.z), explosionEffect.transform.rotation);
        if (gameObject.tag == "Enemy") {
            gameObject.GetComponent<Enemy>().Die();
            //Destroy(this.gameObject);
        }
    }




    public void Disappear()
    {

    }
}
