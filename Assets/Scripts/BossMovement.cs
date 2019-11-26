using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement :  MovementBehaviour
{
    [SerializeField]
    public Transform characterTransform;
    [Range(10, 140)]
    public float speed = 125f;

    float time = 0.0f;
    float interpolationPeriod = 0.7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MoveKingRelativeToX(Rigidbody rigidbody) {

        int direction;

        direction = Random.Range(-1, 2);

        Debug.Log("direction = " + direction);

        if (characterTransform.position.x <= -8.25 || characterTransform.position.x >= 5.75)
        {
            transform.position = new Vector3(-1.25f, characterTransform.position.y, characterTransform.position.z);
        }
        else {
            if (direction > 0) direction = 1;
            transform.position = new Vector3(direction * 7f + characterTransform.position.x, characterTransform.position.y, characterTransform.position.z);
        }
    }



public override void Move(Rigidbody rigidbody)
{
        float movement = speed * Time.deltaTime;

        characterTransform.Translate(-Vector3.forward * movement);

        time += Time.deltaTime;

        if (time >= interpolationPeriod) {
            time = time - interpolationPeriod;
            MoveKingRelativeToX(rigidbody);
        }
       
        
    }


}
