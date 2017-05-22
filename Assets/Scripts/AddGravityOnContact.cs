using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravityOnContact : MonoBehaviour {


    private Collider2D[] colliders;
    private Rigidbody2D[] childObjectRB2D;
    private Rigidbody2D thisRigidBody2D;
    private Transform releasePoint;
    private HingeJoint2D hingeJoint;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private bool hinged;
    [SerializeField]
    private bool triggeredMotor;
    [SerializeField]
    private bool releaseHinge;

    private Transform playerTransform;
    float distanceToHinge;
    float distanceToPlayer;
    float hingeToPlayer;
    private void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        colliders = gameObject.GetComponents<Collider2D>();
        childObjectRB2D = gameObject.GetComponentsInChildren<Rigidbody2D>();
        thisRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        
        if (hinged)
        {
            hingeJoint = GetComponent<HingeJoint2D>();
            if (releaseHinge)
            {
                distanceToHinge = Vector3.Distance(hingeJoint.connectedAnchor, thisRigidBody2D.position);
                
            }
        }
    }

    private void Update()
    {
        if (hinged)
        {
            if (releaseHinge)
                distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);            

            hingeToPlayer = Vector3.Distance(hingeJoint.connectedAnchor, player.transform.position);
            if (Mathf.Abs(hingeToPlayer - distanceToHinge - distanceToPlayer) < 1)
            {
                hingeJoint.enabled = false;
                Destroy(this, 5);
            }
        }
    }
        
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            addGravityToObject();
        }
    }

    private void addGravityToObject()
    {       
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        foreach (Collider2D thisCollider2D in colliders)
        {
            thisCollider2D.isTrigger = false;            
        }
        if (triggeredMotor)
            hingeJoint.useMotor = true;
        else
        {
            foreach (Rigidbody2D rb2D in childObjectRB2D)
            {
                rb2D.gravityScale = 1;
            }
        }
        
    }
    
}
