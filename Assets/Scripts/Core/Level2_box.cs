using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level2_box : MonoBehaviour
{
    [SerializeField] private AudioClip victorySound;
    [SerializeField] GameObject  timeLineEnd;
    private PlayableDirector Director;
    private bool isNextLevelBox;
    private PlayerController playerControll;
    private PlayerAttack playerAttack;
    private Player_Item playerItems;

    bool canFinish;
    [SerializeField] private double finishTime;
    private void Start()
    {
        isNextLevelBox = false;
        canFinish = true;
        Director = timeLineEnd.GetComponent<PlayableDirector>();
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        playerItems = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Item>();
    }

    private void Update()
    {
        if (isNextLevelBox && Input.GetKey(KeyCode.UpArrow) && playerItems.GetColorCurrentCard()=="Red")
        {
            GameManager.instance.UnlockLevel();

            if (playerControll != null && playerAttack != null)
            {
                playerControll.enabled = false;
                playerAttack.enabled = false;
            }

            timeLineEnd.SetActive(true);

        }
        if (timeLineEnd.activeSelf)
        {
            double currentTime = Director.time;
            
            if (currentTime >= finishTime && canFinish)
            {
                canFinish = false;
                GameManager.instance.LoadScene(0);
                Debug.Log("ok");
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
