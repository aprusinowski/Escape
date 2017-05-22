using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    [SerializeField]
    private float horizontalMovementSpeed;

    [SerializeField]
    private float jumpSpeed;

    private bool attack;
    private bool run;
    private bool facingRight;
    private bool isGrounded;
    private bool jump;
    private bool jumpAnimIP;
    private int stage;
    private int pointsCount;
    private bool enoughPointstoContinue;    

    int[] pointsForStage = { 50, 74, 106, 129, 137, 151 };
    int[] totalPossibleAtStage = { 66, 90, 120, 150, 158, 172};
    int[] totalLeftAtStage = { 66, 90, 120, 150, 158, 172 };
    private AudioSource Sound;



    float horizontal; 


    [SerializeField]
    private bool PlayerInAirControl;
    [SerializeField]
    private Transform[] groundPt;
    [SerializeField]
    private float grdRad;

    [SerializeField]
    private Text pointsCountText;
    public Text currentStageText;

    private int pointsCollected;

    [SerializeField]
    private LayerMask grdMask;
	// Use this for initialization
	void Start () {

        stage = 0;
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        pointsCollected = 0;
        pointsCount = 0;
        enoughPointstoContinue = true;
        Sound = gameObject.GetComponent<AudioSource>();

    }

    void Update ()
    {
        HandleInput();
        pointsCountText.text = pointsCount.ToString();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        horizontal = Input.GetAxis("Horizontal");
        isGrounded = isPlayerGrounded();          
        Flip(horizontal);
        HandleMovement(horizontal);
        HandleAttack();
            
        ResetValues();
        if (myRigidbody.velocity.magnitude > 28)
            receiveDamage( 1000);

    }

    private void HandleMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            myAnimator.SetTrigger("playerjump");
            jumpAnimIP = true;
            myAnimator.SetLayerWeight(1, 1);

        }

        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerAttack") && (isGrounded || PlayerInAirControl))
        {
            if (run)
            {
                myAnimator.SetBool("run", true);
                myRigidbody.velocity = new Vector3((float)(1.5) * horizontal * horizontalMovementSpeed, myRigidbody.velocity.y, 0);

            }
            else
            {
                myAnimator.SetBool("run", false);
                myRigidbody.velocity = new Vector3(horizontal * horizontalMovementSpeed, myRigidbody.velocity.y, 0);
            }

        }
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void HandleAttack()
    {
        if(attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerAttack"))
        {
            myAnimator.SetTrigger("attack");
           
            myRigidbody.AddForce(-myRigidbody.velocity);
        }
    }
    

    private void HandleInput()
    {   
               
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            run = true;
        }
        if(Input.GetKeyDown(KeyCode.Space ))
        {            
            if(isGrounded)
            {
                jump = true;
                Sound.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 playerScale = transform.localScale;
            playerScale.x *= -1;
            transform.localScale = playerScale;
            
        }

    }

    private void ResetValues()
    {        
        run = false;
        jump = false;        
        
    }

    private bool isPlayerGrounded()
    {

        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPt)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, grdRad, grdMask);

                foreach(Collider2D collider in colliders)
                {
                    if(collider.gameObject !=gameObject)
                    {                       
                        return true;
                    }                     
                }
            }
        }
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    public void ObjectCollected(int value)
    {
        totalLeftAtStage[stage] = totalPossibleAtStage[stage] - pointsCollected;

        
        pointsCollected += value;
        pointsCount = pointsCount + value;
        if (pointsCount >= pointsForStage[stage])
            stage++;
        Debug.Log("Points Collected " + pointsCollected);
        Debug.Log("Points Count " + pointsCollected);
        Debug.Log("Stage " + stage);
        Debug.Log("============================================= ");

    }
    public int getPoints()
    {
        return pointsCount;
    }

    public void receiveDamage(int damageValue)
    {
        
        pointsCount =  pointsCount - damageValue;
        Debug.Log("PointCount " + pointsCount);
        Debug.Log("Damage Received " + damageValue);

        if ((totalPossibleAtStage[stage] + pointsCount )< pointsForStage[stage])
        {
            enoughPointstoContinue = false;
            SceneManager.LoadScene(3);
            Debug.Log("Player Dead");
        }
    }

    public void setSortingLayer(string levelName,int order)
    {        
        GetComponent<SpriteRenderer>().sortingLayerName = levelName;
        GetComponent<SpriteRenderer>().sortingOrder = order;
    }
    public void resetSortingLayer()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        GetComponent<SpriteRenderer>().sortingOrder = 0;
    }

}
