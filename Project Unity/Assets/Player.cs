using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;

    float jumpMaxTime;
    float jumpTime;
    public bool isJumping;
    public float jumpPower;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal") * 6;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            isJumping = true;
            jumpMaxTime = Time.time + 0.65f;
            jumpTime = 0;
            jumpPower = 3.0f;
        }

        if (Input.GetButton("Jump") && Time.time < jumpMaxTime)
        {
            jumpTime += Time.deltaTime;

            rb.velocity = new Vector2(rb.velocity.x, jumpPower);

            if (jumpTime < 0.45f)
            {
                if (jumpPower < 8)
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
