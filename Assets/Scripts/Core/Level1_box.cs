using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1_box : MonoBehaviour
{
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private Transform levelCompleteScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.UnlockLevel();
            GameManager.instance.OpenUI(levelCompleteScreen);
        }
    }
}
