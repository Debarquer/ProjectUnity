﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : MonoBehaviour {

    public AudioClip timerStartClip;
    public AudioClip timerStartClipAlt;

    private void Start()
    {
        if (FindObjectOfType<GameSettings>().alternateVoicePack)
        {
            //EVA
            GetComponent<AudioSource>().clip = timerStartClipAlt;
        }
        else
        {
            //Cabal
            GetComponent<AudioSource>().clip = timerStartClip;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            if (FindObjectOfType<Player>().timerFrozen)
            {
                FindObjectOfType<Player>().timerFrozen = false;

                GetComponent<AudioSource>().Play();
            }   
        }
    }
}
