using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_move : MonoBehaviour
{
    [SerializeField] private float delaySpikeTime;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private IEnumerator DelaySpike()
    {
        ani.speed = 0;
        yield return new WaitForSeconds(delaySpikeTime);
        ani.speed = 1;
    }
}
