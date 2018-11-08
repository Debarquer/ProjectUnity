using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {

    //public Scene[] scenes;

    public GameObject buttonPrefab;
    public Transform buttonContainer;

    public GameObject loadingScreen;

	// Use this for initialization
	void Start () {
		//foreach(Scene scene in scenes)
  //      {
  //          GameObject go = Instantiate(buttonPrefab, buttonContainer);
  //          go.GetComponentInChildren<Text>().text = go.name = scene.name;
  //      }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string name)
    {
        //loadingScreen.SetActive(true);
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
