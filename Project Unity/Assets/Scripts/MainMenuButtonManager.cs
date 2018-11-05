using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour {

    public Button[] buttons;
    public GameObject[] menus;

    public void PressButton(string name)
    {
        switch (name)
        {
            case "play":
                Debug.Log("Pressed play");
                UnityEngine.SceneManagement.SceneManager.LoadScene("SimonSaysScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
                break;
            case "howtoplay":
                CloseAllMenus(menus[0]);
                ResetAllButtonColors();
                if(!menus[0].activeInHierarchy)
                    buttons[1].GetComponent<Image>().color = Color.grey;
                menus[0].SetActive(!menus[0].activeInHierarchy);
                break;
            case "settings":
                CloseAllMenus(menus[1]);
                ResetAllButtonColors();
                if(!menus[1].activeInHierarchy)
                    buttons[2].GetComponent<Image>().color = Color.grey;
                menus[1].SetActive(!menus[1].activeInHierarchy);
                break;
            case "about":
                CloseAllMenus(menus[2]);
                ResetAllButtonColors();
                if(!menus[2].activeInHierarchy)
                    buttons[3].GetComponent<Image>().color = Color.grey;
                menus[2].SetActive(!menus[2].activeInHierarchy);
                break;
            case "quit":
                Application.Quit();
                break;
        }
    }

    void CloseAllMenus(GameObject currentMenu)
    {
        foreach(GameObject menu in menus)
        {
            if(menu != currentMenu)
                menu.SetActive(false);
        }
    }

    void ResetAllButtonColors()
    {
        foreach(Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }
}
