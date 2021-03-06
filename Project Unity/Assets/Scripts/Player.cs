﻿using System;
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
    public bool timerFrozen = false;
    public int score;

    Rigidbody2D rb;
    Transform myTrans;

    public AudioSource jumpSound;
    public AudioSource hitSound;

    public CameraShake cameraShake;

    float jumpMaxTime;
    float jumpTime;
    public bool isJumping;
    public float jumpPower;

    public float extraJumpTime = 0.55f;
    public float extraJumpAscendTime = 0.4f;
    public float extraJumpPower = 0.55f;

    public float androidX = 0;

    public GameObject SmokePE;

    public AudioClip yourDefeatIsAtHandClip;
    public AudioClip yourDefeatIsAtHandClipAlt;
    public AudioSource yourDefeatIsAtHand;
    bool hasThretenedDefeat = false;

    // Use this for initialization

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;

        if (FindObjectOfType<GameSettings>().alternateVoicePack)
        {
            //EVA
            yourDefeatIsAtHand.clip = yourDefeatIsAtHandClipAlt;
        }
        else
        {
            //Cabal
            yourDefeatIsAtHand.clip = yourDefeatIsAtHandClip;
        }
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

        if (!timerFrozen)
        {
            timer -= Time.deltaTime;
            if(timer > 15)
            {
                hasThretenedDefeat = false;
            }
            if(timer < 10)
            {
                if (!hasThretenedDefeat)
                {
                    hasThretenedDefeat = true;
                    yourDefeatIsAtHand.Play();
                }
            }
            if(timer < 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("DefeatScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
                //Invoke("UnityEngine.SceneManagement.SceneManager.LoadScene(DefeatScene, UnityEngine.SceneManagement.LoadSceneMode.Single)", 2f);
            }
        }
        if (timerText != null)
        {
            timerText.text = "Time left: " + (int)timer;
        }
    

         
        float x = CrossPlatformInputManager.GetAxisRaw("Horizontal") * 5;

        rb.velocity = new Vector2(x, rb.velocity.y);

        if (rb.velocity.y < 0 )
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFalling", true);
        }
        else
        {
            _animator.SetBool("IsFalling", false);

        }
        if (x > 0 ) // 
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if (x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            _animator.SetBool("IsRunning", true);
        }
        else if (x == 0)
        {
            _animator.SetBool("IsRunning", false);
           
        }



        if (CrossPlatformInputManager.GetButtonDown("Jump") && isJumping == false)
        {
            jumpSound.Play();
            _animator.SetBool("IsJumping", true);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            isJumping = false;
            _animator.SetBool("IsJumping", false);
        }
    }

    public void ChangeScore(int d)
    {
        score += d;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("Player does not have a reference to score");
        }
    }

    public void ChangeTimer(float d)
    {
        timer += d;
        if (timerText != null)
        {
            timerText.text = "Time left: " + (int)timer;
        }
        else
        {
            Debug.Log("Player does not have a reference to timer");
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {           
            hitSound.Play();
            Destroy(collision.gameObject);
            FindObjectOfType<Player>().ChangeTimer(-5f);
            Instantiate(SmokePE, collision.transform.position, collision.transform.rotation);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }   

}
