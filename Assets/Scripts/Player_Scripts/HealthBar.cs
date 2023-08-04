using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player_health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
        totalHealthBar.fillAmount = playerHealth.startingHealth/ 10;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.GetCurrentHealth()/ 10;

        //if (playerHealth.currentHeath > 3)
        //{
        //    totalHealthBar.fillAmount = playerHealth.currentHeath / 10;
        //}
        
    }
}
