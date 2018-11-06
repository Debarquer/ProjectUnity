using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Header("References")]
    public Text timerText;
    public Text scoreText;

    public float timer;
    public int score;

    Rigidbody2D rb;

    float jumpMaxTime;
    float jumpTime;
    public bool isJumping;
    public float jumpPower;

    public float extraJumpTime = 0.55f;
    public float extraJumpAscendTime = 0.4f;
    public float extraJumpPower = 0.55f;

    public float androidX = 0;


    // Use this for initialization

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void setAndroidX(float force)
    {
        androidX = force * 5;
    }
	
	// Update is called once per frame
	void Update () {

        if(timerText != null)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time left: " + (int)timer;
        }
        

        if (false)//Application.platform == RuntimePlatform.Android
        {
            float x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxisRaw("Horizontal") * 5;

            rb.velocity = new Vector2(x, rb.velocity.y);

            if (UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonDown("Jump") && isJumping == false)
            {
                isJumping = true;
                jumpMaxTime = Time.time + extraJumpTime;
                jumpTime = 0;
                jumpPower = extraJumpPower;
            }

            if (UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButton("Jump") && Time.time < jumpMaxTime)
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

            if (UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                jumpMaxTime = 0;
            }
        }

      

        else
        {
          
            float x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * 5;

            rb.velocity = new Vector2(x, rb.velocity.y);

            if (x != 0) // 
            {
                transform.localScale = new Vector2(Mathf.Sign(x), 1);
                _animator.SetBool("isRunning", true);
            }
            else if (x == 0)
            {
                _animator.SetBool("isRunning", false);
           
            }



            if (CrossPlatformInputManager.GetButtonDown("Jump") && isJumping == false)
            {
                isJumping = true;
                jumpMaxTime = Time.time + extraJumpTime;
                jumpTime = 0;
                jumpPower = extraJumpPower;
            }

            if (CrossPlatformInputManager.GetButton("Jump") && Time.time < jumpMaxTime)
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

            if (CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                jumpMaxTime = 0;
            }
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }

    public void ChangeScore(int d)
    {
        score += d;
        scoreText.text = "Score: " + score;
    }

    public void ChangeTimer(float d)
    {
        timer += d;
        timerText.text = "Time left: " + (int)timer;
    }
}
