using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

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
                FindObjectOfType<FancyTimer>().textMeshPro.color = Color.green;
            }
        }
    }

    public Text nrOfThingsToSaveText;
    public GameObject[] thingsToSave;

    // Use this for initialization
    void Start () {
        thingsToSave = GameObject.FindGameObjectsWithTag("SaveMe");
        NrOfTingsToSave = thingsToSave.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
