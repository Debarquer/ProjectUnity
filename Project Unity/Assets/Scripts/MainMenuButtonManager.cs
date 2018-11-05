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
            case "start":
                break;
            case "howtoplay":
                CloseAllMenus(menus[0]);
                menus[0].SetActive(!menus[0].activeInHierarchy);
                break;
            case "settings":
                CloseAllMenus(menus[1]);
                menus[1].SetActive(!menus[1].activeInHierarchy);
                break;
            case "about":
                CloseAllMenus(menus[2]);
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
}
