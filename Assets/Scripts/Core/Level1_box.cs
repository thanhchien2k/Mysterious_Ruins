using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1_box : MonoBehaviour
{
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private Transform levelCompleteScreen;
    private bool isNextLevelBox ;
    private PlayerController playerControll;

    private void Start()
    {
        isNextLevelBox = false;
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(isNextLevelBox && Input.GetKey(KeyCode.UpArrow))
        {
            GameManager.instance.UnlockLevel();
            GameManager.instance.OpenUI(levelCompleteScreen);
            if (playerControll != null) playerControll.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNextLevelBox = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isNextLevelBox = false;
        }
    }
}
