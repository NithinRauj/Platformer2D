using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField]
     float runSpeed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    float climbSpeed;

    private Rigidbody2D rb;
    private Animator anim;
    private int layerMask,ladderMask;
    private float initialGravity;



    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        layerMask = LayerMask.GetMask("Ground");     //Got the layer mask for the foreground which is set with layer "Ground"
        ladderMask = LayerMask.GetMask("Ladder");
        initialGravity = rb.gravityScale;
    }
	
	
	void Update () {
        Run();
        Jump();
        FlipSprite();
        ClimbLadder();
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
        bool isTouching = GetComponent<CapsuleCollider2D>().IsTouchingLayers(layerMask);  //Checking wether player's collider
                                                                                                                                              //is touching the foreground
          if (isTouching)
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
        bool touchingLadder = GetComponent<CapsuleCollider2D>().IsTouchingLayers(ladderMask);
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

   

}
