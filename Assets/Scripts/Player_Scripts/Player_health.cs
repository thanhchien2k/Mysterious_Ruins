using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class Player_health : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    [SerializeField] private float maxHealth;
    private float currentHeath;
    private Animator ani;
    private bool dead;
    private UImanager uiManager;


    [Header("invulnerability")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer SP;
    private bool invulnerable;
    [SerializeField] private Behaviour[] component;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHeath = startingHealth;
        SP = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        uiManager = FindObjectOfType<UImanager>();

    }

    public void takeDamage(float _damage)
    {   if (invulnerable) return;
        currentHeath = Mathf.Clamp(currentHeath - _damage, 0,maxHealth);
        if (currentHeath > 0)
        {
            ani.SetTrigger("isHurt");
            StartCoroutine(invulnerability());
        }
        else
        {
            if (!dead)

            {
                if (GetComponent<PlayerController>() != null)
                {
                    GetComponent<PlayerController>().enabled = false;
                }

                if (GetComponent<PlayerAttack>() != null)
                {
                    GetComponent<PlayerAttack>().enabled = false;
                }


                foreach (Behaviour comp in component)
                {
                    comp.enabled = false;
                }
                dead = true;

                uiManager.GameOver();

                gameObject.SetActive(false);
            }
        }
    }

    public void addHealth(float _value)
    {
        currentHeath = Mathf.Clamp(currentHeath + _value, 0, maxHealth);
    }

    public float GetCurrentHealth()
    {
        return currentHeath;
    }

    public void IsRespawn()
    { 
        //ani.Play("player-idle");
        ani.SetBool("isJump", false);
        ani.SetBool("isRunning", false);
        StartCoroutine(invulnerability());
    }


    private IEnumerator invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(9, 10, true);

        for (int i=0; i < numberOfFlashes; i++)
        {
            SP.color = new Color(255, 0, 0, 100f);
            yield return new WaitForSeconds(iFrameDuration/(numberOfFlashes*2));
            SP.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            
        }

        Physics2D.IgnoreLayerCollision(9, 10, false);

        invulnerable = false;
    }
}
