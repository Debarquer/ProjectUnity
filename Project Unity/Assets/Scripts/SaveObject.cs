﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObject : MonoBehaviour {

    ScoreManager scoreManager;
    Player player;

	// Use this for initialization
	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        player.ChangeScore(5);
        scoreManager.NrOfTingsToSave -= 1;
        Destroy(gameObject);
    }
}