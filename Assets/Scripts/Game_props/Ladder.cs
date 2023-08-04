using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private BoxCollider2D coll;
    private PlayerController playerControll;

    private void Awake()
    {
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (playerControll.IsClimbing)
        {
            coll.enabled = false;
           
        }
        else coll.enabled = true;
        
    }
}
