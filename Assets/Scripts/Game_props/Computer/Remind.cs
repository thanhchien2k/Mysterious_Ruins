using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remind : MonoBehaviour
{
    private NPC npc;
    private Teleporter teleporter;
    private bool isTweening;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isNpc;
    [SerializeField] private bool isTeleport;
    [SerializeField] private bool isProps;

    private void Start()
    {
        npc = GetComponentInParent<NPC>();
        teleporter = GetComponentInParent<Teleporter>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    private void Update()
    {
        if (isNpc)
        {
            if (npc.GetIsDiaLogue() && !DialogueManager.isMessageActive)
            {
                spriteRenderer.enabled = true;

            }
            else if (DialogueManager.isMessageActive)
            {
                spriteRenderer.enabled = false;
            }
            else if (!npc.GetIsDiaLogue())
            {
                spriteRenderer.enabled = false;
            }
        } else if (isTeleport)
        {
            if (teleporter.GetIsTouch())
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                spriteRenderer.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isProps)
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isProps)
        {
            spriteRenderer.enabled = false;

        }
    }
}
