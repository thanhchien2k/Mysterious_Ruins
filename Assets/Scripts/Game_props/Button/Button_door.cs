using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_door : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;
    [SerializeField] private GameObject linkObject;
 
    private bool hover;

    private void Awake()
    {
        hover = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hover) return;
        if (collision.CompareTag("Player"))
        {
                linkObject.SetActive(false);
                SpriteRenderer spR = GetComponent<SpriteRenderer>();
                if (spR != null && newSprite != null)
                {
                    spR.sprite = newSprite;
                }

        }

    }

}
