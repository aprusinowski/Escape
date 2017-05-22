using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretDoorTrigger : MonoBehaviour {
    private Player playerObject;

    [SerializeField]
    private int pointsRequired;

    [SerializeField]
    private bool enableGravity;

    [SerializeField]
    private bool enableMotor;
    private AudioSource Sound;

    // Use this for initialization
    void Start () {
        playerObject = (Player)FindObjectOfType(typeof(Player));
        Sound = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(playerObject.getPoints() >= pointsRequired)
        {            
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            Sound.Play();
            if (enableGravity)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                gameObject.GetComponent<Rigidbody2D>().mass = 5000;
            } 
            if (enableMotor)
            {
                gameObject.GetComponent<HingeJoint2D>().useMotor = true;
            }
        }
	}

}
