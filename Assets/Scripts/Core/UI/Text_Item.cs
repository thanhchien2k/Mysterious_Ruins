using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Item : MonoBehaviour
{
    [SerializeField] private string nameItems;
    private Text txt;
    private Image img;
    private Player_Item playerItems;
    [SerializeField]private Sprite[] CardImage;
    private void Awake()
    {
        playerItems = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Item>();
        txt = GetComponent<Text>();
        img = GetComponent<Image>();
    }

    private void Update()
    {
        UpdateItems();
    }
    private void UpdateItems()
    {
        
        if(nameItems == "Power")
        {
            txt.text = playerItems.GetPower().ToString() + "/" + playerItems.GetMaxPower().ToString();
        }
        else if(nameItems == "Bullet")
        {
            txt.text = playerItems.GetBullet().ToString();
            
        }
        else if(nameItems == "Card")
        {
            if (playerItems.GetColorCurrentCard() == null) return;
            else
            {
                string currentColorCard = playerItems.GetColorCurrentCard();
                if (currentColorCard == "Green") img.sprite = CardImage[0];
                else if (currentColorCard == "Red") img.sprite = CardImage[1];
                else if (currentColorCard == "Blue") img.sprite = CardImage[2];
                
            }
        }
    }

}
