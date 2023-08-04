using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Option : MonoBehaviour
{
    private DialogueTrigger dialogue;
    private Player_Item playerItem;
    public OptionDialogue option1;
    public OptionDialogue option2;
    private void Start()
    {
        playerItem = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Item>();
        dialogue = GetComponent<DialogueTrigger>();
        dialogue.messages = option1.message;
        dialogue.actors = option1.actor;
    }
    private void Update()
    {   
        if (playerItem.GetPower() < playerItem.GetMaxPower()) return;

            dialogue.messages = option2.message;
            dialogue.actors = option2.actor;
        
    }
}

[System.Serializable]
public class OptionDialogue
{
    public Message[] message;
    public Actor[] actor;
}
