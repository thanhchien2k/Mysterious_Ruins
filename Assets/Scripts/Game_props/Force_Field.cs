using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_Field : MonoBehaviour
{
    private Player_Item playerItem;
    [SerializeField] private GameObject computer;
    private void Start()
    {
        playerItem = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Item>();
    }
    void Update()
    {
        if (playerItem.GetPower() == playerItem.GetMaxPower() && DialogueManager.isMessageActive
            && computer.gameObject.GetComponent<NPC>().GetIsDiaLogue())
        {
            gameObject.SetActive(false);
        }
    }
}
