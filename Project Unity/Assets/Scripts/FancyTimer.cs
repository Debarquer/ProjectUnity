using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FancyTimer : MonoBehaviour {

    Player player;
    TMPro.TextMeshProUGUI textMeshPro;

	// Use this for initialization
	void Start () {
        textMeshPro = GetComponent<TMPro.TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
		if(player == null)
        {
            player = FindObjectOfType<Player>();
        }
        else
        {
            string minutes = ((int)player.timer / 60).ToString("n0");
            string seconds = (player.timer % 60).ToString("n0");
            string ms = ((player.timer % 1)*100).ToString("n0");

            if(player.timer / 60 < 10)
            {
                minutes = "0" + minutes;
            }
            if (player.timer % 60 < 10)
            {
                seconds = "0" + seconds;
            }
            if((player.timer % 1) * 100 < 10)
            {
                ms = "0" + ms;
            }
            textMeshPro.text = string.Format("{0}:{1}:{2}", minutes, seconds, ms);
        }
	}
}
