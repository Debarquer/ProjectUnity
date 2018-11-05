using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;

    float jumpMaxTime;
    float jumpTime;
    public bool isJumping;
    public float jumpPower;

    public float extraJumpTime = 0.55f;
    public float extraJumpAscendTime = 0.4f;
    public float extraJumpPower = 0.55f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal") * 5;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            jumpMaxTime = Time.time + extraJumpTime;
            jumpTime = 0;
            jumpPower = extraJumpPower;
        }

        if (Input.GetButton("Jump") && Time.time < jumpMaxTime)
        {
            jumpTime += Time.deltaTime;

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            if (jumpTime < extraJumpAscendTime)
            {
                if (jumpPower < 6)
                {
                    jumpPower *= 1.3f;
                }
            }
            else
            {
                jumpPower *= 0.8f;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpMaxTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }
}
