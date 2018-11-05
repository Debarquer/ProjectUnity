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
                ResetAllButtonColors();

                buttons[0].GetComponent<Image>().color = Color.grey;
                menus[0].SetActive(true);
                break;
            case "graphics":
                CloseAllMenus();
                ResetAllButtonColors();

                buttons[1].GetComponent<Image>().color = Color.grey;
                menus[1].SetActive(true);
                break;
            case "audio":
                CloseAllMenus();
                ResetAllButtonColors();

                buttons[2].GetComponent<Image>().color = Color.grey;
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

    void ResetAllButtonColors()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Image>().color = Color.white;
        }
    }
}
