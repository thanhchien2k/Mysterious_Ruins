using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    private Transform currentRespawnPoint;
    private Transform currentCheckPoint;
    private Player_health playerHealth;
    private bool isDeep;
    private float healthRespawn;
    [SerializeField] AudioClip CheckPointAppear;
   
    // Start is called before the first frame update
    private void Awake()
    {
        playerHealth = GetComponent<Player_health>();
    }

    // Update is called once per frame
    public void Respawn()
    {
       
        if (isDeep && playerHealth.GetCurrentHealth()>=1)
        {
            isDeep = false;
            StartCoroutine(Respawning());
            transform.position = currentRespawnPoint.position;
            transform.localScale = currentRespawnPoint.localScale;
            playerHealth.IsRespawn(); 
        } 
        else if(playerHealth.GetCurrentHealth() <= 0)
        {
            StartCoroutine(Respawning());
            transform.position = currentCheckPoint.position;
            transform.localScale = currentCheckPoint.localScale;
            playerHealth.AddHealth(healthRespawn);
            playerHealth.IsRespawnCheckPoint();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("RespawnPoint"))
        {
            currentRespawnPoint = collision.transform;
        }

        if (collision.CompareTag("Deep"))
        {
            isDeep = true;
        }

        if (collision.transform.CompareTag("CheckPoint"))
        {
            currentCheckPoint = collision.transform;
            healthRespawn = playerHealth.GetCurrentHealth();
            SoundManager.instance.PlaySound(CheckPointAppear);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Appear");
        }
    }

    private IEnumerator Respawning()
    {
        PlayerController player = GetComponent<PlayerController>();

        if (player != null)
        {
            
            player.SetMoving(0, 0);
            player.enabled = false;
        }

        yield return new WaitForSeconds(0.8f);

        if (player != null)
        {
            player.enabled = true;
        }

    }

    public bool CanRespawnCheckPoint()
    {
        return currentCheckPoint != null;
    }

}
