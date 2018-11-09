using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyTimerAnimations : MonoBehaviour {

    public bool animate = false;
    public TMPro.TextMeshProUGUI textMesh;

    public int maxSize;
    public float normalSize;
    public float increments = 0.2f;

    // Use this for initialization
    void Start () {
        ExpandAndFade(Color.blue);
    }
	
	// Update is called once per frame
	void Update () {
        if(textMesh == null)
        {
            Debug.Log(gameObject.name + ": no textmesh");
            textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        }

		if(animate)
        {
            // Fade
            textMesh.fontSize-= increments;
            if(textMesh.fontSize <= normalSize)
            {
                animate = false;
                textMesh.fontSize = normalSize;
                textMesh.color = Color.red;
            }
        }
        else
        {
            
        }
	}

    public void ExpandAndFade(Color color)
    {
        if (textMesh == null)
        {
            Debug.Log(gameObject.name + ": no textmesh");
            textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        }

        animate = true;
        textMesh.fontSize = maxSize;
        textMesh.color = color;
    }
}
