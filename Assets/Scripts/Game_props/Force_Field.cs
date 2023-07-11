using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_Field : MonoBehaviour
{
    [SerializeField] private Player_Item playerItem;
    [SerializeField] private GameObject computer;
    void Update()
    {
        if (playerItem.GetPower() == playerItem.GetMaxPower() && DialogueManager.isMessageActive
            && computer.gameObject.GetComponent<NPC>().GetIsDiaLogue())
        {
            gameObject.SetActive(false);
        }
    }
}
