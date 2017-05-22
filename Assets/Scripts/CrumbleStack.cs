using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbleStack : MonoBehaviour {
    private Collider2D[] colliders;
    private Rigidbody2D[] childObjectRB2D;
    private Collider2D[] childColliders2D;
    private Rigidbody2D thisRigidBody2D;

    [SerializeField]
    private float forcetoAdd;

    private void Start()
    {
        colliders = gameObject.GetComponents<Collider2D>();
        childColliders2D = gameObject.GetComponentsInChildren<Collider2D>();
        childObjectRB2D = gameObject.GetComponentsInChildren<Rigidbody2D>();
        thisRigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        crumbleStack();
    }

    private void crumbleStack()
    {
        
        foreach (Collider2D thisCollider2D in colliders)
        {
            thisCollider2D.isTrigger = false;
        }

        thisRigidBody2D.gravityScale = 1;
        foreach (Rigidbody2D rb2D in childObjectRB2D)
        {
            rb2D.GetComponent<Collider2D>().isTrigger = false; 
            rb2D.AddForce(new Vector3(((Random.Range(-forcetoAdd, forcetoAdd)) * rb2D.mass * 10f), 0, 0));
            rb2D.transform.Rotate(0, 0, Random.rotation.z);
            rb2D.gravityScale = 1;

        }
    }
}
