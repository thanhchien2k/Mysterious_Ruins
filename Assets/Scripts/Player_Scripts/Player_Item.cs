using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Item : MonoBehaviour
{
    [SerializeField] private int playerBullet;
    [SerializeField] private int maxBullet;
    //public float startingBullet;
    private int power;
    [SerializeField] private int maxPower;

    [SerializeField]private string currentCard;

    private void Awake()
    {
        playerBullet = 0;
        power = 0;
        currentCard= null;
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
        power = Mathf.Clamp(power + _value, 0, maxPower);
    }

    public int GetPower()
    {
        return power;
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
        }

        if (collision.gameObject.CompareTag("Gun"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("ok");
            addBullet(1);
        }

        if (collision.gameObject.CompareTag("Power"))
        {
            collision.gameObject.SetActive(false);
            AddPower(1);
        }

        if (collision.gameObject.CompareTag("Card"))
        {
            currentCard = collision.gameObject.GetComponent<Card>().GetColorCard();
            //collision.gameObject.SetActive(false);
        }
    }
}
