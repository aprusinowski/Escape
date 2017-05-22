using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjectTrigger : MonoBehaviour {
    [SerializeField]
    private int value;
    private bool collected;
    private AudioSource Sound;
    private Player player;
    
    private void Start()
    {
        collected = false;
        Sound = gameObject.GetComponent<AudioSource>();
        player = (Player)FindObjectOfType(typeof(Player));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !collected)
        {
            collected = true;
            player.ObjectCollected(value);
            {
                Sound.Play();
                GetComponent<Rigidbody2D>().gravityScale = -1f;
                Destroy(gameObject,3);
            }
            
        }
            


    }


}
