using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public AudioClip missionAccomplished;
    public AudioClip missionAccomplishedAlt;

    private int nrOfThingsToSave;
    public int NrOfTingsToSave
    {
        get
        {
            return nrOfThingsToSave;
        }
        set
        {
            Debug.Log("changing nr of villagers from a -> b" + nrOfThingsToSave + "->" + value);

            nrOfThingsToSave = value;
            if(nrOfThingsToSaveText != null)
                nrOfThingsToSaveText.text = "Remaining things: " + value;

            FancyTimerAnimations[] timerAnimations = FindObjectsOfType<FancyTimerAnimations>();
            foreach (FancyTimerAnimations fancyTimerAnimation in timerAnimations)
            {
                if (fancyTimerAnimation.gameObject.tag == "Enemy")
                {
                    fancyTimerAnimation.ExpandAndFade(Color.green);
                }
            }

            if(nrOfThingsToSave <= 0)
            {
                FindObjectOfType<Player>().timerFrozen = true;

                FancyTimer ft = FindObjectOfType<FancyTimer>();
                if(ft != null)
                {
                    ft.textMeshPro.color = Color.green;
                    
                }

                GetComponent<AudioSource>().Play();
            }
        }
    }

    public Text nrOfThingsToSaveText;
    public GameObject[] thingsToSave;

    // Use this for initialization
    void Start () {
        thingsToSave = GameObject.FindGameObjectsWithTag("SaveMe");
        NrOfTingsToSave = thingsToSave.Length;

        if (FindObjectOfType<GameSettings>().alternateVoicePack)
        {
            GetComponent<AudioSource>().clip = missionAccomplishedAlt;
        }
        else
        {
            GetComponent<AudioSource>().clip = missionAccomplished;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
