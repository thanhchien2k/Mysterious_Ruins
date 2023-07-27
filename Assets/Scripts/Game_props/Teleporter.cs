using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform destination;
    [SerializeField] private TypeColor teleporter;
    private bool isTouch = false;

    public string GetTeleportColor()
    {
        return teleporter.Color;
    }

    public Transform GetDestination()
    {
        return destination;
    }

    public bool GetIsTouch()
    {
        return isTouch;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouch = false;
        }
    }



}
