using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour {

    private Player player;
    private Vector3 velocity;
    private Rigidbody2D thisRb;

    [SerializeField]
    private int damageValue;
    // Use this for initialization
    void Start () {
        damageValue = damageValue > 0 ? damageValue : 0;
        player = (Player)FindObjectOfType(typeof(Player));
        thisRb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        velocity = thisRb.velocity;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player" && damageValue > 0 && velocity.magnitude>6)
        {
            
            Debug.Log("velocity "+velocity);
            Debug.Log("velocity magnitude " + velocity.magnitude);
            player.receiveDamage(damageValue);
        }
    }
}
