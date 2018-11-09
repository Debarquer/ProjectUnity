using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    public bool alternateVoicePack;

    public UnityEngine.UI.Text audioSettingsText;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);

        string settingsString = "Current voice pack: " + (alternateVoicePack ? "Eva" : "Cabal")
        audioSettingsText.text = settingsString;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
