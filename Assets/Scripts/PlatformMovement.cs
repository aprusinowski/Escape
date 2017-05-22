using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
          
    Vector3 posA;
    Vector3 posB;
    Vector3 targetPos;

    [SerializeField]
    private float speed;    
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distanceTollerance;
    [SerializeField]
    private int PointsRequired;
    [SerializeField]
    private bool PointActivated;


    /************** Platform types**********************/
    [SerializeField]
    public bool constantlyMoving;
    [SerializeField]
    public bool constantlyMovingTriggered;
    [SerializeField]
    public bool TriggeredOneWay;
    [SerializeField]
    public bool triggeredReturn;
    [SerializeField]
    public bool immediateReturn;
    /***********************************************/

    private bool playerOnPlatform;
    private bool platformActivated;
    private float distToTarget;
    private Transform playerParent;
    private Player playerObject;
    
    
    private void Awake()
    {     
        posA = gameObject.transform.position;
        posB = target.position;
        targetPos = posB;
        playerOnPlatform = false;
        platformActivated = false;        
        playerObject = (Player)FindObjectOfType(typeof(Player));
        playerParent = playerObject.transform.parent;

    }

    private void Update()
    {
        if(platformMovement())
            MovePlatform();
        else
            this.enabled = false;
    }

  /*********************************************************************************
  *                                                                                *
  *                 Trigger handlers                                               *
  *                                                                                *
  ********************************************************************************/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!PointActivated ||(PointActivated && PointsRequired <= playerObject.getPoints()))
        {
            this.enabled = true;
            playerOnPlatform = true;
            platformActivated = true;
            if (!constantlyMoving && !constantlyMovingTriggered)
                targetPos = posB;
            other.transform.SetParent(gameObject.transform); 
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!PointActivated || (PointActivated && PointsRequired <= playerObject.getPoints()))
        {
            playerOnPlatform = false;
            other.transform.SetParent(playerParent);
        }
    }


    /*********************************************************************************
    *                                                                                *
    *                   Platform Movement                                            *
    *                                                                                *
    ********************************************************************************/

    private void MovePlatform()
    {
         gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos, speed * Time.deltaTime);             
    }
   
    //returns true if movement allowed
    private bool platformMovement()
    {
        distToTarget = Vector3.Distance(targetPos, gameObject.transform.position);

        /*******Constantly Moving*********/
        if (constantlyMoving)
        {
            if (distToTarget <= distanceTollerance)
            {
                targetPos = (targetPos == posB) ? posA : posB;
            }
            return true;
        }

        /*******Constantly Moving Triggered*********/
        else if (constantlyMovingTriggered && platformActivated)
        {
            if (distToTarget <= distanceTollerance)
            {
                targetPos = (targetPos != posA) ? posA : posB;
            }
            return true;
        }

        /*******Triggered One Way*********/
        else if (TriggeredOneWay && platformActivated)
        {
            targetPos = posB;
            if (distToTarget > distanceTollerance)
                return true;            
        }

        /*******Triggered Return*********/
        else if (triggeredReturn && platformActivated/*playerOnPlatform*/)
        {
            if (targetPos == posB)
            {
                if (distToTarget <= distanceTollerance)
                    targetPos = posA;
                return true;
            }
            else if (targetPos == posA && (distToTarget > distanceTollerance))
            {
                return true;
            }
        }
        /*******Triggered Immediate Return*********/
        else if (immediateReturn && platformActivated)
        {
            if (!playerOnPlatform)
                targetPos = posA;
            else
                targetPos = posB;

            if (distToTarget > distanceTollerance)
                return true;            
        }
       
        
        return false;
    }


}
