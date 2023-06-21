using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_move : MonoBehaviour
{
    [SerializeField] private float delaySpikeTime;
    private Animator ani;
    [SerializeField] private bool isMove;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void StopSpike()
    {
        if (!isMove)
        {
            ani.speed = 0;
        }
    }
    private IEnumerator DelaySpike()
    {
        ani.speed = 0;
        yield return new WaitForSeconds(delaySpikeTime);
        ani.speed = 1;
    }
}
