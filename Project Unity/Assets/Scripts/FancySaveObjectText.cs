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
                    if (name == "Save")
                    {
                        textMeshPro.text = "Save ";
                    }
                    if (name == "Number")
                    {
                        textMeshPro.text = scoreManager.NrOfTingsToSave.ToString();
                    }
                    if (name == "Other")
                    {
                        textMeshPro.text = " more villagers to advance";
                    }
                    
                }
                else
                {
                    textMeshPro.color = Color.green;
                    if (name == "Save")
                    {
                        textMeshPro.text = "Save ";
                        textMeshPro.text = "Mission";
                    }
                    if(name == "Number")
                    {
                        textMeshPro.text = "";
                        Destroy(gameObject);
                    }
                    if (name == "Other")
                    {
                        textMeshPro.text = "Save ";
                        textMeshPro.text = "accomplished";
                    }
                }
            }
        }
	}
}
