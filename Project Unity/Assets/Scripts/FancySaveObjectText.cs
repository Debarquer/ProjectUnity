using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancySaveObjectText : MonoBehaviour {

    ScoreManager scoreManager;
    TMPro.TextMeshProUGUI textMeshPro;

    // Use this for initialization
    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        textMeshPro = GetComponent<TMPro.TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        if(scoreManager != null)
        {
            if(textMeshPro != null)
            {
                if(scoreManager.NrOfTingsToSave > 0)
                {
                    textMeshPro.text = "Save "+scoreManager.NrOfTingsToSave+" more villagers to advance";
                }
                else
                {
                    textMeshPro.color = Color.green;
                    textMeshPro.text = "Mission accomplished";
                }
            }
        }
	}
}
