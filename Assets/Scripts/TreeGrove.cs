using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrove : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private BoxCollider2D bridgeBoxCollider;
    private Player player;
    float startingYpos;
    float startTargetYpos;
	// Use this for initialization
	void Start () {
        startingYpos = transform.position.y;
        startTargetYpos = target.transform.position.y;
       

    }
	
	// Update is called once per frame
	void Update () {
		if(startTargetYpos - transform.position.y == 0)
        {
            bridgeBoxCollider.enabled = true;
        }
	}   
}
