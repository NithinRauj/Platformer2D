using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    public float runSpeed;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
        float inputValue;
        if ((inputValue=CrossPlatformInputManager.GetAxis("Horizontal")) != 0f)  //Axis value ranges from -1f to 1f and 0 when 
        {                                                                                                                  //stationary 
            Run(inputValue);
            FlipSprite();
        }
	}

    void Run(float inputValue)
    {
        Vector2 playerVelocity = new Vector2(inputValue * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
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
