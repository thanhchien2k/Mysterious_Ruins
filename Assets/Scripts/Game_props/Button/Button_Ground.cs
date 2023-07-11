using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Ground : MonoBehaviour
{
    private bool hover = false;
    [SerializeField] private Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hover) return;
        if (collision.CompareTag("Player"))
        {
            hover = true;
            SpriteRenderer spR = GetComponent<SpriteRenderer>();
            if (spR != null && newSprite != null)
            {
                spR.sprite = newSprite;
            }
        }
    }

    public bool  GetIsHover()
    {
        return hover;
    }
}
