using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatIcon : MonoBehaviour
{
    private NPC npc;
    private bool isTweening;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        npc = GetComponentInParent<NPC>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (npc.GetIsDiaLogue())
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }
}
