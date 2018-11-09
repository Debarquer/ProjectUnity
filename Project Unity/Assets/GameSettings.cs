using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    public bool alternateVoicePack;

    public UnityEngine.UI.Text audioSettingsText;

	// Use this for initialization
	void Start () {
        GameSettings[] gs = FindObjectsOfType<GameSettings>();
        foreach(GameSettings gameSettings in gs)
        {
            if(gameSettings != this)
            {
                DestroyImmediate(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);

                if(audioSettingsText != null)
                {
                    string settingsString = "Current voice pack: " + (alternateVoicePack ? "Eva" : "Cabal");
                    audioSettingsText.text = settingsString;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeVoicePack(string voicePack)
    {
        if(voicePack == "EVA" || voicePack == "Alternate")
        {
            alternateVoicePack = true;
        }
        else
        {
            alternateVoicePack = false;
        }

        string settingsString = "Current voice pack: " + (alternateVoicePack ? "Eva" : "Cabal");
        audioSettingsText.text = settingsString;
    }

    public void SetAudioText(UnityEngine.UI.Text text)
    {
        audioSettingsText = text;
        string settingsString = "Current voice pack: " + (alternateVoicePack ? "Eva" : "Cabal");
        audioSettingsText.text = settingsString;
    }
}
