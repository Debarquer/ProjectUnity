using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameSettingsText : MonoBehaviour {

    private void Awake()
    {
        FindObjectOfType<GameSettings>().SetAudioText(this.GetComponent<UnityEngine.UI.Text>());
    }
}
