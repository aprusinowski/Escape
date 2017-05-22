using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Bridge : MonoBehaviour {
    private Player player;
    // Use this for initialization
    void Start () {
        player = (Player)FindObjectOfType(typeof(Player));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.setSortingLayer("Background",1);
        }

    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.resetSortingLayer();
        }

    }
}
