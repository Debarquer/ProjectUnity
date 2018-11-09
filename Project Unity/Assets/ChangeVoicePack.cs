using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVoicePack : MonoBehaviour {

	public void Do(string voicePack)
    {
        FindObjectOfType<GameSettings>().ChangeVoicePack(voicePack);
    }
}
