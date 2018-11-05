using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuButtonManager : MonoBehaviour {

    public Button[] buttons;
    public GameObject[] menus;

    public void PressButton(string name)
    {
        switch (name)
        {
            case "gameplay":
                CloseAllMenus();
                menus[0].SetActive(true);
                break;
            case "graphics":
                CloseAllMenus();
                menus[1].SetActive(true);
                break;
            case "audio":
                CloseAllMenus();
                menus[2].SetActive(true);
                break;
        }
    }

    void CloseAllMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }
}
