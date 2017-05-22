using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour {

    private bool climbUp;
    private GameObject otherGameObject;
    private Rigidbody2D otherRigidBody;
    [SerializeField]
    private float climbspeed;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (climbUp)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                
                otherRigidBody.velocity = new Vector3(0, climbspeed, 0);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                otherRigidBody.velocity = new Vector3(0, -climbspeed, 0);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        otherGameObject = other.gameObject;
        otherRigidBody = otherGameObject.GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "Player")
            climbUp = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            climbUp = false;
    }
}
