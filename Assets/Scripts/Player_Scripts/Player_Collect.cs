using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            gameObject.GetComponent<Player_health>().addHealth(1);
            collision.gameObject.SetActive(false);
            
        }

        if (collision.gameObject.CompareTag("Gun"))
        {
            gameObject.GetComponent<Player_Item>().addBullet(1);
            collision.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("Power"))
        {
            gameObject.GetComponent<Player_Item>().addPower(1);
            collision.gameObject.SetActive(false);

        }
    }

}
