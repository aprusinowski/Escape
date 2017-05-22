using UnityEngine;
using System.Collections;

[SharedBetweenAnimators]
public class PlayerJumpinInAir : StateMachineBehaviour
{
    private GameObject player;
    private Rigidbody2D myRigidbody;
    private Animator animator;
    private AnimatorStateInfo stateInfo;
    private static int jumpReqCount;


    /**********************************************************************************
    *                                                                                 *
    *                      OnStateEnter                                               *
    *                                                                                 *  
    ***********************************************************************************/
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        this.stateInfo = stateInfo;
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody = player.GetComponent<Rigidbody2D>();

        if (stateInfo.IsName("PlayerJumpStart"))
        {
            jumpReqCount = 1;
        }
        else if (stateInfo.IsName("PlayerJump"))
        {            
            myRigidbody.AddForce(new Vector3(0, 300 / jumpReqCount, 0));
        }
    }

    /**********************************************************************************
    *                                                                                 *
    *                      OnStateUpdate                                              *
    *                                                                                 *  
    ***********************************************************************************/
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("PlayerJump"))
        {
            if (animator.GetBool("doubleJump") == true)
            {
                animator.SetTrigger("doubleJump");
            }
            else if (myRigidbody.velocity.y <= 0)
            {
                animator.SetBool("playerLand", true);
                animator.ResetTrigger("doubleJump");
            }
        }
        HandleInput();
    }

    /**********************************************************************************
    *                                                                                 *
    *                      OnStateExit                                                *
    *                                                                                 *  
    ***********************************************************************************/
    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        if (stateInfo.IsName("PlayerJumpEnd"))
        {
            jumpReqCount = 1;
            animator.SetLayerWeight(1, 0);                    
            animator.SetBool("doubleJump", false);
            animator.SetBool("playerLand", false);
            
        }
    }


    /**********************************************************************************
    *                                                                                 *
    *                      GetKeyDown                                                 *
    *                                                                                 *  
    ***********************************************************************************/
    private void HandleInput()
    {       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("doubleJump",true);
            jumpReqCount++;
        }
    }
}





