using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float enemyDamage;
    public float maxHealth;
    protected float currentHealth;
    private Animator ani;
    public AudioClip explosionSound;


     void Start()
    {
        currentHealth = maxHealth;
        ani = GetComponent<Animator>();
        ani.speed = 1;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_health>().TakeDamage(enemyDamage);
        }
    }


}
