using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    [SerializeField] private int playerBullet;
    [SerializeField] private int maxBullet;
    //public float startingBullet;
    private int curentPower;
    [SerializeField] private int maxPower;

    private string currentCard;
    [SerializeField] private AudioClip pickUPSound;
    private void Awake()
    {
        playerBullet = 0;
        curentPower = 0;
        currentCard= null;
        playerBullet = 0;
    }

    public void addBullet(int _value)
    {
        playerBullet =Mathf.Clamp(playerBullet + _value, 0, maxBullet);
    }

    public void subBullet(int _value)
    {
        playerBullet = Mathf.Clamp(playerBullet - _value, 0, maxBullet);
    }

    public int GetBullet()
    {
        return playerBullet;
    }

    public void AddPower(int _value)
    {
        curentPower = Mathf.Clamp(curentPower + _value, 0, maxPower);
    }

    public int GetPower()
    {
        return curentPower;
    }

    public int GetMaxPower()
    {
        return maxPower;
    }

    public string GetColorCurrentCard()
    {
        return currentCard;
    }

    public bool Checkcard()
    {
        if (currentCard == null) return false;
        else return true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Heart"))
        {
            collision.gameObject.SetActive(false);
            gameObject.GetComponent<Player_health>().addHealth(1);
            SoundManager.instance.PlaySound(pickUPSound);
        }

        if (collision.gameObject.CompareTag("Gun"))
        {
            addBullet(collision.gameObject.GetComponent<Addbullet>().GetBullet());
            collision.gameObject.SetActive(false);
            SoundManager.instance.PlaySound(pickUPSound);
        }

        if (collision.gameObject.CompareTag("Power"))
        {
            collision.gameObject.SetActive(false);
            AddPower(1);
            SoundManager.instance.PlaySound(pickUPSound);
        }

        if (collision.gameObject.CompareTag("Card"))
        {
            currentCard = collision.gameObject.GetComponent<Card>().GetColorCard();
            SoundManager.instance.PlaySound(pickUPSound);
            //collision.gameObject.SetActive(false);
        }
    }
}
