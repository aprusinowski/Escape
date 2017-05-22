using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroGravity : MonoBehaviour {

    private Player player;
    
    // Use this for initialization
    void Start()
    {
        player = (Player)FindObjectOfType(typeof(Player));
    }


    // Update is called once per frame
    void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -0.02f;
            player.tag = "Finished";
            player.GetComponent<Rigidbody2D>().transform.Rotate(0, 0, Random.rotation.z);
            GetComponent<EdgeCollider2D>().enabled = false;
            
        }
        else if(other.tag == "Finished")
            SceneManager.LoadScene(4);
    }



}
