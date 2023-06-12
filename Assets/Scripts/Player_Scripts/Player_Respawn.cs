using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_Respawn : MonoBehaviour
{
    private Transform currentRespawnPoint;
    private Player_health playerHealth;
    private PlayerController playercontroller;
    private bool  isDeep;
    // Start is called before the first frame update
    private void Awake()
    {
        playerHealth = GetComponent<Player_health>();
    }

    // Update is called once per frame
    public void Respawn()
    {
        if (!isDeep) return;
        isDeep = false;
        StartCoroutine(isDeeping());
        transform.position = currentRespawnPoint.position;
        transform.localScale = currentRespawnPoint.localScale;
        playerHealth.IsRespawn();

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
    }

    private IEnumerator isDeeping()
    {

        if (GetComponent<PlayerController>() != null)
        {
            playercontroller = GetComponent<PlayerController>();
            playercontroller.setMoving(0, 0);
            playercontroller.enabled = false;
        }
        yield return new WaitForSeconds(1f);
            playercontroller.enabled = true;


    }

}
