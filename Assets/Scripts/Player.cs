using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    public float runSpeed;

    private Rigidbody2D rb;
    private Animator anim; 

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	
	void Update () {
        Run();
        FlipSprite();
	}

    void Run()
    {
        float inputValue = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(inputValue * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
        bool isPlayerRunning = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("isRunning", isPlayerRunning);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);    //character is flipped as per sign of velocity
        }
    }


}
