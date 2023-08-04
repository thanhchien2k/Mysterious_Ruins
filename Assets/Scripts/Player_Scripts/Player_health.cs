using System.Collections;
using UnityEngine;

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

    [Header ("Sound")] 
    [SerializeField]private AudioClip deadthSound;
    [SerializeField]private AudioClip hurtSound;
    private Player_Respawn playerRespawn;

    // Start is called before the first frame update
    private void Awake()
    {
        currentHeath = startingHealth;
        SP = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        uiManager = FindObjectOfType<UImanager>();
        playerRespawn = GetComponent<Player_Respawn>();

    }

    public void TakeDamage(float _damage)
    {   if (invulnerable) return;
        currentHeath = Mathf.Clamp(currentHeath - _damage, 0,maxHealth);
        if (currentHeath > 0)
        {
            ani.SetTrigger("isHurt");
            SoundManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invulnerability());

        }
        else 
        {
            if (playerRespawn.CanRespawnCheckPoint()) 
            {
                ani.SetTrigger("isHurt");
                SoundManager.instance.PlaySound(hurtSound);
                StartCoroutine(Invulnerability());
            }
            else if (!dead)

            {
                foreach (Behaviour comp in component)
                {
                    comp.enabled = false;
                }

                dead = true;

                SoundManager.instance.PlaySound(deadthSound);

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
        ani.SetBool("isJump", false);
        ani.SetBool("isRunning", false);
    }

    public void IsRespawnCheckPoint()
    {
        ani.SetBool("isJump", false);
        ani.SetBool("isRunning", false);
        dead = false;
    }


    private IEnumerator Invulnerability()
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
