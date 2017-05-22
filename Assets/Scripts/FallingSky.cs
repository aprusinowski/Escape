using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSky : MonoBehaviour
{

    [SerializeField]
    private GameObject brick;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int quantity;
    GameObject[] Bricks;
    GameObject Brick;
    private int counter;
    int playerposX;
    // Use this for initialization
    void Start()
    {
        counter = 0;
        quantity = quantity > 0 ? quantity : 1;
        quantity = 120 / quantity;
    }
    
    void Update()
    {
        if (counter == quantity)
        {
          
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x - 12, 15, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x - 9, 20, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x - 6, 11, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x - 3, 30, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x, 22, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x + 3, 40, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x + 6, 11, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x + 9, 33, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();
            Brick = (GameObject)Instantiate(brick, new Vector3(player.transform.position.x + 12, 50, 0), Quaternion.identity);
            Brick.GetComponent<Rigidbody2D>().gravityScale = 1;
            Brick.AddComponent<KillFallingBrick>();

            counter = 0;
        }

        counter++;
    }
}

