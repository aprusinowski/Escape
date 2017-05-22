using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private float maxX;
        [SerializeField]
        private float maxY;
        [SerializeField]
        private float minX;
        [SerializeField]
        private float minY;
        
        private Transform target; 
        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void LateUpdate()
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX),
                                             Mathf.Clamp(target.position.y, minY, maxY),
                                             transform.position.z);

        }        

    }
}
