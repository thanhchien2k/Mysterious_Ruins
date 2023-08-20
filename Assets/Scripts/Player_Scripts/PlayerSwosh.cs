using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwosh : MonoBehaviour
{
    private PlayerController playerController;
    private Animator ani;
    private SpriteRenderer render;
    [SerializeField] private AudioClip LandDust;
    bool Istrue = true;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        ani = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") && !playerController.IsLandDust() )
        {   if (Istrue) Istrue = false;
            else
            {
                render.enabled = true;
                ani.SetTrigger("land");
                SoundManager.instance.PlaySound(LandDust);
            }

        }
    }

    private void StopLandDust()
    {
        render.enabled = false;
    }
}
