using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] scales;
    public float smoothing;

    private Vector3 previousCamPos;
	
	void Start () {
        previousCamPos = transform.position;
        scales = new float[backgrounds.Length];
        for(int i=0; i < scales.Length; i++)
        {
            scales[i] = backgrounds[i].position.z * (-1);
        } 
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void LateUpdate()
    {
        for (int i = 0; i < scales.Length; i++)
        {
            Vector3 parallax = (previousCamPos - transform.position) * (scales[i] / smoothing );
            backgrounds[i].position = new Vector3(backgrounds[i].position.x + parallax.x,
                                                   backgrounds[i].position.y + parallax.y,
                                                   backgrounds[i].position.z);
        }

        previousCamPos = transform.position;
    }
}
