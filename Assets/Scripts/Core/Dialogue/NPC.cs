using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]private DialogueTrigger dialogueTrigger;
    private bool isDialogue;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        isDialogue = false;
    }

     private void Update()
    {
        if (isDialogue && Input.GetKeyDown(KeyCode.R) && !DialogueManager.isMessageActive)
        {
            dialogueTrigger.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            isDialogue = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogueManager.isMessageActive = false;
            isDialogue = false;
        }
    }

    public bool GetIsDiaLogue()
    {
        return isDialogue;
    }

}
