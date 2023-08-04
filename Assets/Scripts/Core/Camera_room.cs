using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Camera_room : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;
    private PlayerController playerController;
    [SerializeField] private List<GameObject> objects;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        foreach (GameObject temp in objects)
        {
            temp.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger && playerController.canChangeCamera())
        {
            virtualCam.SetActive(true);



            foreach (GameObject temp in objects)
            {
                temp.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && playerController.canChangeCamera())
        {
            virtualCam.SetActive(false);

            foreach (GameObject temp in objects)
            {
                temp.SetActive(false);
            }
        }
    }
    

}
