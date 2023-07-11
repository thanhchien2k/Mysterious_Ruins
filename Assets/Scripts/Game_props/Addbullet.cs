using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addbullet : MonoBehaviour
{
    [SerializeField] private int numberOfbullet;

    public int GetBullet()
    {
        return numberOfbullet;
    }
}
