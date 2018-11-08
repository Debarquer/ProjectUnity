using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveObject : MonoBehaviour {

    ScoreManager scoreManager;
    Player player;
    Canvas canvas;
    Text speechText; 
    public float speechTimerNextMax = 0;
    public float speechTimerNextCurr = 0;
    public float speechTimerEnabledMax = 2;
    public float speechTimerEnabledCurr = 0;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<Player>();

        speechText = GetComponentInChildren<Text>();
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        speechTimerNextCurr += Time.deltaTime;
		if(speechTimerNextCurr > speechTimerNextMax)
        {
            canvas.enabled = true;

            speechTimerEnabledCurr += Time.deltaTime;
            if(speechTimerEnabledCurr > speechTimerEnabledMax)
            {
                speechTimerNextCurr = 0;
                speechTimerEnabledCurr = 0;
                speechTimerNextMax = Random.Range(3, 12);

                canvas.enabled = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(scoreManager != null)
        {
            scoreManager.NrOfTingsToSave -= 1;
        }

        GetComponent<BoxCollider2D>().enabled = false;
        player.ChangeScore(5);
        Destroy(gameObject);
    }
}
