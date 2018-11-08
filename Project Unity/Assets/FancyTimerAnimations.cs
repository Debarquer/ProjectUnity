using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyTimerAnimations : MonoBehaviour {

    public bool animate = false;
    TMPro.TextMeshProUGUI textMesh;

    // Use this for initialization
    void Start () {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();

        ExpandAndFade();
    }
	
	// Update is called once per frame
	void Update () {
		if(animate)
        {
            // Fade
            textMesh.fontSize-=0.2f;
            if(textMesh.fontSize <= 64)
            {
                animate = false;
                textMesh.fontSize = 64;
                textMesh.color = Color.red;
            }
        }
        else
        {
            
        }
	}

    public void ExpandAndFade()
    {
        Debug.Log("Animating");

        animate = true;
        textMesh.fontSize = 86;
        textMesh.color = Color.green;
    }
}
