using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_shooting : Enemy
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBall;
    [SerializeField] private float delayShootingTime;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void enemyShooting()
    {
            fireBall[selectFireBall()].transform.position = firePoint.transform.position;
            fireBall[selectFireBall()].GetComponent<EnemyProjectTitle>().SetProjectTitleActive();
    }

    private int selectFireBall()
    {
        for (int i = 0; i < fireBall.Length; i++)
        {
            if (!fireBall[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

    private IEnumerator DelayShooting()
    {
        ani.speed = 0;
        yield return new WaitForSeconds(delayShootingTime);
        ani.speed = 1;
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
    }


}
