using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level1_box : MonoBehaviour
{
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private float delayTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.UnlockLevel();
            StartCoroutine(DelayNextLevel());
        }
    }

    private IEnumerator DelayNextLevel()
    {
        SoundManager.instance.PlaySound(victorySound);
        yield return new WaitForSeconds(delayTime);
        GameManager.instance.NextLevel();
    }
    

}
