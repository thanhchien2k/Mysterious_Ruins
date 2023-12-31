using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_telePort : MonoBehaviour
{
    private GameObject currentTeleport;
    private Player_Item playerItems;

    private void Awake()
    {
        playerItems = GetComponent<Player_Item>();
    }
    private void Update()
    {
        if (currentTeleport == null) return;
        if (Input.GetKeyDown(KeyCode.UpArrow) 
            && ( (currentTeleport.GetComponent<Teleporter>().GetTeleportColor() == playerItems.GetColorCurrentCard())|| currentTeleport.GetComponent<Teleporter>().GetTeleportColor()=="Black"))
        {
            transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TelePort"))
        {
            currentTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("TelePort"))
        {
            if(collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }
}
