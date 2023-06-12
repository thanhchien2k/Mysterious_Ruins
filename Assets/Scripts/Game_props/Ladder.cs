using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private PlayerController player;
    private void Update()
    {
        if (player.IsClimbing)
        {
            coll.enabled = false;
           
        }
        else coll.enabled = true;
        
    }
}
