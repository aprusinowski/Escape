using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFallingBrick : MonoBehaviour {

    GameObject parent;	
	void Start () {        
        Destroy(gameObject, 4);
	}
	
	
}
