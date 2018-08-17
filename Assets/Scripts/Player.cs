using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField]float runSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float climbSpeed;
    [SerializeField] Vector2 deathVelocity;

    private Rigidbody2D rb;
    private Animator anim;
    private int groundLayer,ladderMask;
    private float initialGravity;
    private bool isAlive = true;
    public bool hasDrowned=false;
    private BoxCollider2D feetCollider;
    private CapsuleCollider2D bodyCollider;
  


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");     //Got the layer mask for the foreground which is set with layer "Ground"
        ladderMask = LayerMask.GetMask("Ladder");
        initialGravity = rb.gravityScale;
        feetCollider = GetComponent<BoxCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
    }
	
	
	void Update () {
        if (!isAlive)
        {
            return;
        }
        Run();
        Jump();
        FlipSprite();
        ClimbLadder();
        CheckIfDead();
	}

    void Run()
    {
        float inputValue = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(inputValue * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool isPlayerRunning = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("isRunning", isPlayerRunning);
    }

    void Jump()
    {
        bool isTouchingGround = feetCollider.IsTouchingLayers(groundLayer);  //Checking wether player's collider
                                                                            //is touching the foreground
          if (isTouchingGround)
        {
            Vector2 velocityToAdd = new Vector2(0f, jumpSpeed);
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
                rb.velocity += velocityToAdd;
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);    //character is flipped as per sign of velocity
        }
    }

    void ClimbLadder()
    {
        bool touchingLadder = feetCollider.IsTouchingLayers(ladderMask);
        if (!touchingLadder)
        {
            anim.SetBool("isClimbing", false);
            rb.gravityScale = initialGravity;
            return;
        }
        float inputValue = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(rb.velocity.x, climbSpeed*inputValue);
        rb.gravityScale = 0f;
        rb.velocity = climbVelocity;
        anim.SetBool("isClimbing", true);
       
    }

    void CheckIfDead()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            isAlive = false;
            rb.velocity = deathVelocity;
            anim.SetTrigger("DeathTrigger");
            FindObjectOfType<GameSession>().ProcessPlayerDeath(hasDrowned);
        }
        if(bodyCollider.IsTouchingLayers(LayerMask.GetMask("WaterTable")))
        {
           isAlive=false;
           hasDrowned=true;
           rb.velocity=deathVelocity;
           anim.SetTrigger("DeathTrigger");
           FindObjectOfType<GameSession>().ProcessPlayerDeath(hasDrowned);
        }
    }
}
