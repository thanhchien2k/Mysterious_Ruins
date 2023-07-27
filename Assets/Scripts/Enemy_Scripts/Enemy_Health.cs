using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth;
    [SerializeField]private  float currentHealth;
    private Animator ani;
    [SerializeField] private Behaviour[] component;
    void Start()
    {
        ani = GetComponent<Animator>();
        currentHealth = maxHealth;
    }


    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            if (GetComponent<Enemy_follow>() != null)
            {
                GetComponent<Enemy_follow>().enabled = false;
            }

            if (GetComponent<Enemy_patrol>() != null)
            {
                GetComponent<Enemy_patrol>().enabled = false;
            }

            if (GetComponent<Enemy_shooting>() != null)
            {
                GetComponent<Enemy_shooting>().enabled = false;
            }

            foreach (Behaviour comp in component)
            {
                comp.enabled = false;
            }
            gameObject.SetActive(false);
        }
    }
}
