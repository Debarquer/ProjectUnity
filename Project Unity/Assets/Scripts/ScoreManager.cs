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
            nrOfThingsToSave = value;
            nrOfThingsToSaveText.text = "Remaining things: " + nrOfThingsToSave;
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
