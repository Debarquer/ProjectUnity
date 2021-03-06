﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudProjectile : MonoBehaviour {
    public float speed = 10;
    public Rigidbody2D rb;
    public GameObject SmokePE;

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        //rb.velocity = new Vector2(speed, 0);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            FindObjectOfType<Player>().ChangeTimer(5f);
            Instantiate(SmokePE, other.transform.position, other.transform.rotation);
            FancyTimerAnimations[] timerAnimations = FindObjectsOfType<FancyTimerAnimations>();
            foreach(FancyTimerAnimations fancyTimerAnimation in timerAnimations)
            {
                 if(fancyTimerAnimation.gameObject.tag == "Player")
                {
                    fancyTimerAnimation.ExpandAndFade(Color.green);
                }
            }
        }
        else if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
