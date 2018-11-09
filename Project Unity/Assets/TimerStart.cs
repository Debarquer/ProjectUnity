using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStart : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (FindObjectOfType<Player>().timerFrozen)
            {
                FindObjectOfType<Player>().timerFrozen = false;

                GetComponent<AudioSource>().Play();
            }   
        }
    }
}
