using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player_health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
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
