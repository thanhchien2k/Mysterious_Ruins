using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineEnable : MonoBehaviour
{
    private PlayerController playerControll;
    void Start()
    {
        playerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if(playerControll!=null) playerControll.enabled = false;
    }

    private void OnDisable()
    {
        if (playerControll != null) playerControll.enabled = true;
    }



}
