using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour {

    public Sprite levelSprite;
    public GameObject graphicsBox;

    public void OnMouseEnter()
    {
        graphicsBox.SetActive(true);
        graphicsBox.GetComponent<Image>().sprite = levelSprite;
    }

    public void OnMouseExit()
    {
        graphicsBox.GetComponent<Image>().sprite = null;
        graphicsBox.SetActive(false);
    }
}
