using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private TypeColor card;

    public string  GetColorCard()
    {
        return card.Color;
    }
}
