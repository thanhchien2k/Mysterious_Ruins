using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1_box : MonoBehaviour
{
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private Transform levelCompleteScreen;
    private bool isNextLevelBox ;
    private PlayerController playerControll;
    private PlayerAttack playerAttack;

    private void Start()
    {
        isNextLevelBox = false;
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if(isNextLevelBox && Input.GetKey(KeyCode.UpArrow))
        {
            GameManager.instance.UnlockLevel();
            GameManager.instance.OpenUI(levelCompleteScreen);
            if (playerControll != null || playerAttack!= null) 
            {
                playerControll.enabled = false;
                playerAttack.enabled = false;
            }
           
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
