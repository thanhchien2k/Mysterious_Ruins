using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_telePort : MonoBehaviour
{
    private GameObject currentTeleport;
    private bool isTeleport;
    private void Update()
    {
        if (currentTeleport == null) return;
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
