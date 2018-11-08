using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelCollider : MonoBehaviour {

    public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.gameObject.GetComponent<Player>() != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
