using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;

    [SerializeField]
    public MovementBehaviour movementBehaviour;
    [SerializeField]
    public GameObject deathCharacter;

    bool isAlive;


    public void Play()
    {
        movementBehaviour.Move(GetComponent<Rigidbody>());
    }

    public void Die() {
        isAlive = false;
        gameManager.onEnemyDie();
        Instantiate(deathCharacter,transform.position,transform.rotation);
        Destroy(movementBehaviour.gameObject);
        Destroy(this.gameObject);
    }

    public GameObject getDeathCharacter() {
        return deathCharacter;
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
        Play();
        }
    }
}
