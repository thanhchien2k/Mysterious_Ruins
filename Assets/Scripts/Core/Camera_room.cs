using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_room : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger && playerController.canChangeCamera())
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && playerController.canChangeCamera())
        {
            virtualCam.SetActive(false);
        }
    }
    

}
