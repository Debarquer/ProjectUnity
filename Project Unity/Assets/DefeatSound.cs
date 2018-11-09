using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatSound : MonoBehaviour {

    public AudioClip defeatClip;
    public AudioClip defeatClipAlt;

	// Use this for initialization
	void Start () {
        if (FindObjectOfType<GameSettings>().alternateVoicePack)
        {
            //EVA
            GetComponent<AudioSource>().clip = defeatClipAlt;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            //Cabal
            GetComponent<AudioSource>().clip = defeatClip;
            GetComponent<AudioSource>().Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
