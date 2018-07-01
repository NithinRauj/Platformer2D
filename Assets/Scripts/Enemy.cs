using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D rb;
    private BoxCollider2D flipCollider;
    private CapsuleCollider2D bodyCollider;
	
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        flipCollider = GetComponent<BoxCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
    }
	
	
	void Update () {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
       
	}

    private void OnTriggerExit2D(Collider2D col)
    {
        FlipSprite();
    }
    void FlipSprite()
    {
        bool enemyNotReachedEdge=flipCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (!enemyNotReachedEdge)
        {
            transform.localScale = new Vector2(-Mathf.Sign(rb.velocity.x), 1f);    //character is flipped as per sign of velocity
            moveSpeed = -moveSpeed;
        }
    }
}
