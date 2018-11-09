using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour {

    public AudioClip victoryClip;
    public AudioClip victoryClipAlt;

	// Use this for initialization
	void Start () {
        if (FindObjectOfType<GameSettings>().alternateVoicePack)
        {
            //EVA
            GetComponent<AudioSource>().clip = victoryClipAlt;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            //CABAL
            GetComponent<AudioSource>().clip = victoryClip;
            GetComponent<AudioSource>().Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
