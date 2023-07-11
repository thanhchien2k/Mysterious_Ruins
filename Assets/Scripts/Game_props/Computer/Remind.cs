using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Remind : MonoBehaviour
{
    private NPC npc;
    private bool isTweening;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        npc = GetComponentInParent<NPC>();
        isTweening = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    private void Update()
    {
        if(npc.GetIsDiaLogue() && !isTweening && !DialogueManager.isMessageActive)
        {
            isTweening = true;
            spriteRenderer.enabled = true;

        }
        else if (DialogueManager.isMessageActive)
        {
            spriteRenderer.enabled = false;
        } 
        else if (!npc.GetIsDiaLogue())
        {
            isTweening = false;
            spriteRenderer.enabled = false;
        }
    }
}
