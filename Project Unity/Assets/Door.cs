using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool playerAtDoor = false;

    public Transform otherDoor;

    private void Update()
    {
        if (playerAtDoor)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                FindObjectOfType<Player>().transform.position = otherDoor.transform.position;
            }
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerAtDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerAtDoor = false;
    }
}
