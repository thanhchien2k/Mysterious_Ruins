using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]protected float enemyDamage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_health>().takeDamage(enemyDamage);
        }

    }
}
