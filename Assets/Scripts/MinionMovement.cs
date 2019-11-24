using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovement :  MovementBehaviour
{
    [SerializeField]
    public Transform characterTransform;
    [Range(1,30)]
    public float speed=15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Move(Rigidbody rigidbody) {
        Debug.Log("Minion is moving");
        rigidbody.AddForce(new Vector3(characterTransform.position.x, characterTransform.position.y,- characterTransform.position.z * speed * Time.deltaTime));
    }
}
